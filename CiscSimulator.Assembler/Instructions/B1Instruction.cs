using CiscSimulator.Assembler.Enums;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler.Instructions
{
    public class B1Instruction : Instruction
    {
        public byte InstructionNumber { get; set; }

        public AddressMode SourceAddressMode { get; set; }
        public byte Source { get; set; }
        public Data SourceDataExtension { get; set; }

        public AddressMode DestinationAddressMode { get; set; }
        public byte Destination { get; set; }
        public Data DestinationDataExtension { get; set; }
        

        public override Data Data
        {
            get
            {
                var data = new Data();
                data.Value += (ushort)(InstructionNumber << 12);
                data.Value += (ushort)((ushort)SourceAddressMode << 10);
                data.Value += (ushort)(Source << 6);
                data.Value += (ushort)((ushort)DestinationAddressMode << 4);
                data.Value += (ushort)Destination;

                return data;
            }
        }
    }
}
