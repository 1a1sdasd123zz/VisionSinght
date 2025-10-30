using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HardwareCameraNet;
using VisionCore.Manager.CameraManager;
using VisionCore.Manager.PluginServer;

namespace UniVision.Forms;

public partial class Frm_Camera2D : DevExpress.XtraEditors.XtraForm
{
    // 维护当前选中的相机实例，用于切换时取消订阅以防重复订阅
    private ICamera currentSelectedCamera;


    public Frm_Camera2D()
    {
        InitializeComponent();
        // 表单显示后再初始化显示控件，避免首开阻塞
        //Shown += Frm_Camera2D_Shown;
    }
    private void Frm_Camera2D_Load(object sender, EventArgs e)
    {
        cmb_Manufacturers.Properties.Items.AddRange(CameraManager.Instance.GetAllManufacturers());

        DgvUpdate();

        SetControlState();
    }



    private void DgvUpdate()
    {
        dgv_CameraConfig.AutoGenerateColumns = false;
        dgv_CameraConfig.DataSource = CameraManager.Instance.GetAllCameraConfigs();
    }
    private void dgv_CameraConfig_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        // 只处理备注列
        if (dgv_CameraConfig.Columns[e.ColumnIndex].Name != "col_Expain")
            return;

        var sn = dgv_CameraConfig.Rows[e.RowIndex].Cells["col_SerialNumber"].Value?.ToString();
        var expain = dgv_CameraConfig.Rows[e.RowIndex].Cells["col_Expain"].Value?.ToString();

        if (string.IsNullOrEmpty(sn)) return;
        var configs = CameraManager.Instance.GetAllCameraConfigs();
        var config = configs.FirstOrDefault(cfg => cfg.SerialNumber == sn);
        if (config == null) return;
        config.Expain = expain ?? "";
        CameraManager.Instance.AddOrUpdateCameraConfig(config);

        // 刷新界面
        dgv_CameraConfig.DataSource = null;
        dgv_CameraConfig.DataSource = CameraManager.Instance.GetAllCameraConfigs();
    }

    private void SetControlState(bool connect = false)
    {
        SetControlText();
        if (connect)
        {
            txt_Exposure.Enabled = true;
            txt_Gain.Enabled = true;
            chk_HardTrigger.Enabled = true;

            btn_Connect.Enabled = false;
            btn_TriggerOnce.Enabled = true;
            btn_DisConnect.Enabled = true;
            btn_Continuous.Enabled = true;
        }
        else
        {
            txt_Exposure.Enabled = false;
            txt_Gain.Enabled = false;
            chk_HardTrigger.Enabled = false;

            
            
            btn_TriggerOnce.Enabled = false;
            btn_DisConnect.Enabled = false;
            btn_Continuous.Enabled = false;
            chk_HardTrigger.Checked = false;

            btn_Connect.Enabled = cmb_SnList.EditValue != null;
        }
    }
    private void SetControlText()
    {
        try
        {
            if(currentSelectedCamera == null)return;

            if (currentSelectedCamera.IsConnected)
            {
                txt_Exposure.EditValue = currentSelectedCamera.Parameters.ExposureTime;
                txt_Gain.EditValue = currentSelectedCamera.Parameters.Gain;
                txt_MaxExposure.Text = currentSelectedCamera.Parameters.MaxExposureTime.ToString("F5");
                txt_MaxGain.Text = currentSelectedCamera.Parameters.MaxGain.ToString("F5");
                cmb_TriggerSource.Properties.Items.Clear();
                cmb_TriggerSource.Properties.Items.AddRange(currentSelectedCamera.Parameters.TriggerSoures);
            }
            else
            {
                txt_Exposure.EditValue = 0;
                txt_Gain.EditValue = 0;
                txt_MaxExposure.Text = "0";
                txt_MaxGain.Text = "0";
                cmb_TriggerSource.Properties.Items.Clear();
            }

        }
        catch (Exception)
        {
            // ignored
        }
    }

    private void cmb_SnList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // 防止下拉框初始化时触发（无实际选择）
            if (cmb_SnList.SelectedItem == null || string.IsNullOrEmpty(cmb_SnList.SelectedText))
                return;

            btn_Connect.Enabled = true;
            // 取消当前相机的事件订阅（避免切换时残留订阅）
            UnsubscribeCurrentCameraEvent();

            // 获取厂商名称和选中的序列号
            var selectedManufacturer = cmb_Manufacturers.Text;
            var selectedSerial = cmb_SnList.SelectedText.Trim(); // 确保去除空格

            // 通过CameraManager获取相机实例（缓存中存在则直接返回）
            var newCamera = CameraManager.Instance.CreateCamera(selectedManufacturer, selectedSerial);
            if (newCamera == null)
            {
                MessageBox.Show($"获取相机{selectedSerial}失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentSelectedCamera = null;
                SetControlState(connect: false); // 更新UI为未连接状态
                return;
            }

            // 订阅新相机的事件
            SubscribeNewCameraEvent(newCamera);

            //更新当前相机状态，并同步UI
            currentSelectedCamera = newCamera;
            SetControlState(currentSelectedCamera.IsConnected);
            
        }
        catch (Exception)
        {
            // ignored
        }
    }

    private void cmb_Manufacturers_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmb_SnList.SelectedText = "";
        cmb_SnList.Properties.Items.Clear();
        var list = CameraManager.Instance.EnumerateDevices(cmb_Manufacturers.Text);
        cmb_SnList.Properties.Items.AddRange(list);
    }
    /// <summary>
    /// 订阅新相机的FrameGrabedEvent（确保只订阅一次）
    /// </summary>
    private void SubscribeNewCameraEvent(ICamera newCamera)
    {
        if (newCamera == null) return;

        //订阅前先取消一次（防止相机实例被其他地方订阅过）
        newCamera.FrameGrabedEvent -= UpdateUIImage;
        // 正式订阅
        newCamera.FrameGrabedEvent += UpdateUIImage;
        Console.WriteLine($"订阅相机{newCamera.SN}的图像事件");
    }
    /// <summary>
    /// 取消当前相机的FrameGrabedEvent订阅
    /// </summary>
    private void UnsubscribeCurrentCameraEvent()
    {
        if (currentSelectedCamera != null)
        {
            // 取消订阅
            currentSelectedCamera.FrameGrabedEvent -= UpdateUIImage;
            Console.WriteLine($"取消订阅相机{currentSelectedCamera.SN}的图像事件");
        }
    }

    private void UpdateUIImage(object sender, object img)
    {
        var dispatcher = pictureEdit_Display ?? (Control)this;
        if (dispatcher.InvokeRequired)
        {
            dispatcher.BeginInvoke(new Action<object, object>(UpdateUIImage), sender, img);
            return;
        }
        try
        {
            if (img is Bitmap bmp)
            {
                pictureEdit_Display.Image = bmp;
            }
        }
        catch (Exception)
        {
            // ignored
        }
    }

    private void DisConnectEvent(object sender, bool disconnect)
    {
        Invoke(() =>
        {
            if (cmb_SnList.SelectedText == ((ICamera)sender).SN)
            {
                SetControlState(!disconnect);
            }
        });

    }

    private void txt_Exposure_EditValueChanged(object sender, EventArgs e)
    {
        try
        {
            var val = double.Parse(txt_Exposure.Text);
            var max = currentSelectedCamera.Parameters.MaxExposureTime;
            if (val > max)
            {
                val = max;
                txt_Exposure.EditValue = val;
            }
            currentSelectedCamera.Parameters.ExposureTime = val;
        }
        catch (Exception exception)
        {
            MessageBox.Show("曝光设置失败" + exception, "", MessageBoxButtons.OK);
        }
    }
     
    private void txt_Gain_EditValueChanged(object sender, EventArgs e)
    {
        try
        {
            double val = double.Parse(txt_Gain.Text);
            var max = currentSelectedCamera.Parameters.MaxGain;
            if (val > max)
            {
                val = max;
                txt_Gain.EditValue = val;
            }
            
            currentSelectedCamera.Parameters.Gain = val;
        }
        catch (Exception exception)
        {
            MessageBox.Show("增益设置失败" + exception, "", MessageBoxButtons.OK);
        }
    }
    private void cmb_TriggerSource_SelectedIndexChanged(object sender, EventArgs e)
    {
        currentSelectedCamera.Parameters.TriggerSoure = cmb_TriggerSource.Text;
    }

    private void btn_Add_Click(object sender, EventArgs e)
    {
        try
        {
            var selectedManufacturer = cmb_Manufacturers.Text;
            var selectedSerial = cmb_SnList.SelectedText.Trim();
            if (string.IsNullOrEmpty(selectedManufacturer) || string.IsNullOrEmpty(selectedSerial))
            {
                MessageBox.Show("请选择厂商和序列号");
                return;
            }

            var configs = CameraManager.Instance.GetAllCameraConfigs();
            var existConfig = configs.FirstOrDefault(cfg => cfg.SerialNumber == selectedSerial);

            string expain;
            if (existConfig == null)
            {
                // 新建时自动生成备注
                var usedIndexes = configs
                    .Select(cfg => cfg.Expain)
                    .Where(exp => exp != null && exp.StartsWith("相机"))
                    .Select(exp =>
                    {
                        if (int.TryParse(exp.Substring(2), out int idx))
                            return idx;
                        return -1;
                    })
                    .Where(idx => idx >= 0)
                    .ToHashSet();

                int nextIndex = 0;
                while (usedIndexes.Contains(nextIndex))
                    nextIndex++;
                expain = $"相机{nextIndex}";
            }
            else
            {
                // 已存在则保留原备注
                expain = existConfig.Expain;
            }

            var fullName = currentSelectedCamera.GetType().FullName;
            if (fullName != null)
                CameraManager.Instance.AddOrUpdateCameraConfig(
                    new CameraConfig(selectedSerial, selectedManufacturer,
                        CameraPluginServer.Instance.GetPluginInfo(fullName))
                    {
                        Expain = expain
                    });
            DgvUpdate();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }

    private void btn_Remove_Click(object sender, EventArgs e)
    {
        // 判断是否有选中行
        if (dgv_CameraConfig.SelectedRows.Count == 0)
        {
            //MessageBox.Show("请先选择要移除的相机配置行！");
            return;
        }

        // 获取选中行
        var row = dgv_CameraConfig.SelectedRows[0];
        var sn = row.Cells["col_SerialNumber"].Value?.ToString();

        if (string.IsNullOrEmpty(sn))
        {
            MessageBox.Show("选中的行序列号无效！");
            return;
        }
        if(DialogResult.Yes != MessageBox.Show("是否移除相机配置！","",MessageBoxButtons.YesNoCancel))return;
        // 调用CameraManager移除配置
        if (CameraManager.Instance.RemoveCameraConfig(sn))
        {
            dgv_CameraConfig.Rows.Remove(row);
            //MessageBox.Show($"已移除相机配置：{sn}");
        }
        else
        {
            MessageBox.Show("移除失败，未找到该序列号的配置！");
        }
    }
    private void btn_Connect_Click(object sender, EventArgs e)
    {
        try
        {
            currentSelectedCamera.Open();
            SetControlState(currentSelectedCamera.IsConnected);
            currentSelectedCamera.DisConnetEvent += DisConnectEvent;
        }
        catch (Exception)
        {
            //MessageBox.Show($"打开相机失败,错误码{errCode}," + exception, "", MessageBoxButtons.OK);
        }
    }
    private void btn_DisConnect_Click(object sender, EventArgs e)
    {
        try
        {
            currentSelectedCamera.DisConnet();
            SetControlState(currentSelectedCamera.IsConnected);
            currentSelectedCamera.DisConnetEvent -= DisConnectEvent;
        }
        catch (Exception exception)
        {
            MessageBox.Show($"关闭相机失败," + exception, "", MessageBoxButtons.OK);
        }
    }
    private void btn_TriggerOnce_Click(object sender, EventArgs e)
    {
        currentSelectedCamera.SoftwareTriggerOnce();
    }
    private void btn_Continuous_Click(object sender, EventArgs e)
    {
        if (btn_Continuous.Text == "连续采集")
        {
            currentSelectedCamera.ContinuousGrab();
            btn_Continuous.Text = "停止采集";
            btn_DisConnect.Enabled = false;
        }
        else
        {
            currentSelectedCamera.StopContinuousGrab();
            btn_Continuous.Text = "连续采集";
            btn_DisConnect.Enabled = true;
        }
    }
    private void chk_HardTrigger_CheckedChanged(object sender, EventArgs e)
    {
        cmb_TriggerSource.Visible = chk_HardTrigger.Checked;
        if (chk_HardTrigger.Checked && currentSelectedCamera != null)
        {
            // 选中当前触发源字符串
            cmb_TriggerSource.SelectedItem = currentSelectedCamera.Parameters.TriggerSoure;
        }
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            // 2. 取消相机事件订阅，避免残留引用
            UnsubscribeCurrentCameraEvent();

            // 3. 释放设计器组件（默认逻辑）
            if (components != null)
                components.Dispose();
        }
        base.Dispose(disposing);
    }
}