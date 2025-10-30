using System;
using HardwareCommunication.Abstractions;

namespace HardwareCommunication.Core;

/// <summary>
/// 通讯通道抽象基类：
/// - 持有 <see cref="ICommParameters"/> 参数
/// - 统一抛出不支持的默认实现
/// - 提供 <see cref="RaiseConnection"/> 与 <see cref="RaiseMessage"/> 事件触发帮助方法
/// 具体 Provider 仅需覆盖自身能力范围对应的方法。
/// </summary>
public abstract class BaseCommChannel : ICommChannel
{
    /// <summary>
    /// 通过参数构造具体通道。
    /// </summary>
    protected BaseCommChannel(ICommParameters parameters)
    {
        Parameters = parameters;
    }

    /// <inheritdoc />
    public ICommParameters Parameters { get; }
    /// <inheritdoc />
    public abstract bool IsConnected { get;}

    /// <inheritdoc />
    public abstract CommCapabilities Capabilities { get; }

    /// <inheritdoc />
    public event Action<string, bool> ConnectionStateChanged;
    /// <inheritdoc />
    public event Action<string, byte[]> MessageReceived;

    /// <summary>
    /// 触发连接状态事件（供子类调用）。
    /// </summary>
    protected void RaiseConnection(bool connected) => ConnectionStateChanged?.Invoke(Parameters.Key, connected);
    /// <summary>
    /// 触发消息接收事件（供子类调用）。
    /// </summary>
    protected void RaiseMessage(byte[] data) => MessageReceived?.Invoke(Parameters.Key, data);

    /// <inheritdoc />
    public abstract int Open();
    /// <inheritdoc />
    public abstract void Close();

    // Message 默认不支持
    /// <inheritdoc />
    public virtual int Send(byte[] payload) => throw new NotSupportedException();

    // Registers 默认不支持
    /// <inheritdoc />
    public virtual bool WriteBool(string address, bool value) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual bool[] ReadBool(string address, ushort length) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual bool WriteInt16(string address, short value) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual short[] ReadInt16(string address, ushort length) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual bool WriteUInt16(string address, ushort value) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual ushort[] ReadUInt16(string address, ushort length) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual bool WriteInt32(string address, int value) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual int[] ReadInt32(string address, ushort length) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual bool WriteUInt32(string address, uint value) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual uint[] ReadUInt32(string address, ushort length) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual bool WriteInt64(string address, long value) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual long[] ReadInt64(string address, ushort length) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual bool WriteUInt64(string address, ulong value) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual ulong[] ReadUInt64(string address, ushort length) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual bool WriteFloat(string address, float value) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual float[] ReadFloat(string address, ushort length) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual bool WriteDouble(string address, double value) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual double[] ReadDouble(string address, ushort length) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual bool WriteString(string address, string value) => throw new NotSupportedException();
    /// <inheritdoc />
    public virtual string ReadString(string address, ushort length) => throw new NotSupportedException();
}