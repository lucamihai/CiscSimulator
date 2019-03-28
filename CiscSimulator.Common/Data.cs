using System;

namespace CiscSimulator.Common
{
    public class Data : IComparable, ICloneable
    {
        public byte LoByte { get; set; } = byte.MinValue;
        public byte HiByte { get; set; } = byte.MinValue;

        public static Data LowestData => new Data { HiByte = byte.MinValue, LoByte = byte.MinValue };

        public short Value
        {
            get => BitConverter.ToInt16(new[] {LoByte, HiByte}, 0);
            set
            {
                HiByte = (byte) (value >> 8);
                LoByte = (byte) (value & 255);
            }
        }

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
            return new Data {HiByte = this.HiByte, LoByte = this.LoByte};
        }

        public int CompareTo(object obj)
        {
            if (obj is Data otherData)
            {
                return this.Value.CompareTo(otherData.Value);
            }

            throw new ArgumentException("Object is not a Data");
        }
    }
}
