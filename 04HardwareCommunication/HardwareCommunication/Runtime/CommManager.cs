using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HardwareCommunication.Abstractions;
using HardwareCommunication.Core;

namespace HardwareCommunication.Runtime
{
    /// <summary>
    /// 通讯管理器（单例）：
    /// - 维护配置、通道实例、设备在线状态
    /// - 提供 Add/Remove/Get 等 API
    /// - 自动保存/加载 XML 配置
    /// - 支持自动重连
    /// </summary>
    public sealed class CommManager
    {
        /// <summary>设备状态变化：key, expain, connected</summary>
        public event Action<string, string, bool> DeviceStateChanged;

        private readonly ConcurrentDictionary<string, (string expain, bool connected)> _states = new(StringComparer.OrdinalIgnoreCase);
        private readonly ConcurrentDictionary<string, CommParameters> _configs = new(StringComparer.OrdinalIgnoreCase);
        private readonly ConcurrentDictionary<string, ICommChannel> _channels = new(StringComparer.OrdinalIgnoreCase);
        private readonly ConcurrentDictionary<string, CancellationTokenSource> _reconnect = new(StringComparer.OrdinalIgnoreCase);

        private static readonly Lazy<CommManager> _inst = new(() => new CommManager(), LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary>单例实例</summary>
        public static CommManager Instance => _inst.Value;

        private readonly string _configPath;

        private CommManager()
        {
            _configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs", "CommConfigs.xml");
            Directory.CreateDirectory(Path.GetDirectoryName(_configPath));
            LoadConfigs();
        }

        private void UpdateState(string key, string expain, bool connected)
        {
            _states[key] = (expain, connected);
            DeviceStateChanged?.Invoke(key, expain, connected);
        }

        /// <summary>获取全部设备状态视图</summary>
        public IReadOnlyDictionary<string, (string expain, bool connected)> GetAllStates() => _states;
        /// <summary>获取全部配置</summary>
        public List<CommParameters> GetAllConfigs() => _configs.Values.ToList();

        /// <summary>添加或更新配置，并建立/更新通道。</summary>
        public bool AddOrUpdate(CommParameters cfg)
        {
            if (cfg == null || string.IsNullOrWhiteSpace(cfg.Key) || string.IsNullOrWhiteSpace(cfg.Provider))
                throw new ArgumentException("Key/Provider 不能为空");
            _configs.AddOrUpdate(cfg.Key, cfg, (_, _) => cfg);
            var ch = CreateChannel(cfg);
            if (ch != null)
            {
                _channels.AddOrUpdate(cfg.Key, ch, (_, __) => ch);
                WireChannelEvents(ch);
                EnsureReconnectLoop(cfg.Key, cfg.ReconnectIntervalMs, cfg.AutoReconnect, ch);
            }
            SaveConfigs();
            UpdateState(cfg.Key, cfg.Expain, ch != null && ch.IsConnected);
            return true;
        }

        /// <summary>删除配置以及对应通道。</summary>
        public bool Remove(string key)
        {
            var ok = _configs.TryRemove(key, out _);
            if (ok)
            {
                StopReconnect(key);
                if (_channels.TryRemove(key, out var ch))
                {
                    try { ch.Close(); } catch { }
                }
                SaveConfigs();
            }
            return ok;
        }

        /// <summary>按 Key 获取或创建通道。</summary>
        public ICommChannel GetChannel(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return null;
            if (_channels.TryGetValue(key, out var ch)) return ch;
            if (_configs.TryGetValue(key, out var cfg))
            {
                ch = CreateChannel(cfg);
                if (ch != null)
                {
                    _channels[key] = ch;
                    WireChannelEvents(ch);
                    EnsureReconnectLoop(cfg.Key, cfg.ReconnectIntervalMs, cfg.AutoReconnect, ch);
                }
                return ch;
            }
            return null;
        }

        private void WireChannelEvents(ICommChannel ch)
        {
            ch.ConnectionStateChanged -= OnConnectionChanged;
            ch.ConnectionStateChanged += OnConnectionChanged;
        }

        private void OnConnectionChanged(string key, bool connected)
        {
            if (_configs.TryGetValue(key, out var cfg))
            {
                UpdateState(key, cfg.Expain, connected);
            }
        }

        private ICommChannel CreateChannel(CommParameters cfg)
        {
            var ch = CommFactory.Create(cfg.Provider, cfg);
            return ch;
        }

        private void LoadConfigs()
        {
            if (!File.Exists(_configPath)) return;
            try
            {
                var ser = new XmlSerializer(typeof(List<CommParameters>));
                using var fs = File.OpenRead(_configPath);
                var list = (List<CommParameters>)ser.Deserialize(fs);
                foreach (var c in list)
                {
                    _configs[c.Key] = c;
                    var ch = CreateChannel(c);
                    if (ch != null)
                    {
                        _channels[c.Key] = ch;
                        WireChannelEvents(ch);
                        try { ch.Open(); } catch { }
                        UpdateState(c.Key, c.Expain, ch.IsConnected);
                        EnsureReconnectLoop(c.Key, c.ReconnectIntervalMs, c.AutoReconnect, ch);
                    }
                }
            }
            catch { }
        }

        private void SaveConfigs()
        {
            try
            {
                var ser = new XmlSerializer(typeof(List<CommParameters>));
                using var fs = File.Create(_configPath);
                ser.Serialize(fs, _configs.Values.ToList());
            }
            catch { }
        }

        private void EnsureReconnectLoop(string key, int intervalMs, bool autoReconnect, ICommChannel ch)
        {
            if (!autoReconnect) { StopReconnect(key); return; }
            StopReconnect(key);
            var cts = new CancellationTokenSource();
            _reconnect[key] = cts;
            _ = Task.Run(async () =>
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    try { if (!ch.IsConnected) ch.Open(); }
                    catch { }
                    await Task.Delay(Math.Max(500, intervalMs), cts.Token).ConfigureAwait(false);
                }
            }, cts.Token);
        }

        private void StopReconnect(string key)
        {
            if (_reconnect.TryRemove(key, out var cts))
            {
                try { cts.Cancel(); cts.Dispose(); } catch { }
            }
        }
    }
}
