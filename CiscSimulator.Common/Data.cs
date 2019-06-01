using System;

namespace CiscSimulator.Common
{
    public class Data : ICloneable
    {
        private byte _LoByte;
        public byte LoByte
        {
            get => _LoByte;
            set
            {
                _LoByte = value;
                OnValueChanged();
            }
        }

        private byte _HiByte;
        public byte HiByte
        {
            get => _HiByte;
            set
            {
                _HiByte = value;
                OnValueChanged();
            }
        }

        public ushort Value
        {
            get => BitConverter.ToUInt16(new[] {LoByte, HiByte}, 0);
            set
            {
                HiByte = (byte) (value >> 8);
                LoByte = (byte) (value & 255);
            }
        }

        public delegate void ValueChanged();
        public ValueChanged OnValueChanged { get; set; } = () => { };

        public static Data LowestData => new Data { HiByte = byte.MinValue, LoByte = byte.MinValue };

        public override string ToString()
        {
            return
                $"{Utilities.GetBinaryStringRepresentation(HiByte)} {Utilities.GetBinaryStringRepresentation(LoByte)}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Data otherData)
            {
                return this.Value == otherData.Value;
            }

            return false;
        }

        public object Clone()
        {
            return new Data {Value = this.Value};
        }
    }
}
