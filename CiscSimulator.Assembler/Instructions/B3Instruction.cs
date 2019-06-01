using System.Collections.Generic;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler.Instructions
{
    public class B3Instruction : Instruction
    {
        public byte InstructionNumber { get; set; }
        public byte Offset { get; set; }
        public Data DataExtension { get; set; }

        public override List<Data> Data
        {
            get
            {
                var dataList = new List<Data>();

                var dataInstruction = new Data();
                dataInstruction.Value += (6 << 13);
                dataInstruction.Value += (ushort)(InstructionNumber << 8);
                dataInstruction.Value += (ushort)Offset;

                dataList.Add(dataInstruction);
                dataList.Add(DataExtension);

                return dataList;
            }
        }
    }
}
