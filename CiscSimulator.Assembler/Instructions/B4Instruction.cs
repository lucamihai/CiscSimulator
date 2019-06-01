using System.Collections.Generic;
using CiscSimulator.Assembler.Interfaces;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler.Instructions
{
    public class B4Instruction : IInstruction
    {
        public byte InstructionNumber { get; set; }

        public List<Data> Data
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
