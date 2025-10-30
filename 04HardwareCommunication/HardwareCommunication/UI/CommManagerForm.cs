using System;
using System.Linq;
using System.Windows.Forms;
using HardwareCommunication.Abstractions;
using HardwareCommunication.Core;
using HardwareCommunication.Runtime;

namespace HardwareCommunication.UI
{
    public partial class CommManagerForm : Form
    {
        public CommManagerForm()
        {
            InitializeComponent();
            lst.SelectedIndexChanged += (_, __) => LoadCurrentView();
            btnAdd.Click += (_, __) => AddDevice();
            LoadList();
        }

        private void LoadList()
        {
            lst.Items.Clear();
            foreach (var c in CommManager.Instance.GetAllConfigs().OrderBy(c => c.Key))
                lst.Items.Add(c.Key);
            if (lst.Items.Count > 0) lst.SelectedIndex = 0;
        }

        private void AddDevice()
        {
            var providers = CommFactory.GetProviderNames();
            if (providers.Count == 0) { MessageBox.Show("未发现通讯插件"); return; }
            using (var dlg = new Form { Width = 300, Height = 260, Text = "选择通讯类型" })
            {
                var list = new ListBox { Dock = DockStyle.Fill };
                list.Items.AddRange(providers.Select(p => CommFactory.GetDisplayName(p)).Cast<object>().ToArray());
                var ok = new Button { Text = "确定", Dock = DockStyle.Bottom, Height = 30 };
                dlg.Controls.Add(list); dlg.Controls.Add(ok);
                ok.Click += (_, __) => dlg.DialogResult = DialogResult.OK;
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                var display = list.SelectedItem?.ToString();
                var provider = providers.FirstOrDefault(p => CommFactory.GetDisplayName(p) == display) ?? display;
                if (string.IsNullOrEmpty(provider)) return;
                var key = MakeUniqueName(provider);
                var cfg = new CommParameters { Key = key, Provider = provider, Host = "127.0.0.1", Port = 9000, Station = 1 };
                CommManager.Instance.AddOrUpdate(cfg);
                LoadList();
                lst.SelectedItem = key;
            }
        }

        private static string MakeUniqueName(string provider)
        {
            var exist = CommManager.Instance.GetAllConfigs().Select(c => c.Key).ToHashSet();
            for (int i = 0; i < 10000; i++)
            {
                var name = provider + i;
                if (!exist.Contains(name)) return name;
            }
            return provider + "_X";
        }

        private void LoadCurrentView()
        {
            rightHost.Controls.Clear();
            var key = lst.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(key)) return;
            var cfg = CommManager.Instance.GetAllConfigs().FirstOrDefault(c => c.Key == key);
            if (cfg == null) return;
            lblTitle.Text = cfg.Key + " - " + CommFactory.GetDisplayName(cfg.Provider);

            var view = CommFactory.CreateConfigView(cfg.Provider);
            if (view != null)
            {
                var ctrl = view.GetControl();
                view.LoadFrom(cfg);
                ctrl.Dock = DockStyle.Fill;
                rightHost.Controls.Add(ctrl);
            }
        }
    }
}
