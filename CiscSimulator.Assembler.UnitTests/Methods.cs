using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Assembler.Instructions;
using CiscSimulator.Assembler.Interfaces;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class Methods
    {
        public static bool DataListsAreTheSame(List<Data> dataList1, List<Data> dataList2)
        {
            if (dataList1.Count != dataList2.Count)
            {
                return false;
            }

            for (int index = 0; index < dataList1.Count; index++)
            {
                var data1 = dataList1[index];
                var data2 = dataList2[index];

                if (!data1.Equals(data2))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool InstructionListsAreTheSame(List<IInstruction> instructionList1, List<IInstruction> instructionList2)
        {
            if (instructionList1.Count != instructionList2.Count)
            {
                return false;
            }

            for (int index = 0; index < instructionList1.Count; index++)
            {
                var instruction1 = instructionList1[index];
                var instruction2 = instructionList2[index];

                if (instruction1.GetType() != instruction2.GetType())
                {
                    return false;
                }

                if (!DataListsAreTheSame(instruction1.Data, instruction2.Data))
                {
                    DataListsAreTheSame(instruction1.Data, instruction2.Data);
                    return false;
                }
            }

            return true;
        }

    }
}
