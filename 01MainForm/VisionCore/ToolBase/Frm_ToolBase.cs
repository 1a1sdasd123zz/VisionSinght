namespace VisionCore.ToolBase;

public partial class Frm_ToolBase : DevExpress.XtraEditors.XtraForm
{
    // 修改为 protected 以便子类访问并挂接事件/更新状态
    protected DevExpress.XtraEditors.SimpleButton BtnRun => btn_Run;
    protected DevExpress.XtraEditors.SimpleButton BtnConfirm => btn_Confirm;
    protected DevExpress.XtraEditors.SimpleButton BtnCancel => btn_Cancel;
    protected DevExpress.XtraEditors.LabelControl LblTime => txt_Time;
    protected DevExpress.XtraEditors.LabelControl LblState => txt_State;

    protected Frm_ToolBase()
    {
        InitializeComponent();
    }

}