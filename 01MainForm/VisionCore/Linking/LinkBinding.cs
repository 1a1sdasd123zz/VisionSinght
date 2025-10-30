using System;

namespace VisionCore.Linking
{
    /// <summary>
    /// 目标工具属性到源变量的链接关系。
    /// 持久化后用于恢复运行期绑定。
    /// </summary>
    [Serializable]
    public class LinkBinding
    {
        /// <summary>目标工具的属性名称。</summary>
        public string TargetProperty { get; set; }
        /// <summary>源变量路径: 流程.工具.变量。</summary>
        public string SourcePath { get; set; }
        /// <summary>可选转换器 Id（目前未用，预留扩展）。</summary>
        public string ConverterId { get; set; }
    }
}
