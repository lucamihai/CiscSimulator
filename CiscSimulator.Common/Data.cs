using System;

namespace CiscSimulator.Common
{
    public class Data : ICloneable
    {
        public bool ReadOnly { get; }

        private byte loByte;
        public byte LoByte
        {
            get => loByte;
            set
            {
                if (ReadOnly)
                {
                    throw new InvalidOperationException("Data is read-only");
                }

                loByte = value;
                OnValueChanged();
            }
        }

        private byte hiByte;
        public byte HiByte
        {
            get => hiByte;
            set
            {
                if (ReadOnly)
                {
                    throw new InvalidOperationException("Data is read-only");
                }

                hiByte = value;
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

        public Data(bool readOnly = false)
        {
            ReadOnly = readOnly;
        }

        public override string ToString()
        {
            return $"{Utilities.GetBinaryStringRepresentation(HiByte)} {Utilities.GetBinaryStringRepresentation(LoByte)}";
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
