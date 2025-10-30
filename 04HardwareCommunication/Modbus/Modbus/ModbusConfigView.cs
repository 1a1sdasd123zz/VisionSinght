using System;
using System.Linq;
using System.Windows.Forms;
using HardwareCommunication.Abstractions;
using HardwareCommunication.Runtime;

namespace Modbus
{
    public partial class ModbusConfigView : UserControl, ICommConfigView
    {
        public ModbusConfigView()
        {
            InitializeComponent();
            HookEvents();
        }

        private void HookEvents()
        {
            btnConnect.Click += (_, __) => DoConnect(true);
            btnDisconnect.Click += (_, __) => DoConnect(false);
            btnReadU16.Click += (_, __) => DoReadU16();
            btnWriteU16.Click += (_, __) => DoWriteU16();
        }

        public ICommChannel Channel { get; private set; }
        public Control GetControl() => this;
        public void ApplyTo(ICommParameters p)
        {
            p.Host = txtHost.Text.Trim();
            p.Port = (int)numPort.Value;
            p.Station = (int)numStation.Value;
            p.ConnectTimeoutMs = (int)numConnTo.Value;
            p.ReceiveTimeoutMs = (int)numRecvTo.Value;
        }
        public void LoadFrom(ICommParameters p)
        {
            txtHost.Text = p.Host;
            numPort.Value = p.Port;
            numStation.Value = p.Station;
            numConnTo.Value = p.ConnectTimeoutMs;
            numRecvTo.Value = p.ReceiveTimeoutMs;
            Channel = CommFactory.Create(p.Provider, p);
        }

        private void DoConnect(bool connect)
        {
            if (Channel == null) return;
            ApplyTo(Channel.Parameters);
            if (connect)
            {
                var r = Channel.Open();
                btnConnect.Enabled = r != 0;
                btnDisconnect.Enabled = r == 0;
            }
            else
            {
                Channel.Close();
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
            }
        }

        private void DoReadU16()
        {
            if (Channel == null) return;
            try
            {
                var res = Channel.ReadUInt16(txtAddr.Text.Trim(), (ushort)numLen.Value);
                txtResult.AppendText("读取成功: " + string.Join(",", res.Select(x => x.ToString())) + Environment.NewLine);
            }
            catch (Exception ex)
            {
                txtResult.AppendText("读取失败: " + ex.Message + Environment.NewLine);
            }
        }

        private void DoWriteU16()
        {
            if (Channel == null) return;
            try
            {
                var ok = Channel.WriteUInt16(txtAddr.Text.Trim(), ushort.Parse(txtWriteVal.Text.Trim()));
                txtResult.AppendText(ok ? "写入成功" + Environment.NewLine : "写入失败" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                txtResult.AppendText("写入失败: " + ex.Message + Environment.NewLine);
            }
        }
    }
}
