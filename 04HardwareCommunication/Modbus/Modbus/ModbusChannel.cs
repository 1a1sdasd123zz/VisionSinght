using System;
using HardwareCommunication.Abstractions;
using HardwareCommunication.Core;
using HslCommunication.ModBus;

namespace Modbus
{
    /// <summary>
    /// 基于 HslCommunication 的 Modbus TCP 通道实现。
    /// - 能力类型：<see cref="CommCapabilities.Registers"/>
    /// - 读写：实现了常见的寄存器/线圈读写接口（Bool/Int16/UInt16/Int32/UInt32/Int64/UInt64/Float/Double/String 及数组）
    /// - 连接状态：在 <see cref="Open"/>/<see cref="Close"/> 时通过 <see cref="BaseCommChannel.ConnectionStateChanged"/> 通知
    /// </summary>
    [CommProvider("ModbusTcp", typeof(ModbusConfigView), "ModbusTCP")]
    public class ModbusChannel : BaseCommChannel
    {
        private ModbusTcpNet _client;
        private bool _isConnected;
        public ModbusChannel(ICommParameters parameters) : base(parameters) { }

        /// <summary>
        /// 是否已连接（只读）。
        /// </summary>
        public override bool IsConnected => _isConnected;

        /// <summary>
        /// 通道能力：寄存器读写。
        /// </summary>
        public override CommCapabilities Capabilities => CommCapabilities.Registers;

        /// <summary>
        /// 打开与 PLC 的连接。
        /// </summary>
        public override int Open()
        {
            try
            {
                _client = new ModbusTcpNet(Parameters.Host, Parameters.Port, (byte)Parameters.Station);
                var res = _client.ConnectServer();
                _isConnected = res.IsSuccess;
                RaiseConnection(_isConnected);
                return _isConnected ? 0 : -1;
            }
            catch (Exception)
            {
                _isConnected = false; RaiseConnection(false);
                return -1;
            }
        }

        /// <summary>
        /// 关闭连接。
        /// </summary>
        public override void Close()
        {
            try { _client?.ConnectClose(); } catch { }
            _isConnected = false; RaiseConnection(false);
        }

        // 读写实现区域
        public override bool WriteBool(string address, bool value) => _client.Write(address, value).IsSuccess;
        public override bool[] ReadBool(string address, ushort length) => _client.ReadBool(address, length).Content;
        public override bool WriteInt16(string address, short value) => _client.Write(address, value).IsSuccess;
        public override short[] ReadInt16(string address, ushort length) => _client.ReadInt16(address, length).Content;
        public override bool WriteUInt16(string address, ushort value) => _client.Write(address, value).IsSuccess;
        public override ushort[] ReadUInt16(string address, ushort length) => _client.ReadUInt16(address, length).Content;
        public override bool WriteInt32(string address, int value) => _client.Write(address, value).IsSuccess;
        public override int[] ReadInt32(string address, ushort length) => _client.ReadInt32(address, length).Content;
        public override bool WriteUInt32(string address, uint value) => _client.Write(address, value).IsSuccess;
        public override uint[] ReadUInt32(string address, ushort length) => _client.ReadUInt32(address, length).Content;
        public override bool WriteInt64(string address, long value) => _client.Write(address, value).IsSuccess;
        public override long[] ReadInt64(string address, ushort length) => _client.ReadInt64(address, length).Content;
        public override bool WriteUInt64(string address, ulong value) => _client.Write(address, value).IsSuccess;
        public override ulong[] ReadUInt64(string address, ushort length) => _client.ReadUInt64(address, length).Content;
        public override bool WriteFloat(string address, float value) => _client.Write(address, value).IsSuccess;
        public override float[] ReadFloat(string address, ushort length) => _client.ReadFloat(address, length).Content;
        public override bool WriteDouble(string address, double value) => _client.Write(address, value).IsSuccess;
        public override double[] ReadDouble(string address, ushort length) => _client.ReadDouble(address, length).Content;
        public override bool WriteString(string address, string value) => _client.Write(address, value).IsSuccess;
        public override string ReadString(string address, ushort length) => _client.ReadString(address, length).Content;
    }
}
