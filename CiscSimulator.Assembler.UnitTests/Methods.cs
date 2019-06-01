using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    }
}
