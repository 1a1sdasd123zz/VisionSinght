using System;

namespace VisionCore.PluginBase
{
    [Serializable]
    public sealed class ToolDragData
    {
        public string DisplayName { get; set; }
        public string AssemblyQualifiedType { get; set; }
    }
}
