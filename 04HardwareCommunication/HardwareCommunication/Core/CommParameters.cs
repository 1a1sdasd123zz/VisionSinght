using HardwareCommunication.Abstractions;

namespace HardwareCommunication.Core
{
    public class CommParameters : ICommParameters
    {
        public string Key { get; set; }
        public string Provider { get; set; }
        public string Host { get; set; }
        public int Port { get; set; } = 502;
        public int Station { get; set; } = 1;
        public int ConnectTimeoutMs { get; set; } = 3000;
        public int SendTimeoutMs { get; set; } = 3000;
        public int ReceiveTimeoutMs { get; set; } = 3000;
        public bool AutoReconnect { get; set; } = true;
        public int ReconnectIntervalMs { get; set; } = 2000;
        public string Expain { get; set; } = string.Empty;

        public override string ToString() => Key;
    }
}
