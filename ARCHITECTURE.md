# UniVision Architecture Overview

> 本文档概述当前框架的核心组成与扩展点，帮助快速理解并安全扩展（新增工具 / 全局变量 / 运行逻辑）。

## 1. 解决方案 (Solution)
- 数据模型序列化为单个 `.uv` (XML)：包含流程 (ProcessItem / ProcessFolder)、工具引用 (ToolRef) 以及全局变量列表。
- `ToolRef` 保存：唯一 Id、名称、类型键(TypeKey)、反射类型(AssemblyQualifiedType)、启用标记、配置 JSON/字符串。
- 事件：
  - `ToolAdded(string processPath, ToolRef)`
  - `ToolRemoved(string processPath, ToolRef)`
  - `ToolRenamed(string processPath, ToolRef, string oldName)`
  用于驱动变量注册与界面刷新，避免 UI 手动维护状态。

## 2. 工具系统 (Tool)
- 插件需实现 `ITool`；可选 `IPersistableTool` 参与配置导入导出。
- 推荐继承 `ToolBase`：封装运行模板（计时、异常捕获、状态记录）并减少样板代码。
- 新增元数据特性 `[Tool(name, category, ...)]` 由 `ToolFactory` 扫描注册。
- 运行期实例缓存由 `SolutionManager` 维护：`toolRef.Id -> ITool`，避免重复创建。

### 变量链接 (LinkRegistry)
- 通过属性标记 `[LinkableVar]` 自动注册。
- 注册键结构：`ProcessId.ToolId.PropertyName`。
- 流程 / 工具删除或重命名通过事件驱动增量更新。
- 全局变量以 `_Global` 作为虚拟流程；其注释 (Annotation) 优先作为显示名。

## 3. 执行引擎 (ProcessExecutionService)
- 支持：
  - 单次运行全部 / 指定流程
  - 循环运行全部 / 指定流程
- 并发：流程级可并行（不同流程），流程内部默认顺序执行工具。
- 事件：`RunStateChanged`, `ProcessStarted`, `ToolStarted`, `ToolFinished`, `ProcessFinished` 供 UI 订阅。
- 可扩展策略：执行模式 (顺序/并行)、失败策略 (继续 / 终止流程 / 全局停止 / 重试)。

## 4. 全局变量
- 保存在 `Solution.Data.GlobalVariables`。
- 添加时自动生成唯一名称（Value0+N）。
- 通过包装工具 `GlobalVariableTool` 暴露一个 `[LinkableVar("值")]` 属性。
- 注释(Annotation) 可在 UI 中编辑，作为变量显示名优先级 (Annotation > LinkableVar.DisplayName > 属性名)。

## 5. 新增一个工具的最少步骤
1. 新建类，继承 `ToolBase`（或直接实现 `ITool`）。
2. 添加 `[Tool("显示名","分类", Description="..." )]`。
3. 使用 `[LinkableVar]` 标记需要输出的属性。
4. 实现 `protected override bool OnRun(out string message)`。
5. 如需配置：实现 `IPersistableTool` + JSON 序列化（推荐使用 ToolBase 提供的通用方法 / 自定义设置对象）。
6. 编译后即会被 `ToolFactory` 发现并出现在工具面板。

## 6. 配置持久化
- 迁移目标：统一使用 JSON（替换早期 XML / BinaryFormatter）。
- 旧字段仍兼容，避免一次性破坏存量配置。
- 示例：`SaveImage` / `LocalImage` 使用自定义 *Settings DTO + JSON* 方式序列化。

## 7. 代码层职责划分
| 模块 | 作用 | 说明 |
|------|------|------|
| Solution / SolutionManager | 持久化 + 运行期实例缓存 + 事件分发 | 不含 UI 逻辑 |
| ProcessExecutionService | 流程调度 / 循环控制 / 运行事件 | 纯业务服务 |
| LinkRegistry | 变量发现、查询、类型兼容 | UI 查询只读使用 |
| ToolFactory | 反射扫描 + 元数据缓存 + 实例化 | 降低新增插件成本 |
| ToolBase | 运行模板 | 统一异常与耗时统计 |
| 全局变量模块 | 变量声明与包装 | 注释优先显示 |

## 8. 后续可拓展点
- 依赖图执行 (DAG) / 条件分支 / 并行工具节点
- 运行历史 / 性能分析缓冲区
- UI 中变量搜索与类型筛选
- 自定义转换器链式注册

---
如需补充或深入某部分（例如执行策略扩展或变量查询优化），可继续提出具体需求。
