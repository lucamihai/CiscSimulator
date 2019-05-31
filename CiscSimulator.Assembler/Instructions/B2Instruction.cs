using CiscSimulator.Assembler.Enums;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler.Instructions
{
    public class B2Instruction : Instruction
    {
        public byte InstructionNumber { get; set; }

        public AddressMode AddressMode { get; set; }
        public byte Value { get; set; }
        public Data DataExtension { get; set; }


        public override Data Data
        {
            get
            {
                var data = new Data();
                data.Value += 4 << 13;
                data.Value += (ushort)(InstructionNumber << 6);
                data.Value += (ushort)((ushort)AddressMode << 4);
                data.Value += Value;

                return data;
            }
        }
    }
}
