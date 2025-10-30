using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using HardwareCommunication.Abstractions;
using HardwareCommunication.Core;

namespace SocketComm
{
    /// <summary>
    /// TCP 客户端通道实现。
    /// - 能力类型：<see cref="CommCapabilities.Message"/>
    /// - 发送：调用 <see cref="Send(byte[])"/> 直接写入网络流
    /// - 接收：内部启动后台接收循环，收到数据后通过 <see cref="BaseCommChannel.MessageReceived"/> 事件上报
    /// - 连接状态：在 <see cref="Open"/> / <see cref="Close"/> 以及异常时调用 <see cref="BaseCommChannel.ConnectionStateChanged"/> 通知
    /// </summary>
    [CommProvider("TcpClient", typeof(TcpClientConfigView), "TCP客户端")]
    public class TcpClientChannel : BaseCommChannel
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private bool _rxExit;

        /// <summary>
        /// 通过通用通讯参数构造 TCP 客户端。
        /// <para>使用 <see cref="ICommParameters.Host"/> 与 <see cref="ICommParameters.Port"/> 建立连接。</para>
        /// </summary>
        public TcpClientChannel(ICommParameters parameters) : base(parameters) { }

        /// <summary>
        /// 是否处于已连接状态。
        /// </summary>
        public override bool IsConnected => _client != null && _client.Connected;

        /// <summary>
        /// 通道能力：仅支持消息收发，不支持寄存器读写。
        /// </summary>
        public override CommCapabilities Capabilities => CommCapabilities.Message;

        /// <summary>
        /// 打开连接并启动后台接收循环。
        /// </summary>
        /// <returns>0 表示成功，负数表示失败。</returns>
        public override int Open()
        {
            try
            {
                Close();
                _client = new TcpClient();
                // 连接使用超时控制
                var ar = _client.BeginConnect(Parameters.Host, Parameters.Port, null, null);
                if (!ar.AsyncWaitHandle.WaitOne(Parameters.ConnectTimeoutMs)) { _client.Close(); throw new TimeoutException(); }
                _client.EndConnect(ar);
                _client.SendTimeout = Parameters.SendTimeoutMs;
                _client.ReceiveTimeout = Parameters.ReceiveTimeoutMs;
                _stream = _client.GetStream();
                RaiseConnection(true);
                StartReceiveLoop();
                return 0;
            }
            catch
            {
                RaiseConnection(false);
                return -1;
            }
        }

        /// <summary>
        /// 关闭连接并停止接收循环。
        /// </summary>
        public override void Close()
        {
            _rxExit = true;
            try { _stream?.Close(); } catch { }
            try { _client?.Close(); } catch { }
            _stream=null; _client=null;
            RaiseConnection(false);
        }

        /// <summary>
        /// 发送字节数组到远端。
        /// </summary>
        /// <param name="payload">要发送的数据</param>
        /// <returns>写入的字节数，失败返回 -1。</returns>
        public override int Send(byte[] payload)
        {
            if (!IsConnected) return -1;
            try { _stream.Write(payload, 0, payload.Length); return payload.Length; } catch { Close(); return -1; }
        }

        /// <summary>
        /// 后台接收循环：有数据可读即读取并通过事件抛出，避免阻塞主线程。
        /// </summary>
        private void StartReceiveLoop()
        {
            _rxExit = false;
            _ = Task.Run(async () =>
            {
                var buf = new byte[4096];
                while (!_rxExit)
                {
                    try
                    {
                        if (!IsConnected) break;
                        if (_stream.DataAvailable)
                        {
                            var n = await _stream.ReadAsync(buf, 0, buf.Length);
                            if (n > 0)
                            {
                                var data = new byte[n];
                                Buffer.BlockCopy(buf, 0, data, 0, n);
                                // 将接收的数据通过事件抛出给订阅者（上层统一处理）
                                RaiseMessage(data);
                            }
                        }
                    }
                    catch { Close(); break; }
                    await Task.Delay(10);
                }
            });
        }
    }
}
