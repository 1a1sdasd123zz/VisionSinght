using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HardwareCommunication.Abstractions;
using HardwareCommunication.Runtime;

namespace SocketComm
{
    public partial class TcpServerConfigView : UserControl, ICommConfigView
    {
        public TcpServerConfigView()
        {
            InitializeComponent();
            HookEvents();
        }

        private void HookEvents()
        {
            btnDoSend.Click += (_, __) => DoSend();
            btnClearSend.Click += (_, __) => txtSend.Clear();
            btnClearRecv.Click += (_, __) => txtRecv.Clear();
            chkConnect.CheckedChanged += (_, __) => ToggleConnect();
        }

        public ICommChannel Channel { get; private set; }
        public Control GetControl() => this;
        public void ApplyTo(ICommParameters parameters)
        {
            parameters.Host = txtHost.Text.Trim();
            parameters.Port = (int)numPort.Value;
            parameters.Expain = txtExpain.Text.Trim();
        }
        public void LoadFrom(ICommParameters parameters)
        {
            txtHost.Text = parameters.Host;
            numPort.Value = Math.Max(numPort.Minimum, Math.Min(numPort.Maximum, parameters.Port));
            txtExpain.Text = parameters.Expain;
            Channel = CommFactory.Create(parameters.Provider, parameters);
            if (Channel != null)
            {
                Channel.MessageReceived += OnMessage;
                Channel.ConnectionStateChanged += OnConnState;
            }
        }
        private void OnMessage(string key, byte[] data)
        {
            if (InvokeRequired) BeginInvoke(new Action(() => AppendRx(data)));
            else AppendRx(data);
        }
        private void AppendRx(byte[] data)
        {
            if (chkHexRecv.Checked)
                txtRecv.AppendText(string.Join(" ", data.Select(b => b.ToString("X2"))) + Environment.NewLine);
            else
                txtRecv.AppendText(Encoding.UTF8.GetString(data) + Environment.NewLine);
        }
        private void OnConnState(string key, bool connected)
        {
            if (IsDisposed) return;
            if (InvokeRequired) BeginInvoke(new Action(() => chkConnect.Checked = connected));
            else chkConnect.Checked = connected;
        }
        private void ToggleConnect()
        {
            if (Channel == null) return;
            ApplyTo(Channel.Parameters);
            if (chkConnect.Checked) Channel.Open(); else Channel.Close();
        }
        private void DoSend()
        {
            if (Channel == null || !Channel.IsConnected) { MessageBox.Show("未连接"); return; }
            byte[] data;
            if (chkHexSend.Checked)
            {
                try { data = HexToBytes(txtSend.Text); }
                catch { MessageBox.Show("16进制格式错误"); return; }
            }
            else
            {
                data = chkUtf8.Checked ? Encoding.UTF8.GetBytes(txtSend.Text ?? string.Empty) : Encoding.Default.GetBytes(txtSend.Text ?? string.Empty);
            }
            Channel.Send(data);
        }
        private static byte[] HexToBytes(string hex)
        {
            var s = new string((hex ?? string.Empty).Where(c => !char.IsWhiteSpace(c)).ToArray());
            if (s.Length % 2 != 0) throw new FormatException();
            var buf = new byte[s.Length / 2];
            for (int i = 0; i < buf.Length; i++) buf[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
            return buf;
        }
    }
}
