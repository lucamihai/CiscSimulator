using System.Collections.Generic;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler.Interfaces
{
    public interface IInstruction
    {
        List<Data> Data { get; }
    }
}
