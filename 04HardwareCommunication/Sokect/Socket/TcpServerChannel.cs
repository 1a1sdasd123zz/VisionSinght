using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using HardwareCommunication.Abstractions;
using HardwareCommunication.Core;

namespace SocketComm
{
    /// <summary>
    /// TCP 服务端通道实现。
    /// </summary>
    [CommProvider("TcpServer", typeof(TcpServerConfigView), "TCP服务器")]
    public class TcpServerChannel : BaseCommChannel
    {
        private TcpListener _listener;
        private TcpClient _client;
        private NetworkStream _stream;
        private bool _rxExit;

        /// <summary>
        /// 通过通用参数构造服务端，使用 <see cref="ICommParameters.Port"/> 进行监听。
        /// </summary>
        public TcpServerChannel(ICommParameters parameters) : base(parameters) { }

        /// <summary>
        /// 当前是否有客户端连接。
        /// </summary>
        public override bool IsConnected => _client != null && _client.Connected;

        /// <summary>
        /// 通道能力：仅支持消息收发，不支持寄存器读写。
        /// </summary>
        public override CommCapabilities Capabilities => CommCapabilities.Message;

        /// <summary>
        /// 开始监听并等待客户端接入。
        /// </summary>
        public override int Open()
        {
            try
            {
                Close();
                _listener = new TcpListener(IPAddress.Any, Parameters.Port);
                _listener.Start();
                AcceptLoop();
                return 0;
            }
            catch
            {
                RaiseConnection(false);
                return -1;
            }
        }

        /// <summary>
        /// 后台接受连接循环，新的连接会替换旧连接。
        /// </summary>
        private void AcceptLoop()
        {
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        var c = await _listener.AcceptTcpClientAsync();
                        ReplaceClient(c);
                    }
                    catch { break; }
                }
            });
        }

        private void ReplaceClient(TcpClient c)
        {
            try { _client?.Close(); } catch { }
            _client = c;
            _stream = _client.GetStream();
            RaiseConnection(true);
            StartReceiveLoop();
        }

        /// <summary>
        /// 关闭监听与当前连接。
        /// </summary>
        public override void Close()
        {
            _rxExit = true;
            try { _stream?.Close(); } catch { }
            try { _client?.Close(); } catch { }
            try { _listener?.Stop(); } catch { }
            _stream=null; _client=null; _listener=null;
            RaiseConnection(false);
        }

        /// <summary>
        /// 向已连接的客户端发送数据。
        /// </summary>
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
