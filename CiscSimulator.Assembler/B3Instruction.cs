using CiscSimulator.Common;

namespace CiscSimulator.Assembler
{
    public class B3Instruction : Instruction
    {
        public byte InstructionNumber { get; set; }
        public byte Offset { get; set; }
        public Data DataExtension { get; set; }

        public override Data Data
        {
            get
            {
                var data = new Data();
                data.Value += (6 << 13);
                data.Value += (ushort)(InstructionNumber << 8);
                data.Value += (ushort)Offset;

                return data;
            }
        }
    }
}
