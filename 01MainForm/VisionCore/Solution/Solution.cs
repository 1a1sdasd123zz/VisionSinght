using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace VisionCore.Solution
{
    [XmlInclude(typeof(ProcessFolder))]
    [XmlInclude(typeof(ProcessItem))]
    public abstract class ProcessNode
    {
        [XmlAttribute]
        public string Name { get; set; }
    }

    public class ProcessFolder : ProcessNode
    {
        [XmlElement("Folder", typeof(ProcessFolder))]
        [XmlElement("Process", typeof(ProcessItem))]
        public List<ProcessNode> Children { get; set; } = new List<ProcessNode>();
    }

    /// <summary>
    /// 流程类：包含多个工具。工具以 ToolRef 形式保存（类型键 + JSON 配置），便于插件化与版本化。
    /// </summary>
    public class ProcessItem : ProcessNode
    {
        [XmlAttribute]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        [XmlAttribute]
        public bool Enabled { get; set; } = true; // 新增：流程启用状态

        [XmlArray("Tools")]
        [XmlArrayItem("Tool")]
        public List<ToolRef> Tools { get; set; } = new List<ToolRef>();
    }

    /// <summary>
    /// 工具引用信息（用于序列化）。
    /// TypeKey: 业务内注册的工具键（如 "CameraCapture2D"）
    /// AssemblyQualifiedType: 可选，反射创建使用。
    /// SettingsJson: 工具配置的 JSON 字符串（由具体工具提供导出/导入）。
    /// </summary>
    public class ToolRef
    {
        [XmlAttribute]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string TypeKey { get; set; }

        [XmlAttribute]
        public string AssemblyQualifiedType { get; set; }

        [XmlElement]
        public string SettingsJson { get; set; }

        [XmlAttribute]
        public bool Enabled { get; set; } = true;
    }

    [XmlRoot("SolutionData")]
    public class SolutionData
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Version { get; set; } = "1.0";

        [XmlElement("Folder", typeof(ProcessFolder))]
        [XmlElement("Process", typeof(ProcessItem))]
        public List<ProcessNode> Root { get; set; } = new List<ProcessNode>();

        [XmlArray("GlobalVariables")]
        [XmlArrayItem("Var")]
        public List<GlobalVariable> GlobalVariables { get; set; } = new List<GlobalVariable>();
    }

    public class GlobalVariable
    {
        [XmlAttribute] public string Name { get; set; }
        [XmlAttribute] public string Type { get; set; } // System type full name
        [XmlElement] public string Value { get; set; } // serialized string (null => empty)
        [XmlElement] public string Annotation { get; set; } // new: user comment
    }

    /// <summary>
    /// 表示一个具体的解决方案。提供流程与工具的增删改查及序列化能力。
    /// </summary>
    public class Solution
    {
        // 新增: 工具事件 (processPath, toolRef, oldName)
        public event Action<string, ToolRef> ToolAdded;
        public event Action<string, ToolRef> ToolRemoved;
        public event Action<string, ToolRef, string> ToolRenamed;

        public SolutionData Data { get; set; }

        public Solution(string name)
        {
            Data = new SolutionData { Name = name };
        }

        private Solution(SolutionData data)
        {
            Data = data ?? new SolutionData();
        }

        // path 规则：
        // - 根级流程："流程0"
        // - 文件夹下流程："文件夹0/流程0"
        public void AddProcess(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return;
            var parts = SplitPath(path);
            if (parts.Length == 1)
            {
                if (!Data.Root.OfType<ProcessItem>().Any(p => p.Name.Equals(parts[0], StringComparison.OrdinalIgnoreCase)))
                    Data.Root.Add(new ProcessItem { Name = parts[0] });
                return;
            }

            var folder = EnsureFolder(string.Join("/", parts.Take(parts.Length - 1)));
            if (!folder.Children.OfType<ProcessItem>().Any(p => p.Name.Equals(parts.Last(), StringComparison.OrdinalIgnoreCase)))
                folder.Children.Add(new ProcessItem { Name = parts.Last() });
        }

        /// <summary>
        /// 新增：按给定 ProcessItem（含工具/ID）插入。调用方需保证名称在路径下唯一。
        /// </summary>
        public bool AddProcessItem(string path, ProcessItem item)
        {
            if (string.IsNullOrWhiteSpace(path) || item == null) return false;
            var parts = SplitPath(path);
            if (parts.Length == 1)
            {
                if (Data.Root.OfType<ProcessItem>().Any(p => p.Name.Equals(parts[0], StringComparison.OrdinalIgnoreCase))) return false;
                item.Name = parts[0];
                Data.Root.Add(item); return true;
            }
            var folder = EnsureFolder(string.Join("/", parts.Take(parts.Length - 1)));
            if (folder.Children.OfType<ProcessItem>().Any(p => p.Name.Equals(parts.Last(), StringComparison.OrdinalIgnoreCase))) return false;
            item.Name = parts.Last();
            folder.Children.Add(item); return true;
        }

        public bool RemoveProcess(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return false;
            var parts = SplitPath(path);
            if (parts.Length == 1)
            {
                var proc = Data.Root.OfType<ProcessItem>().FirstOrDefault(p => p.Name.Equals(parts[0], StringComparison.OrdinalIgnoreCase));
                if (proc != null)
                {
                    Data.Root.Remove(proc);
                    return true;
                }
                return false;
            }

            var parentFolder = FindFolder(string.Join("/", parts.Take(parts.Length - 1)));
            if (parentFolder == null) return false;
            var item = parentFolder.Children.OfType<ProcessItem>().FirstOrDefault(p => p.Name.Equals(parts.Last(), StringComparison.OrdinalIgnoreCase));
            if (item == null) return false;
            parentFolder.Children.Remove(item);
            return true;
        }

        public bool RenameProcess(string oldPath, string newName)
        {
            if (string.IsNullOrWhiteSpace(oldPath) || string.IsNullOrWhiteSpace(newName)) return false;
            var parts = SplitPath(oldPath);
            if (parts.Length == 1)
            {
                var proc = Data.Root.OfType<ProcessItem>().FirstOrDefault(p => p.Name.Equals(parts[0], StringComparison.OrdinalIgnoreCase));
                if (proc == null) return false;
                proc.Name = newName;
                return true;
            }

            var parentFolder = FindFolder(string.Join("/", parts.Take(parts.Length - 1)));
            if (parentFolder == null) return false;
            var item = parentFolder.Children.OfType<ProcessItem>().FirstOrDefault(p => p.Name.Equals(parts.Last(), StringComparison.OrdinalIgnoreCase));
            if (item == null) return false;
            item.Name = newName;
            return true;
        }

        // 工具操作（基于流程路径）
        public ProcessItem GetProcess(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return null;
            var parts = SplitPath(path);
            if (parts.Length == 1)
            {
                return Data.Root.OfType<ProcessItem>().FirstOrDefault(p => p.Name.Equals(parts[0], StringComparison.OrdinalIgnoreCase));
            }
            var parentFolder = FindFolder(string.Join("/", parts.Take(parts.Length - 1)));
            return parentFolder?.Children.OfType<ProcessItem>().FirstOrDefault(p => p.Name.Equals(parts.Last(), StringComparison.OrdinalIgnoreCase));
        }

        public bool AddTool(string processPath, ToolRef tool)
        {
            var proc = GetProcess(processPath);
            if (proc == null || tool == null) return false;
            if (proc.Tools.Any(t => t.Id == tool.Id)) return false;
            proc.Tools.Add(tool);
            try { ToolAdded?.Invoke(processPath, tool); } catch { }
            return true;
        }

        public bool RemoveTool(string processPath, string toolId)
        {
            var proc = GetProcess(processPath);
            if (proc == null || string.IsNullOrWhiteSpace(toolId)) return false;
            var t = proc.Tools.FirstOrDefault(x => x.Id == toolId);
            if (t == null) return false;
            proc.Tools.Remove(t);
            try { ToolRemoved?.Invoke(processPath, t); } catch { }
            return true;
        }

        public bool RenameTool(string processPath, string toolId, string newName)
        {
            if (string.IsNullOrWhiteSpace(newName)) return false;
            var proc = GetProcess(processPath);
            if (proc == null) return false;
            var tr = proc.Tools.FirstOrDefault(x => x.Id == toolId);
            if (tr == null) return false;
            if (proc.Tools.Any(x => !ReferenceEquals(x, tr) && string.Equals(x.Name, newName, StringComparison.OrdinalIgnoreCase))) return false;
            var old = tr.Name;
            tr.Name = newName;
            try { ToolRenamed?.Invoke(processPath, tr, old); } catch { }
            return true;
        }

        public bool UpdateToolSettings(string processPath, string toolId, string settingsJson)
        {
            var proc = GetProcess(processPath);
            var t = proc?.Tools.FirstOrDefault(x => x.Id == toolId);
            if (t == null) return false;
            t.SettingsJson = settingsJson;
            return true;
        }

        public void Save(string filePath)
        {
            var serializer = new XmlSerializer(typeof(SolutionData));
            using var fs = File.Create(filePath);
            serializer.Serialize(fs, Data);
        }

        public static Solution Load(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);
            var serializer = new XmlSerializer(typeof(SolutionData));
            using var fs = File.OpenRead(filePath);
            var data = (SolutionData)serializer.Deserialize(fs);
            return new Solution(data);
        }

        private static string[] SplitPath(string path)
        {
            return path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private ProcessFolder EnsureFolder(string folderPath)
        {
            // 支持多级："A/B/C"，逐级创建
            ProcessFolder current = null;
            var parts = SplitPath(folderPath);
            var level = 0;
            while (level < parts.Length)
            {
                var name = parts[level];
                if (current == null)
                {
                    var f = Data.Root.OfType<ProcessFolder>().FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                    if (f == null)
                    {
                        f = new ProcessFolder { Name = name };
                        Data.Root.Add(f);
                    }
                    current = f;
                }
                else
                {
                    var f = current.Children.OfType<ProcessFolder>().FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                    if (f == null)
                    {
                        f = new ProcessFolder { Name = name };
                        current.Children.Add(f);
                    }
                    current = f;
                }
                level++;
            }
            return current;
        }

        private ProcessFolder FindFolder(string folderPath)
        {
            ProcessFolder current = null;
            var parts = SplitPath(folderPath);
            var level = 0;
            while (level < parts.Length)
            {
                var name = parts[level];
                if (current == null)
                {
                    current = Data.Root.OfType<ProcessFolder>().FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    current = current.Children.OfType<ProcessFolder>().FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                }
                if (current == null) return null;
                level++;
            }
            return current;
        }
    }
}