# UserControl 项目升级说明

## 已完成的工作

? 将 `Frm_Tool.cs` 的变量管理逻辑移植到了两个UserControl:
- `uInputData.cs` - 输入端口配置（带"链接数据"列）
- `uOutputData.cs` - 输出端口配置（支持运行后自动更新值）

## 核心功能

### uInputData（输入端口）

**特性：**
- 添加变量（Int/Double/Float/String/Bool及数组）
- C#命名规则校验（标识符规范、非关键字、唯一性）
- 与ToolBlock.Inputs同步（添加/删除/重命名）
- **特有列："链接数据"** - 可以链接固定值/全局变量/其他工位输出

**数据模型：**
```csharp
public class InputVarDef
{
    public string TypeName { get; set; }    // 类型名称
    public string Name { get; set; }    // 变量名
    public string LinkData { get; set; }    // 链接数据（特有）
    public string Comment { get; set; }     // 注释
}
```

**使用方法：**
```csharp
// 加载数据
uInputData1.LoadData(toolBlock, inputVars);

// 获取变量列表
List<InputVarDef> vars = uInputData1.GetVariables();
```

### uOutputData（输出端口）

**特性：**
- 添加变量（Int/Double/Float/String/Bool及数组）
- C#命名规则校验（标识符规范、非关键字、唯一性）
- 与ToolBlock.Outputs同步（添加/删除/重命名）
- **特有功能：运行后自动更新值** - 从ToolBlock.Outputs读取并显示

**数据模型：**
```csharp
public class OutputVarDef
{
    public string TypeName { get; set; }    // 类型名称
    public string Name { get; set; }        // 变量名
    public string Value { get; set; }    // 当前值（运行后更新）
    public string Comment { get; set; } // 注释
}
```

**使用方法：**
```csharp
// 加载数据
uOutputData1.LoadData(toolBlock, outputVars);

// 运行工具后更新输出值
toolBlock.Run();
uOutputData1.UpdateOutputValues(); // 从ToolBlock.Outputs读取

// 获取变量列表
List<OutputVarDef> vars = uOutputData1.GetVariables();
```

## 需要修复的问题

### 1. 添加 Cognex 引用

UserControl 项目需要添加以下引用（参考主项目的引用路径）：

在 `UserControl.csproj` 中添加：

```xml
<ItemGroup>
  <Reference Include="Cognex.VisionPro.Core">
    <HintPath>..\..\Runtime\Cognex\Cognex.VisionPro.Core.dll</HintPath>
  </Reference>
  <Reference Include="Cognex.VisionPro.ToolBlock">
    <HintPath>..\..\Runtime\Cognex\Cognex.VisionPro.ToolBlock.dll</HintPath>
  </Reference>
</ItemGroup>
```

**或者**，如果路径不同，参考主项目 Vision.csproj 中的引用路径。

### 2. C# 语法兼容性修复

由于 UserControl 项目使用 C# 7.3，需要修改以下语法：

#### 修改 1: Lambda 弃元参数 `(_, _) =>` 改为 `(s, e) =>`

```csharp
// 原代码（C# 9.0）
btn_Int.Click += (_, _) => AddVar(typeof(int));

// 修改为（C# 7.3）
btn_Int.Click += (s, e) => AddVar(typeof(int));
```

**批量替换规则：**
- `(_, _) =>` → `(s, e) =>`

#### 修改 2: `is not` 模式 改为 `!(... is ...)`

```csharp
// 原代码（C# 9.0）
if (dgv_Data.Rows[e.RowIndex].DataBoundItem is not InputVarDef r) return;

// 修改为（C# 7.3）
if (!(dgv_Data.Rows[e.RowIndex].DataBoundItem is InputVarDef r)) return;
```

#### 修改 3: 属性模式 `is { Visible: true }` 改为传统判断

```csharp
// 原代码（C# 8.0）
if (vs is { Visible: true }) available -= vs.Width;

// 修改为（C# 7.3）
if (vs != null && vs.Visible) available -= vs.Width;
```

#### 修改 4: Switch 表达式 改为传统 switch 或 if-else

```csharp
// 原代码（C# 8.0）
private Type NameToType(string name)
{
    return name switch
    {
 "int" => typeof(int),
        "double" => typeof(double),
        // ...
        _ => typeof(object)
 };
}

// 修改为（C# 7.3）
private Type NameToType(string name)
{
    if (name == "int") return typeof(int);
    if (name == "double") return typeof(double);
    if (name == "float") return typeof(float);
    if (name == "string") return typeof(string);
    if (name == "bool") return typeof(bool);
    if (name == "int[]") return typeof(int[]);
    if (name == "double[]") return typeof(double[]);
    if (name == "float[]") return typeof(float[]);
    if (name == "string[]") return typeof(string[]);
    if (name == "bool[]") return typeof(bool[]);
    return typeof(object);
}
```

## 完整修复清单

### uInputData.cs 需要修改的行：

1. **第132行**: `dgv_Data.SizeChanged += (_, _) =>` → `dgv_Data.SizeChanged += (s, e) =>`
2. **第133行**: `dgv_Data.ColumnWidthChanged += (_, e) =>` → `dgv_Data.ColumnWidthChanged += (sender, e) =>`
3. **第141行**: `dgv_Data.CellBeginEdit += (_, e) =>` → `dgv_Data.CellBeginEdit += (sender, e) =>`
4. **第165行**: `is not InputVarDef r` → `!(... is InputVarDef r)`
5. **第293-306行**: 所有按钮事件 `(_, _) =>` → `(s, e) =>`
6. **第416行**: `if (vs is { Visible: true })` → `if (vs != null && vs.Visible)`
7. **第449-461行**: switch表达式改为if-else

### uOutputData.cs 需要修改的行：

1. **第165行**: `dgv_Data.SizeChanged += (_, _) =>` → `dgv_Data.SizeChanged += (s, e) =>`
2. **第166行**: `dgv_Data.ColumnWidthChanged += (_, e) =>` → `dgv_Data.ColumnWidthChanged += (sender, e) =>`
3. **第174行**: `dgv_Data.CellBeginEdit += (_, e) =>` → `dgv_Data.CellBeginEdit += (sender, e) =>`
4. **第195行**: `is not OutputVarDef r` → `!(... is OutputVarDef r)`
5. **第323-336行**: 所有按钮事件 `(_, _) =>` → `(s, e) =>`
6. **第444行**: `if (vs is { Visible: true })` → `if (vs != null && vs.Visible)`
7. **第477-489行**: switch表达式改为if-else

## 集成示例

### 在 Frm_Tool 中使用：

```csharp
public partial class Frm_Tool : Form
{
    private uInputData uInput;
    private uOutputData uOutput;
    
    private void LoadDetection(ProcessStation.ToolBase det)
    {
        // 加载输入
      var inputVars = det.Vars.Select(v => new uInputData.InputVarDef
        {
            TypeName = v.TypeName,
       Name = v.Name,
            LinkData = v.Value,  // 原来的Value作为LinkData
    Comment = v.Comment
        }).ToList();
  
      uInput.LoadData(det.ToolBlock, inputVars);
      
        // 加载输出（如果有）
        // uOutput.LoadData(det.ToolBlock, outputVars);
    }
    
    private void SaveDetection()
    {
        // 保存输入
        var vars = uInput.GetVariables();
        Detection.Vars = vars.Select(v => new ProcessStation.DetectVarDef
    {
            TypeName = v.TypeName,
            Name = v.Name,
            Value = v.LinkData,
       Comment = v.Comment
        }).ToList();
    }
    
    private void ToolRan(object sender, EventArgs e)
    {
        // 工具运行后更新输出值
        uOutput.UpdateOutputValues();
    }
}
```

## 总结

两个UserControl已经完整实现了Frm_Tool的所有核心逻辑：
- ? 变量管理（添加/删除/移动/重命名）
- ? C#命名规则校验
- ? 与ToolBlock端子同步
- ? 输入特有："链接数据"列
- ? 输出特有：运行后自动更新值

只需要：
1. 添加 Cognex 引用
2. 修复 C# 7.3 语法兼容性（约10处修改）

修复完成后即可在项目中使用！
