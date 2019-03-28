using System;

namespace CiscSimulator.Common
{
    public class Data : IComparable, ICloneable
    {
        public byte LoByte { get; set; } = byte.MinValue;
        public byte HiByte { get; set; } = byte.MinValue;

        public short Value => BitConverter.ToInt16(new[] {LoByte, HiByte}, 0);

        public override string ToString()
        {
            return
                $"{Utilities.GetBinaryStringRepresentation(HiByte)} {Utilities.GetBinaryStringRepresentation(LoByte)}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Data otherData)
            {
                return this.LoByte == otherData.LoByte && this.HiByte == otherData.HiByte;
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
