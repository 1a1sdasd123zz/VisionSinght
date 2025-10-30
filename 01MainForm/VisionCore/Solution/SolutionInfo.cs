using System;
using System.ComponentModel;

namespace VisionCore.Solution
{
    public class SolutionInfo
    {
        [DisplayName("方案名称")]
        public string Name { get; set; }
        [DisplayName("描述")]
        public string Description { get; set; }
        /// <summary>
        /// 是否默认启动，每个方案只能有一个默认启动
        /// </summary>
        [DisplayName("默认启动")]
        public bool Enable { get; set; }
        [DisplayName("创建时间")]
        public DateTime CreateTime { get; set; }
        [DisplayName("最后修改时间")]
        public DateTime LastModifyTime { get; set; }
        [DisplayName("文件路径")]
        public string Path { get; set; }

    }
}
