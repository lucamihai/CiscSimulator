using System;

namespace CiscSimulator.Common
{
    public class Data : ICloneable
    {
        public bool ReadOnly { get; }

        private byte _LoByte;
        public byte LoByte
        {
            get => _LoByte;
            set
            {
                if (ReadOnly)
                {
                    throw new InvalidOperationException("Data is read-only");
                }

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
                if (ReadOnly)
                {
                    throw new InvalidOperationException("Data is read-only");
                }

                _HiByte = value;
                OnValueChanged();
            }
        }

        public ushort Value
        {
            get => BitConverter.ToUInt16(new[] {LoByte, HiByte}, 0);
            set
            {
                if (ReadOnly)
                {
                    throw new InvalidOperationException("Data is read-only");
                }

                HiByte = (byte) (value >> 8);
                LoByte = (byte) (value & 255);
            }
        }

        public delegate void ValueChanged();
        public ValueChanged OnValueChanged { get; set; } = () => { };

        public static Data LowestData => new Data { HiByte = byte.MinValue, LoByte = byte.MinValue };

        public Data(bool readOnly = false)
        {
            ReadOnly = readOnly;
        }

        public override string ToString()
        {
            return
                $"{Utilities.GetBinaryStringRepresentationFromByte(HiByte)} {Utilities.GetBinaryStringRepresentationFromByte(LoByte)}";
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
