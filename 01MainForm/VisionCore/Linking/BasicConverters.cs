using System;
using System.Drawing;

namespace VisionCore.Linking
{
    /// <summary>
    /// 内置常用转换器注册与简单实现集合。
    /// </summary>
    public static class BasicConverters
    {
        /// <summary>恒等转换：原类型与目标类型相同或目标可接收源（派生->基类）。</summary>
        public static readonly ILinkValueConverter Identity = new SimpleConverter("identity", delegate(Type s, Type d) { return s == d || d.IsAssignableFrom(s); }, delegate(object v, Type d) { return v; });
        /// <summary>数值互转：所有基础数值类型间使用 System.Convert。</summary>
        public static readonly ILinkValueConverter Number = new SimpleConverter("number", delegate(Type s, Type d) { return IsNumber(s) && IsNumber(d); }, delegate(object v, Type d) { return v == null ? null : System.Convert.ChangeType(v, d); });

        private static bool IsNumber(Type t)
        {
            return t == typeof(byte) || t == typeof(sbyte) || t == typeof(short) || t == typeof(ushort) || t == typeof(int) || t == typeof(uint) || t == typeof(long) || t == typeof(ulong) || t == typeof(float) || t == typeof(double) || t == typeof(decimal);
        }

        /// <summary>
        /// 简单通用转换器实现。
        /// </summary>
        private sealed class SimpleConverter : ILinkValueConverter
        {
            private readonly Func<Type, Type, bool> _can;
            private readonly Func<object, Type, object> _do;
            public string Id { get; private set; }
            public SimpleConverter(string id, Func<Type, Type, bool> can, Func<object, Type, object> d) { Id = id; _can = can; _do = d; }
            public bool CanConvert(Type src, Type dst) { return _can(src, dst); }
            public object Convert(object value, Type dst) { return _do(value, dst); }
        }
    }
}
