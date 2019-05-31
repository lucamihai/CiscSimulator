using CiscSimulator.Common;

namespace CiscSimulator.Assembler.Instructions
{
    public class B4Instruction : Instruction
    {
        public byte InstructionNumber { get; set; }

        public override Data Data
        {
            get
            {
                var data = new Data();
                data.Value += (7 << 13);
                data.Value += (ushort)(InstructionNumber);

                return data;
            }
        }
    }
}
