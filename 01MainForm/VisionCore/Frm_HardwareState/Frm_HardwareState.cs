using System.Collections.Generic;
using System.Windows.Forms;
using VisionCore.Manager.CameraManager;

namespace VisionCore.Frm_HardwareState
{
    public partial class Frm_HardwareState : UserControl
    {
        private readonly Dictionary<string, StateItem> CameraDeviceStateItems = new();
        public Frm_HardwareState()
        {
            InitializeComponent();

            // 先同步所有设备状态
            foreach (var kv in CameraManager.Instance.GetAllDeviceStates())
            {
                AddOrUpdateDevice(kv.Key, kv.Value.expain, kv.Value.isConnected);
            }

            CameraManager.Instance.DeviceStateChanged += AddOrUpdateDevice;
            flowlayoutPanel_HardCamera.SizeChanged += FlowlayoutPanel_HardCamera_SizeChanged;
        }

        private void AddOrUpdateDevice(string sn, string expain, bool isConnected)
        {
            if (CameraDeviceStateItems.TryGetValue(sn, out var stateItem))
            {

                stateItem.SetState(expain, isConnected);
            }
            else
            {
                var item = new StateItem(sn, expain, isConnected);
                CameraDeviceStateItems.Add(sn,item);
                item.Height = 50;
                item.Width = flowlayoutPanel_HardCamera.ClientSize.Width;
                flowlayoutPanel_HardCamera.Controls.Add(item);
            }
        }
        private void FlowlayoutPanel_HardCamera_SizeChanged(object sender, System.EventArgs e)
        {
            foreach (Control ctrl in flowlayoutPanel_HardCamera.Controls)
            {
                ctrl.Width = flowlayoutPanel_HardCamera.ClientSize.Width;
            }
        }
    }
}
