using CiscSimulator.Common;

namespace CiscSimulator.Assembler
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
                data.Value += (short)(InstructionNumber << 6);
                data.Value += (short)((short)AddressMode << 4);
                data.Value += Value;

                return data;
            }
        }
    }
}
