using System.Collections.Generic;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler.Instructions
{
    public class Instruction
    {
        public virtual List<Data> Data { get; }
    }
}
