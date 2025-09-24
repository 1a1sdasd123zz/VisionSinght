#nullable enable
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using NLog;

namespace Logger;

public partial class Frm_Log : UserControl
{
    // 当前过滤类型，null表示全部
    private LogLevel? currentFilter;

    public Frm_Log()
    {
        InitializeComponent();
        LogHelper.LogChanged += UpdateLogView;

        UpdateLogView();

        gridView1.RowCellStyle += GridView1_RowCellStyle;

        btn_Info.Click += (_, _) => ToggleFilter(LogLevel.Info);
        btn_Warning.Click += (_, _) => ToggleFilter(LogLevel.Warn);
        btn_Error.Click += (_, _) => ToggleFilter(LogLevel.Error);

    }

    /// <summary>
    /// 刷新界面和按钮数量
    /// </summary>
    private void UpdateLogView()
    {
        if (InvokeRequired)
        {
            BeginInvoke(new MethodInvoker(UpdateLogView));
            return;
        }

        var logs = currentFilter == null
            ? LogHelper.Logs.ToList()
            : LogHelper.Logs.Where(l => l.Level == currentFilter).ToList();

        gridControl1.DataSource = logs;
        UpdateButtonText();
    }

    /// <summary>
    /// 按钮文本显示数量
    /// </summary>
    private void UpdateButtonText()
    {
        int infoCount = LogHelper.Logs.Count(l => l.Level == LogLevel.Info);
        int warnCount = LogHelper.Logs.Count(l => l.Level == LogLevel.Warn);
        int errorCount = LogHelper.Logs.Count(l => l.Level == LogLevel.Error);

        btn_Info.Text = $"信息({infoCount})";
        btn_Warning.Text = $"警告({warnCount})";
        btn_Error.Text = $"错误({errorCount})";

        // 重置所有按钮颜色
        btn_Info.Appearance.BackColor = Color.FromArgb(64,64,64);
        btn_Warning.Appearance.BackColor = Color.FromArgb(64, 64, 64);
        btn_Error.Appearance.BackColor = Color.FromArgb(64, 64, 64);

        // 根据当前过滤类型设置按钮颜色
        if (currentFilter == LogLevel.Info)
            btn_Info.Appearance.BackColor = Color.Lime;
        else if (currentFilter == LogLevel.Warn)
            btn_Warning.Appearance.BackColor = Color.Lime;
        else if (currentFilter == LogLevel.Error)
            btn_Error.Appearance.BackColor = Color.Lime;
    }

    /// <summary>
    /// 切换过滤类型，支持再次点击显示全部
    /// </summary>
    private void ToggleFilter(LogLevel level)
    {
        currentFilter = currentFilter == level ? null : level;

        UpdateLogView();
    }

    /// <summary>
    /// 日志行颜色区分
    /// </summary>
    private void GridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
    {
        var view = sender as GridView;
        if (view == null) return;
        var entry = view.GetRow(e.RowHandle) as LogEntry;
        if (entry == null) return;

        e.Appearance.BackColor = Color.Black; // 设置背景色为黑色
        switch (entry.Level.Name)
        {
            case "Info":
                e.Appearance.ForeColor = Color.Lime;
                break;
            case "Warn":
                e.Appearance.ForeColor = Color.Orange;
                break;
            case "Error":
                e.Appearance.ForeColor = Color.Red;
                break;
        }
    }
}
