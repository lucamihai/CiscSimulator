using System.Collections.Generic;
using CiscSimulator.Assembler.Enums;
using CiscSimulator.Assembler.Interfaces;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler.Instructions
{
    public class B1Instruction : IInstruction
    {
        public byte InstructionNumber { get; set; }

        public AddressMode SourceAddressMode { get; set; }
        public Data Source { get; set; }
        public Data SourceDataExtension { get; set; }

        public AddressMode DestinationAddressMode { get; set; }
        public Data Destination { get; set; }
        public Data DestinationDataExtension { get; set; }
        

        public List<Data> Data
        {
            get
            {
                var dataList = new List<Data>();

                var dataInstruction = new Data();
                dataInstruction.Value += (ushort)(InstructionNumber << 12);
                dataInstruction.Value += (ushort)((ushort)SourceAddressMode << 10);
                dataInstruction.Value += (ushort)((ushort)DestinationAddressMode << 4);
                dataInstruction.Value += Destination.Value;
                dataList.Add(dataInstruction);

                HandleDataListAndDataInstructionBasedOnSourceAddressMode(dataList, dataInstruction);
                HandleDataListAndDataInstructionBasedOnDestinationAddressMode(dataList, dataInstruction);

                return dataList;
            }

        }

        private void HandleDataListAndDataInstructionBasedOnSourceAddressMode(List<Data> dataList, Data dataInstruction)
        {
            if (SourceAddressMode == AddressMode.Immediate || SourceAddressMode == AddressMode.Indexed)
            {
                var dataSource = new Data();

                if (SourceAddressMode == AddressMode.Immediate)
                {
                    dataSource.Value = Source.Value;
                }

                if (SourceAddressMode == AddressMode.Indexed)
                {
                    dataInstruction.Value += (ushort)(Source.Value << 6);
                    dataSource.Value = SourceDataExtension.Value;
                }

                dataList.Add(dataSource);
            }
            else
            {
                dataInstruction.Value += (ushort)(Source.Value << 6);
            }
        }

        private void HandleDataListAndDataInstructionBasedOnDestinationAddressMode(List<Data> dataList, Data dataInstruction)
        {
            if (DestinationAddressMode == AddressMode.Indexed)
            {
                var dataDestination = new Data { Value = DestinationDataExtension.Value };
                dataList.Add(dataDestination);
            }
        }
    }
}
