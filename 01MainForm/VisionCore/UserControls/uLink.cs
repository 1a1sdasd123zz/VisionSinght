using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using VisionCore.Linking;
using VisionCore.Frm_Solution;

namespace VisionCore.UserControls
{
    public partial class uLink : XtraUserControl
    {
        private object _toolInstance;
        private string _targetProperty;
        private Type _targetType;
        private string _actualPath; // 原始完整路径: 流程.工具.变量名

        public uLink()
        {
            InitializeComponent();
        }

        /// <summary>实际绑定使用的完整路径。</summary>
        public string SelectedPath
        {
            get => _actualPath;
            set
            {
                _actualPath = value;
                txt_LinkPath.Text = BuildDisplayPath(value);
            }
        }

        private string BuildDisplayPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return string.Empty;
            var vd = LinkRegistry.Instance.Resolve(path);
            if (vd == null) return path; // 未找到保持原样
            try
            {
                var parts = path.Split('.');
                if (parts.Length == 0) return path;
                // 使用 Description 优先，其次 DisplayName，再次原属性名
                string friendly = !string.IsNullOrWhiteSpace(vd.Description) ? vd.Description : (!string.IsNullOrWhiteSpace(vd.DisplayName) ? vd.DisplayName : vd.Name);
                parts[parts.Length - 1] = friendly;
                return string.Join(".", parts);
            }
            catch { return path; }
        }

        public void Setup(object tool, string targetProperty, Type targetType)
        {
            _toolInstance = tool;
            _targetProperty = targetProperty;
            _targetType = targetType;
            var ctx = GetLinkContext();
            if (ctx != null)
                SelectedPath = ctx.GetBindingPath(targetProperty); // setter 会处理显示
            btn_Link.Click -= Btn_Link_Click; btn_Link.Click += Btn_Link_Click;
            btn_Clear.Click -= Btn_Clear_Click; btn_Clear.Click += Btn_Clear_Click;
        }

        private ToolLinkContext GetLinkContext()
        {
            if (_toolInstance == null) return null;
            var prop = _toolInstance.GetType().GetProperty("LinkContext");
            return prop?.GetValue(_toolInstance) as ToolLinkContext;
        }

        private string GetToolName()
        {
            try
            {
                return _toolInstance?.GetType().GetProperty("Name")?.GetValue(_toolInstance) as string;
            }
            catch { return null; }
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            SelectedPath = string.Empty;
            var ctx = GetLinkContext();
            ctx?.SetBinding(_targetProperty, null);
        }

        private void Btn_Link_Click(object sender, EventArgs e)
        {
            var selfName = GetToolName();
            using var frm = new Frm_LinkValue(_targetType, selfName);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var path = frm.SelectedVariablePath;
                if (!string.IsNullOrWhiteSpace(path))
                {
                    SelectedPath = path; // 更新显示+内部路径
                    var ctx = GetLinkContext();
                    ctx?.SetBinding(_targetProperty, path);
                }
            }
        }
    }
}
