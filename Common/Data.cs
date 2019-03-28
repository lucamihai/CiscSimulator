namespace Common
{
    public class Data
    {
        public byte LoByte { get; set; } = byte.MinValue;
        public byte HiByte { get; set; } = byte.MinValue;

        public override string ToString()
        {
            return
                $"{Utilities.GetBinaryStringRepresentation(HiByte)} {Utilities.GetBinaryStringRepresentation(LoByte)}";
        }
    }
}
