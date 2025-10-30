using System;
using System.Collections.Generic;

namespace HardwareCommunication.Abstractions
{
    /// <summary>
    /// 通讯能力标识位。
    /// - Message：字节消息的收发（TCP/UDP/串口等）
    /// - Registers：寄存器/线圈读写（如 Modbus/PLC）
    /// - Serial：串口类能力（预留）
    /// </summary>
    [Flags]
    public enum CommCapabilities
    {
        /// <summary>无能力</summary>
        None = 0,
        /// <summary>消息通道能力：发送字节、被动接收</summary>
        Message = 1,
        /// <summary>寄存器通道能力：读写不同数据类型</summary>
        Registers = 2,
        /// <summary>串口相关能力（预留）</summary>
        Serial = 4
    }

    /// <summary>
    /// 通用通讯参数。不同 Provider 通过扩展属性进行个性化配置。
    /// </summary>
    public interface ICommParameters
    {
        /// <summary>配置唯一键</summary>
        string Key { get; set; }
        /// <summary>Provider 名称（与 <see cref="CommProviderAttribute"/> Name 匹配）</summary>
        string Provider { get; set; }
        /// <summary>远端主机或本地绑定地址</summary>
        string Host { get; set; }
        /// <summary>端口号</summary>
        int Port { get; set; }
        /// <summary>站号（Modbus 等 PLC 使用）</summary>
        int Station { get; set; }
        /// <summary>连接超时（毫秒）</summary>
        int ConnectTimeoutMs { get; set; }
        /// <summary>发送超时（毫秒）</summary>
        int SendTimeoutMs { get; set; }
        /// <summary>接收超时（毫秒）</summary>
        int ReceiveTimeoutMs { get; set; }
        /// <summary>是否自动重连</summary>
        bool AutoReconnect { get; set; }
        /// <summary>重连间隔（毫秒）</summary>
        int ReconnectIntervalMs { get; set; }
        /// <summary>备注</summary>
        string Expain { get; set; }
    }

    /// <summary>
    /// 统一通讯通道接口：兼容消息收发与寄存器读写两大类能力。
    /// 不支持的成员应抛出 <see cref="NotSupportedException"/>，并通过 <see cref="Capabilities"/> 暴露支持范围。
    /// </summary>
    public interface ICommChannel
    {
        /// <summary>通道参数</summary>
        ICommParameters Parameters { get; }
        /// <summary>是否已连接</summary>
        bool IsConnected { get;}
        /// <summary>能力标识位</summary>
        CommCapabilities Capabilities { get; }

        /// <summary>连接状态变化事件：key, connected</summary>
        event Action<string, bool> ConnectionStateChanged;
        /// <summary>消息接收事件（Message 能力有效）：key, bytes</summary>
        event Action<string, byte[]> MessageReceived;

        /// <summary>打开通道，0 成功，负数失败</summary>
        int Open();
        /// <summary>关闭通道</summary>
        void Close();

        // Message
        /// <summary>发送字节消息（Message 能力）</summary>
        int Send(byte[] payload);

        // Registers
        /// <summary>写入布尔</summary>
        bool WriteBool(string address, bool value);
        /// <summary>读取布尔数组</summary>
        bool[] ReadBool(string address, ushort length);

        /// <summary>写入 Int16</summary>
        bool WriteInt16(string address, short value);
        /// <summary>读取 Int16 数组</summary>
        short[] ReadInt16(string address, ushort length);

        /// <summary>写入 UInt16</summary>
        bool WriteUInt16(string address, ushort value);
        /// <summary>读取 UInt16 数组</summary>
        ushort[] ReadUInt16(string address, ushort length);

        /// <summary>写入 Int32</summary>
        bool WriteInt32(string address, int value);
        /// <summary>读取 Int32 数组</summary>
        int[] ReadInt32(string address, ushort length);

        /// <summary>写入 UInt32</summary>
        bool WriteUInt32(string address, uint value);
        /// <summary>读取 UInt32 数组</summary>
        uint[] ReadUInt32(string address, ushort length);

        /// <summary>写入 Int64</summary>
        bool WriteInt64(string address, long value);
        /// <summary>读取 Int64 数组</summary>
        long[] ReadInt64(string address, ushort length);

        /// <summary>写入 UInt64</summary>
        bool WriteUInt64(string address, ulong value);
        /// <summary>读取 UInt64 数组</summary>
        ulong[] ReadUInt64(string address, ushort length);

        /// <summary>写入单精度浮点</summary>
        bool WriteFloat(string address, float value);
        /// <summary>读取单精度浮点数组</summary>
        float[] ReadFloat(string address, ushort length);

        /// <summary>写入双精度浮点</summary>
        bool WriteDouble(string address, double value);
        /// <summary>读取双精度浮点数组</summary>
        double[] ReadDouble(string address, ushort length);

        /// <summary>写入字符串</summary>
        bool WriteString(string address, string value);
        /// <summary>读取字符串</summary>
        string ReadString(string address, ushort length);
    }
}
