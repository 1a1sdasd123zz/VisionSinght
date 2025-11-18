using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Cognex.VisionPro.ToolBlock;

namespace UserControlNet;

public partial class uOutputData : System.Windows.Forms.UserControl
{
  // 数据模型：输出变量定义
  public class OutputVarDef
  {
    public string TypeName { get; set; } // 类型名称
    public string Name { get; set; } // 变量名
    public string Value { get; set; } // 当前值（从ToolBlock输出读取）
    public string Comment { get; set; } // 注释
  }

  // 绑定列表
  private BindingList<OutputVarDef> _vars;

  // ToolBlock引用
  private CogToolBlock _toolBlock;

  // 编辑前的原始值（用于回滚）
  private string _originalNameEditing;
  private string _originalValueEditing;

  // C#关键字集合
  private static readonly HashSet<string> CsKeywords = new HashSet<string>(new[]
  {
    "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
    "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else",
    "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for",
    "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is",
    "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override",
    "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte",
    "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch",
    "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe",
    "ushort", "using", "virtual", "void", "volatile", "while"
  }, StringComparer.Ordinal);

  public uOutputData()
  {
    InitializeComponent();
    InitDgv();
    InitButtons();
  }

  /// <summary>
  /// 加载ToolBlock和变量列表
  /// </summary>
  public void LoadData(CogToolBlock toolBlock, List<OutputVarDef> vars)
  {
    _toolBlock = toolBlock;
    _vars = new BindingList<OutputVarDef>(vars ?? new List<OutputVarDef>());
    dgv_Data.DataSource = _vars;
    AdjustCommentFill();
  }

  /// <summary>
  /// 获取当前变量列表
  /// </summary>
  public List<OutputVarDef> GetVariables()
  {
    return _vars?.ToList() ?? new List<OutputVarDef>();
  }

  /// <summary>
  /// 运行后更新输出值（从ToolBlock.Outputs读取）
  /// </summary>
  public void UpdateOutputValues()
  {
    if (_toolBlock == null || _vars == null) return;

    foreach (var v in _vars)
    {
      try
      {
        // 从ToolBlock输出端子读取值
        var term = FindOutputTerminal(v.Name);
        if (term != null)
        {
          var val = term.Value;
          v.Value = ValueToString(val, NameToType(v.TypeName));
        }
        else
        {
          v.Value = "<未找到>";
        }
      }
      catch (Exception ex)
      {
        v.Value = $"<错误:{ex.Message}>";
      }
    }

    // 刷新DataGridView显示
    dgv_Data.Refresh();
  }

  /// <summary>
  /// 初始化DataGridView
  /// </summary>
  private void InitDgv()
  {
    dgv_Data.AutoGenerateColumns = false;
    dgv_Data.Columns.Clear();
    dgv_Data.AllowUserToAddRows = false;
    dgv_Data.AllowUserToDeleteRows = false;
    dgv_Data.MultiSelect = false;
    dgv_Data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    dgv_Data.RowHeadersVisible = false;

    // 类型列（只读）
    dgv_Data.Columns.Add(new DataGridViewTextBoxColumn
    {
      DataPropertyName = nameof(OutputVarDef.TypeName),
      Name = "类型",
      HeaderText = "类型",
      ReadOnly = true,
      Width = 80
    });

    // 名称列（可编辑）
    dgv_Data.Columns.Add(new DataGridViewTextBoxColumn
    {
      DataPropertyName = nameof(OutputVarDef.Name),
      Name = "名称",
      HeaderText = "名称",
      ReadOnly = false,
      Width = 120
    });

    // 值列（只读，运行后自动更新）
    dgv_Data.Columns.Add(new DataGridViewTextBoxColumn
    {
      DataPropertyName = nameof(OutputVarDef.Value),
      Name = "值",
      HeaderText = "值",
      ReadOnly = true,
      Width = 150
    });

// 注释列（自适应填充）
    var colComment = new DataGridViewTextBoxColumn
    {
      DataPropertyName = nameof(OutputVarDef.Comment),
      Name = "注释",
      HeaderText = "注释",
      ReadOnly = false,
      MinimumWidth = 100,
      Width = 150
    };
    dgv_Data.Columns.Add(colComment);

    // 列宽变化时自适应注释列
    dgv_Data.SizeChanged += (_, _) => AdjustCommentFill();
    dgv_Data.ColumnWidthChanged += (_, e) =>
    {
      if (e.Column.Name != "注释") AdjustCommentFill();
    };

    // 编辑开始：记录原值
    dgv_Data.CellBeginEdit += (_, e) =>
    {
      if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
      var col = dgv_Data.Columns[e.ColumnIndex];
      switch (col.DataPropertyName)
      {
        case nameof(OutputVarDef.Name):
          _originalNameEditing = dgv_Data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
          break;
      }
    };

    // 编辑结束：校验
    dgv_Data.CellEndEdit += Dgv_Data_CellEndEdit;
  }

  /// <summary>
  /// 单元格编辑结束事件
  /// </summary>
  private void Dgv_Data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
  {
    if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
    var col = dgv_Data.Columns[e.ColumnIndex];
    if (dgv_Data.Rows[e.RowIndex].DataBoundItem is not OutputVarDef r) return;

    if (col.DataPropertyName == nameof(OutputVarDef.Name))
    {
      var newName = (r.Name ?? string.Empty).Trim();
      if (string.Equals(newName, _originalNameEditing, StringComparison.OrdinalIgnoreCase))
      {
        r.Name = _originalNameEditing;
        return;
      }

      if (!IsNameValid(newName, e.RowIndex, out var reason))
      {
        MessageBox.Show(reason, "名称无效", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        r.Name = _originalNameEditing;
        dgv_Data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _originalNameEditing;
        return;
      }

      if (MessageBox.Show($"确认将名称修改为：{newName}?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
          DialogResult.Yes)
      {
        r.Name = newName;
        dgv_Data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = newName;

        // 同步修改ToolBlock输出端子名称
        if (_toolBlock != null && !string.IsNullOrWhiteSpace(_originalNameEditing))
        {
          var term = FindOutputTerminal(_originalNameEditing);
          if (term != null)
          {
            term.Name = newName;
          }
        }
      }
      else
      {
        r.Name = _originalNameEditing;
        dgv_Data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _originalNameEditing;
      }
    }
  }

  /// <summary>
  /// 名称合法性校验
  /// </summary>
  private bool IsNameValid(string name, int currentIndex, out string reason)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      reason = "名称不能为空";
      return false;
    }

    // C#标识符规范
    if (!Regex.IsMatch(name, @"^[A-Za-z_][A-Za-z0-9_]*$"))
    {
      reason = "名称不合法：必须以字母或下划线开头，且只能包含字母、数字或下划线";
      return false;
    }

    // 关键字禁止
    if (CsKeywords.Contains(name))
    {
      reason = "名称不合法：不能使用C#关键字";
      return false;
    }

    // 界面数据源内唯一
    if (_vars.Where((_, idx) => idx != currentIndex)
        .Any(v => string.Equals(v.Name, name, StringComparison.OrdinalIgnoreCase)))
    {
      reason = "名称已存在";
      return false;
    }

    // 与ToolBlock输出端子冲突则不合法
    if (_toolBlock != null)
    {
      for (var i = 0; i < _toolBlock.Outputs.Count; i++)
      {
        if (string.Equals(_toolBlock.Outputs[i].Name, name, StringComparison.OrdinalIgnoreCase))
        {
// 如果是当前行的原名称，则不算冲突
          if (currentIndex >= 0 && currentIndex < _vars.Count &&
              string.Equals(_vars[currentIndex].Name, _toolBlock.Outputs[i].Name, StringComparison.OrdinalIgnoreCase))
            continue;

          reason = "名称与输出端子冲突";
          return false;
        }
      }
    }

    reason = null;
    return true;
  }

  /// <summary>
  /// 查找输出端子（忽略大小写）
  /// </summary>
  private CogToolBlockTerminal FindOutputTerminal(string name)
  {
    if (_toolBlock == null || string.IsNullOrWhiteSpace(name)) return null;
    for (var i = 0; i < _toolBlock.Outputs.Count; i++)
    {
      var t = _toolBlock.Outputs[i];
      if (string.Equals(t?.Name, name, StringComparison.OrdinalIgnoreCase)) return t;
    }

    return null;
  }

  /// <summary>
  /// 判断输出端子集合中是否存在该名称
  /// </summary>
  private bool ExistsInOutputs(string name)
  {
    if (_toolBlock == null) return false;
    for (var i = 0; i < _toolBlock.Outputs.Count; i++)
      if (string.Equals(_toolBlock.Outputs[i].Name, name, StringComparison.OrdinalIgnoreCase))
        return true;
    return false;
  }

  /// <summary>
  /// 初始化按钮事件
  /// </summary>
  private void InitButtons()
  {
    btn_Int.Click += (_, _) => AddVar(typeof(int));
    btn_Double.Click += (_, _) => AddVar(typeof(double));
    btn_Float.Click += (_, _) => AddVar(typeof(float));
    btn_String.Click += (_, _) => AddVar(typeof(string));
    btn_Bool.Click += (_, _) => AddVar(typeof(bool));
    btn_IntArray.Click += (_, _) => AddVar(typeof(int[]));
    btn_DoubleArray.Click += (_, _) => AddVar(typeof(double[]));
    btn_FloatArray.Click += (_, _) => AddVar(typeof(float[]));
    btn_StringArray.Click += (_, _) => AddVar(typeof(string[]));
    btn_BoolArray.Click += (_, _) => AddVar(typeof(bool[]));

    btn_MoveUp.Click += (_, _) => MoveUp();
    btn_MoveDown.Click += (_, _) => MoveDown();
    btn_Remove.Click += (_, _) => RemoveCurrent();
  }

  /// <summary>
  /// 添加变量
  /// </summary>
  private void AddVar(Type t)
  {
    if (_toolBlock == null)
    {
      MessageBox.Show("尚未加载工具块，无法添加变量", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
      return;
    }

    var baseName = "Value";
    var suffix = 0;
    string name;
    do
    {
      name = baseName + suffix++;
    } while (_vars.Any(v => string.Equals(v.Name, name, StringComparison.OrdinalIgnoreCase)) || ExistsInOutputs(name));

    var typeName = TypeToName(t);

    _vars.Add(new OutputVarDef
    {
      TypeName = typeName,
      Name = name,
      Value = string.Empty, // 输出初始为空
      Comment = string.Empty
    });

    // 同步新增输出端子
    _toolBlock.Outputs.Add(new CogToolBlockTerminal(name, t));
    AdjustCommentFill();
  }

  /// <summary>
  /// 上移
  /// </summary>
  private void MoveUp()
  {
    if (dgv_Data.CurrentRow == null) return;
    var idx = dgv_Data.CurrentRow.Index;
    if (idx <= 0) return;
    var item = _vars[idx];
    _vars.RemoveAt(idx);
    _vars.Insert(idx - 1, item);
    dgv_Data.CurrentCell = dgv_Data.Rows[idx - 1].Cells[0];
  }

  /// <summary>
  /// 下移
  /// </summary>
  private void MoveDown()
  {
    if (dgv_Data.CurrentRow == null) return;
    var idx = dgv_Data.CurrentRow.Index;
    if (idx >= _vars.Count - 1) return;
    var item = _vars[idx];
    _vars.RemoveAt(idx);
    _vars.Insert(idx + 1, item);
    dgv_Data.CurrentCell = dgv_Data.Rows[idx + 1].Cells[0];
  }

  /// <summary>
  /// 删除当前行
  /// </summary>
  private void RemoveCurrent()
  {
    if (dgv_Data.CurrentRow == null) return;
    if (MessageBox.Show("是否删除当前行?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
    var idx = dgv_Data.CurrentRow.Index;
    var name = _vars[idx].Name;
    _vars.RemoveAt(idx);

    // 同步移除ToolBlock的输出端子
    try
    {
      if (_toolBlock != null)
      {
        var term = FindOutputTerminal(name);
        if (term != null)
        {
          _toolBlock.Outputs.Remove(term);
        }
        else
        {
          _toolBlock.Outputs.Remove(name);
        }
      }
    }
    catch (Exception)
    {
      // ignored
    }
  }

  /// <summary>
  /// 自动调整注释列宽度
  /// </summary>
  private void AdjustCommentFill()
  {
    if (dgv_Data.Columns.Count == 0) return;
    var note = dgv_Data.Columns["注释"];
    if (note == null) return;
    var available = dgv_Data.ClientSize.Width - (dgv_Data.RowHeadersVisible ? dgv_Data.RowHeadersWidth : 0);
    var vs = dgv_Data.Controls.OfType<VScrollBar>().FirstOrDefault();
    if (vs is { Visible: true }) available -= vs.Width;
    var others = 0;
    foreach (DataGridViewColumn c in dgv_Data.Columns)
      if (c != note && c.Visible)
        others += c.Width;
    var target = Math.Max(100, available - others);
    if (target != note.Width)
      note.Width = target;
  }

  /// <summary>
  /// 类型转字符串
  /// </summary>
  private string TypeToName(Type t)
  {
    if (t == typeof(int)) return "int";
    if (t == typeof(double)) return "double";
    if (t == typeof(float)) return "float";
    if (t == typeof(string)) return "string";
    if (t == typeof(bool)) return "bool";
    if (t == typeof(int[])) return "int[]";
    if (t == typeof(double[])) return "double[]";
    if (t == typeof(float[])) return "float[]";
    if (t == typeof(string[])) return "string[]";
    if (t == typeof(bool[])) return "bool[]";
    return t?.Name ?? "object";
  }

  /// <summary>
  /// 字符串转类型
  /// </summary>
  private Type NameToType(string name)
  {
    return name switch
    {
      "int" => typeof(int),
      "double" => typeof(double),
      "float" => typeof(float),
      "string" => typeof(string),
      "bool" => typeof(bool),
      "int[]" => typeof(int[]),
      "double[]" => typeof(double[]),
      "float[]" => typeof(float[]),
      "string[]" => typeof(string[]),
      "bool[]" => typeof(bool[]),
      _ => typeof(object)
    };
  }

  /// <summary>
  /// 值转字符串（用于显示）
  /// </summary>
  private string ValueToString(object val, Type targetType)
  {
    if (val == null) return "<null>";

    try
    {
      // 数组类型特殊处理
      if (targetType.IsArray)
      {
        if (val is Array arr)
        {
          return $"[{arr.Length}个元素]";
        }
      }

      return val.ToString();
    }
    catch
    {
      return "<显示错误>";
    }
  }
}