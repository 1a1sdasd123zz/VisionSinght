using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VisionCore.ToolBase;

namespace VisionCore.Linking
{
    /// <summary>
    /// 全局变量索引：收集所有带 <see cref="LinkableVarAttribute"/> 的属性并供查询 / 绑定使用。
    /// 生命周期：方案加载时 Clear+RegisterTool 重建；工具增删时可局部更新（当前未实现）。
    /// </summary>
    public sealed class LinkRegistry
    {
        private readonly Dictionary<string, VariableDescriptor> _pathMap = new Dictionary<string, VariableDescriptor>();
        private readonly List<VariableDescriptor> _all = new List<VariableDescriptor>();
        private readonly List<ILinkValueConverter> _converters = new List<ILinkValueConverter>();

        public static LinkRegistry Instance { get; } = new LinkRegistry();
        private LinkRegistry()
        {
            // 注册内置转换器
            _converters.Add(BasicConverters.Identity);
            _converters.Add(BasicConverters.Number);
        }

        /// <summary>所有已注册变量的快照列表。</summary>
        public System.Collections.Generic.IReadOnlyList<VariableDescriptor> All { get { return _all; } }

        /// <summary>清空所有索引。</summary>
        public void Clear()
        {
            _pathMap.Clear();
            _all.Clear();
        }

        /// <summary>注册一个工具：反射其可链接属性并缓存。</summary>
        public void RegisterTool(string processName, string toolName, ITool tool, string displayOverride = null)
        {
            if (tool == null) return;
            var props = tool.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in props)
            {
                var attr = (LinkableVarAttribute)Attribute.GetCustomAttribute(p, typeof(LinkableVarAttribute));
                if (attr == null || !p.CanRead) continue;
                var vd = new VariableDescriptor
                {
                    ProcessId = processName,
                    ToolId = toolName,
                    Name = p.Name,
                    DisplayName = !string.IsNullOrWhiteSpace(displayOverride) ? displayOverride : (string.IsNullOrWhiteSpace(attr.DisplayName) ? p.Name : attr.DisplayName),
                    DataType = p.PropertyType,
                    ExtraTypes = attr.AsTypes ?? new Type[0],
                    Category = attr.Category,
                    Description = attr.Description,
                    Getter = delegate { return p.GetValue(tool, null); }
                };
                _all.Add(vd);
                _pathMap[vd.FullPath] = vd;
            }
        }

        /// <summary>按路径解析变量。</summary>
        public VariableDescriptor Resolve(string path)
        {
            VariableDescriptor v;
            return path != null && _pathMap.TryGetValue(path, out v) ? v : null;
        }

        /// <summary>返回所有能赋值到目标类型的变量集合。</summary>
        public IEnumerable<VariableDescriptor> QueryAssignableTo(Type targetType)
        {
            foreach (var v in _all)
            {
                if (targetType.IsAssignableFrom(v.DataType)) { yield return v; continue; }
                if (System.Linq.Enumerable.Any(v.ExtraTypes, t => targetType.IsAssignableFrom(t))) { yield return v; continue; }
                if (_converters.Exists(c => c.CanConvert(v.DataType, targetType))) yield return v;
            }
        }

        /// <summary>获取变量值并在必要时做类型转换。</summary>
        public object GetValueConverted(VariableDescriptor vd, Type targetType)
        {
            if (vd == null) return null;
            var val = vd.Getter != null ? vd.Getter() : null;
            if (val == null) return null;
            if (targetType.IsAssignableFrom(vd.DataType)) return val;
            var conv = _converters.Find(c => c.CanConvert(vd.DataType, targetType));
            if (conv != null) return conv.Convert(val, targetType);
            return val; // 兜底返回原值
        }

        /// <summary>流程重命名后更新注册变量的路径 (仅基于流程名，无层级区分，与现有 RegisterTool 保持一致)</summary>
        public void RenameProcess(string oldName, string newName)
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName) || oldName == newName) return;
            var affected = _all.Where(v => v.ProcessId == oldName).ToList();
            if (affected.Count == 0) return;
            // 先移除旧路径
            foreach (var vd in affected)
                _pathMap.Remove(vd.FullPath);
            // 更新并重新注册
            foreach (var vd in affected)
            {
                vd.ProcessId = newName;
                _pathMap[vd.FullPath] = vd;
            }
        }

        /// <summary>删除流程时移除其变量</summary>
        public void RemoveProcess(string processName)
        {
            if (string.IsNullOrWhiteSpace(processName)) return;
            var removed = _all.Where(v => v.ProcessId == processName).ToList();
            if (removed.Count == 0) return;
            // 移除路径
            foreach (var vd in removed) _pathMap.Remove(vd.FullPath);
            // 从所有变量中删除
            _all.RemoveAll(v => v.ProcessId == processName);
        }

        /// <summary>删除单个工具时移除其变量</summary>
        public void RemoveTool(string processName, string toolName)
        {
            if (string.IsNullOrWhiteSpace(processName) || string.IsNullOrWhiteSpace(toolName)) return;
            var removed = _all.Where(v => v.ProcessId == processName && v.ToolId == toolName).ToList();
            if (removed.Count == 0) return;
            // 移除路径
            foreach (var vd in removed) _pathMap.Remove(vd.FullPath);
            // 从所有变量中删除
            _all.RemoveAll(v => v.ProcessId == processName && v.ToolId == toolName);
        }
    }
}
