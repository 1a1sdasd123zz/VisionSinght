using System;

namespace VisionCore.Linking
{
    /// <summary>
    /// 变量链接类型转换器接口。
    /// 一个链接的源变量类型与目标属性类型不完全一致时，<see cref="LinkRegistry"/> 会在所有注册的转换器中调用
    /// <see cref="CanConvert(Type, Type)"/> 询问是否支持转换，若返回 true 则使用 <see cref="Convert(object, Type)"/> 得到最终值。
    /// </summary>
    public interface ILinkValueConverter
    {
        /// <summary>
        /// 转换器的唯一标识（可用于配置序列化/调试）。
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 判断是否可以把 <paramref name="src"/> 类型的值转换为 <paramref name="dst"/> 类型。
        /// 仅做能力判断，不执行真实转换，要求无副作用、快速返回。
        /// 例如数值互转、Bitmap -> Image、派生类 -> 基类等。
        /// </summary>
        /// <param name="src">源类型（变量实际类型）。</param>
        /// <param name="dst">目标类型（目标属性所需类型）。</param>
        /// <returns>true 表示该转换器愿意 / 能够完成这个转换。</returns>
        bool CanConvert(Type src, Type dst);

        /// <summary>
        /// 执行真实转换，把 <paramref name="value"/> 转为 <paramref name="dst"/> 类型的实例并返回。
        /// 若无法转换应抛出异常或直接返回原值（实现自行约定）。
        /// </summary>
        /// <param name="value">源值。</param>
        /// <param name="dst">目标类型。</param>
        /// <returns>转换后的值。</returns>
        object Convert(object value, Type dst);
    }
}
