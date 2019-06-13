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
        public static AluOperator AluOperator => AluOperator.Add;
        public static RBusOperations RBusOperation => RBusOperations.PmIVR;
        public static OtherOperations OtherOperation => OtherOperations.CLS;
        public static MemoryOperations MemoryOperation => MemoryOperations.Read;
        public static JumpOperations JumpOperation => JumpOperations.B1;
        public const byte JumpLocation = 0;
        public static Indexes JumpIndex => Indexes.Index1;

        // 0x408A8A6011
        public const long ExpectedValue1 = 277202231313;
        public static MpmData MpmData1 => new MpmData
        {
            SBusOperation = SBusDBusOperations.PdPc,
            DBusOperation = SBusDBusOperations.PD0,
            AluOperator = AluOperator.Add,
            RBusOperation = RBusOperations.PmAdr,
            OtherOperation = OtherOperations.IncrementPC,
            MemoryOperation = MemoryOperations.IfCh,
            JumpOperation = JumpOperations.JUMPI,
            JumpLocation = 1,
            JumpIndex = Indexes.Index1
        };

        // 0x108B0060D3
        public const long ExpectedValue2 = 71051534547;
        public static MpmData MpmData2 => new MpmData
        {
            SBusOperation = SBusDBusOperations.PdRG,
            DBusOperation = SBusDBusOperations.PD0,
            AluOperator = AluOperator.Add,
            RBusOperation = RBusOperations.PmT,
            OtherOperation = OtherOperations.None,
            MemoryOperation = MemoryOperations.None,
            JumpOperation = JumpOperations.JUMPI,
            JumpLocation = 13,
            JumpIndex = Indexes.Index3
        };
    }
}
