using System.Collections.Generic;
using CiscSimulator.Assembler.Enums;
using CiscSimulator.Assembler.Interfaces;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler.Instructions
{
    public class B2Instruction : IInstruction
    {
        public byte InstructionNumber { get; set; }

        public AddressMode AddressMode { get; set; }
        public Data Value { get; set; }
        public Data DataExtension { get; set; }


        public List<Data> Data
        {
            get
            {
                var dataList = new List<Data>();

                var dataInstruction = new Data();
                dataInstruction.Value += 4 << 13;
                dataInstruction.Value += (ushort)(InstructionNumber << 6);
                dataInstruction.Value += (ushort)((ushort)AddressMode << 4);
                dataList.Add(dataInstruction);

                HandleDataListAndDataInstructionBasedOnAddressMode(dataList, dataInstruction);

                return dataList;
            }
        }

        private void HandleDataListAndDataInstructionBasedOnAddressMode(List<Data> dataList, Data dataInstruction)
        {
            if (AddressMode == AddressMode.Indexed)
            {
                var dataSource = new Data();
                dataInstruction.Value += Value.Value;
                dataSource.Value = DataExtension.Value;

                dataList.Add(dataSource);
            }
            else
            {
                dataInstruction.Value += Value.Value;
            }
        }
    }
}
