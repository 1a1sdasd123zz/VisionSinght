#nullable enable
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils; // 新增
using NLog;
using System.ComponentModel;
using DevExpress.XtraEditors.Repository;

namespace Logger;

public partial class Frm_Log : UserControl
{
    // 当前过滤类型，null表示全部
    private LogLevel? currentFilter;
    // 仅初始化列一次
    private bool _columnsInitialized;
    // 绑定源，避免频繁重设 DataSource 导致滚动条跳动
    private readonly BindingList<LogEntry> _binding = new();

    public Frm_Log()
    {
        InitializeComponent();
        InitUIControls();

        // 绑定一次数据源
        gridControl1.DataSource = _binding;

        LogHelper.LogChanged += UpdateLogView;
        LogHelper.LogAppended += OnLogAppended;

        UpdateLogView();

        gridView1.RowCellStyle += GridView1_RowCellStyle;

        btn_Info.Click += (_, _) => ToggleFilter(LogLevel.Info);
        btn_Warning.Click += (_, _) => ToggleFilter(LogLevel.Warn);
        btn_Error.Click += (_, _) => ToggleFilter(LogLevel.Error);

        // 尺寸与列变动时，动态调整“消息”列宽
        gridControl1.SizeChanged += (_, _) => AdjustMessageColumnWidth();
        gridView1.ColumnWidthChanged += (_, _) => AdjustMessageColumnWidth();
        gridView1.Layout += (_, _) => AdjustMessageColumnWidth();
    }

    private void InitUIControls()
    {
        gridView1.OptionsBehavior.Editable = false;
        gridView1.OptionsBehavior.ReadOnly = true;
        gridView1.OptionsView.ShowGroupPanel = false;
        gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
        gridView1.OptionsView.ColumnAutoWidth = false; // 关闭全局自适应，便于手动控制
        gridView1.OptionsView.RowAutoHeight = true;    // 启用自动行高，长消息完整显示
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

        // 记录当前滚动位置与是否在底部
        int prevTop = gridView1.TopRowIndex;
        int prevFocused = gridView1.FocusedRowHandle;
        bool atBottom = IsAtBottom();

        var logs = currentFilter == null
            ? LogHelper.Logs.ToList()
            : LogHelper.Logs.Where(l => l.Level == currentFilter).ToList();

        gridView1.BeginUpdate();
        _binding.Clear();
        foreach (var l in logs) _binding.Add(l);
        gridView1.EndUpdate();
        gridControl1.RefreshDataSource();

        EnsureColumns(); // 确保列只初始化一次
        AdjustMessageColumnWidth(); // 绑定/刷新后调整一次

        // 恢复滚动：若之前在底部，则滚动到底；否则尽量保持原位置
        if (atBottom)
        {
            var last = gridView1.DataRowCount - 1;
            if (last >= 0)
            {
                gridView1.FocusedRowHandle = last;
                gridView1.MakeRowVisible(last);
            }
        }
        else
        {
            // 尽量还原之前的 TopRowIndex / FocusedRow
            gridView1.TopRowIndex = prevTop < gridView1.DataRowCount ? prevTop : 0;
            if (prevFocused >= 0 && prevFocused < gridView1.DataRowCount)
                gridView1.FocusedRowHandle = prevFocused;
        }

        UpdateButtonText();
    }

    private bool IsAtBottom()
    {
        // 认为可视区域已显示最后一行即为“在底部”
        if (gridView1.DataRowCount == 0) return true;
        var lastIndex = gridView1.DataRowCount - 1;
        var visible = gridView1.IsRowVisible(lastIndex);
        return visible == RowVisibleState.Visible;
    }

    // 首次绑定后生成并规范列
    private void EnsureColumns()
    {
        if (_columnsInitialized) return;

        // 基于数据源生成列
        gridView1.PopulateColumns();

        // 固定列：设置固定宽度
        ConfigureCol("Time", visibleIndex: 0, width: 200, fmt: "HH:mm:ss.fff", fmtType: FormatType.DateTime,
            center: true, fixedWidth: true);
        ConfigureCol("Level", visibleIndex: 1, width: 100, center: true, fixedWidth: true);
        ConfigureCol("Source", visibleIndex: 2, width: 300, center: false, fixedWidth: true);

        // “消息”列：使用 MemoEdit，自动换行，行高自适应
        ConfigureCol("Message", visibleIndex: 3, width: 200, center: false, fixedWidth: false);
        var msgCol = gridView1.Columns["Message"];
        if (msgCol != null)
        {
            var memo = new RepositoryItemMemoEdit
            {
                ReadOnly = true,
                WordWrap = true,
                ScrollBars = ScrollBars.Vertical // 编辑态可滚动；显示态依赖 RowAutoHeight 展示完整
            };
            gridControl1.RepositoryItems.Add(memo);
            msgCol.ColumnEdit = memo;
            msgCol.AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;
        }

        _columnsInitialized = true;
    }

    private void ConfigureCol(string fieldName , int visibleIndex, int width, string? fmt = null, FormatType fmtType = FormatType.None, bool center = false, bool fixedWidth = false)
    {
        var col = gridView1.Columns[fieldName];
        if (col == null) return;

        col.VisibleIndex = visibleIndex;
        col.Width = width;
        col.AppearanceHeader.BackColor = Color.Black;

        // 固定列：锁定宽度，消息列不设 MaxWidth，便于后续拉伸
        col.OptionsColumn.FixedWidth = fixedWidth;
        if (fixedWidth)
        {
            col.MinWidth = width;
            col.MaxWidth = width;
        }
        else
        {
            col.MinWidth = width; // 作为下限，避免过小
            col.MaxWidth = int.MaxValue; // 允许拉伸
        }

        if (!string.IsNullOrEmpty(fmt))
        {
            col.DisplayFormat.FormatType = fmtType;
            col.DisplayFormat.FormatString = fmt;
        }

        if (center)
        {
            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
        }
    }

    // 让“消息”列填充剩余宽度
    private void AdjustMessageColumnWidth()
    {
        var msgCol = gridView1.Columns["Message"];
        if (msgCol == null || !msgCol.Visible) return;

        // 计算可用区域宽度（可视数据区域）
        int totalWidth = gridView1.ViewRect.Width;

        // 累加固定列宽度
        int fixedWidthSum = 0;
        foreach (var name in new[] { "Time", "Level", "Source" })
        {
            var c = gridView1.Columns[name];
            if (c != null && c.Visible)
                fixedWidthSum += c.Width;
        }

        // 剩余给消息列
        int remaining = totalWidth - fixedWidthSum;
        if (remaining < msgCol.MinWidth) remaining = msgCol.MinWidth;

        // 只在需要时设置，避免多余刷新
        if (msgCol.Width != remaining)
            msgCol.Width = remaining;
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

    private void OnLogAppended(LogEntry entry)
    {
        if (InvokeRequired)
        {
            BeginInvoke((MethodInvoker)(() => OnLogAppended(entry)));
            return;
        }
        // 仅当不过滤或符合当前过滤条件时才追加
        if (currentFilter == null || entry.Level == currentFilter)
        {
            bool atBottom = IsAtBottom();
            _binding.Add(entry);
            gridControl1.RefreshDataSource();
            if (atBottom)
            {
                var last = gridView1.DataRowCount - 1;
                if (last >= 0)
                {
                    gridView1.FocusedRowHandle = last;
                    gridView1.MakeRowVisible(last);
                }
            }
            UpdateButtonText();
        }
        else
        {
            // 过滤中也要更新按钮计数
            UpdateButtonText();
        }
    }
}
