using System.Collections.Generic;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler.Instructions
{
    public class B4Instruction : Instruction
    {
        public byte InstructionNumber { get; set; }

        public override List<Data> Data
        {
            get
            {
                var dataList = new List<Data>();

                var dataInstruction = new Data();
                dataInstruction.Value += (7 << 13);
                dataInstruction.Value += (ushort)(InstructionNumber);
                dataList.Add(dataInstruction);

                return dataList;
            }
        }
    }
}
