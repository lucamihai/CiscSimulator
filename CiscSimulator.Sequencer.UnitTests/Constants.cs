using System.Diagnostics.CodeAnalysis;
using CiscSimulator.ArithmeticLogicUnit.Enums;
using CiscSimulator.Sequencer.Enums;

namespace CiscSimulator.Sequencer.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public static SBusDBusOperations SBusOperation => SBusDBusOperations.PD0;
        public static SBusDBusOperations DBusOperation => SBusDBusOperations.PdAdr;
        public static Operator AluOperator => Operator.Add;
        public static RBusOperations RBusOperation => RBusOperations.PmIVR;
        public static OtherOperations OtherOperation => OtherOperations.CLS;
        public static MemoryOperations MemoryOperation => MemoryOperations.Read;
        public static JumpOperations JumpOperation => JumpOperations.B1;
        public const byte JumpLocation = 0;
        public static Indexes JumpIndex => Indexes.Index1;
    }
}
