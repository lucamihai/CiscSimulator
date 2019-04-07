using CiscSimulator.Common;

namespace CiscSimulator.Assembler
{
    public class B1Instruction : Instruction
    {
        public byte InstructionNumber { get; set; }

        public AddressMode SourceAddressMode { get; set; }
        public byte Source { get; set; }

        public AddressMode DestinationAddressMode { get; set; }
        public byte Destination { get; set; }

        public override Data Data
        {
            get
            {
                var data = new Data();
                data.Value += (short)(InstructionNumber << 12);
                data.Value += (short)((short)SourceAddressMode << 10);
                data.Value += (short)(Source << 6);
                data.Value += (short)((short)DestinationAddressMode << 4);
                data.Value += (short)Destination;

                return data;
            }
        }
    }
}
