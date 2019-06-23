using System;

namespace CiscSimulator.Sequencer.Methods
{
    public static class SBusOperationsMethods
    {
        public static void Pd0(Sequencer sequencer)
        {
            sequencer.SBus.Data.Value = 0;
        }

        public static void PdRg(Sequencer sequencer)
        {
            // Which register should be selected?
            throw new NotImplementedException();
        }

        public static void PdIr(Sequencer sequencer)
        {
            sequencer.SBus.Data.Value = sequencer.InstructionRegister.Data.Value;
        }

        public static void PdMdr(Sequencer sequencer)
        {
            sequencer.SBus.Data.Value = sequencer.MemoryDataRegister.Data.Value;
        }

        public static void PdSp(Sequencer sequencer)
        {
            sequencer.SBus.Data.Value = sequencer.StackPointerRegister.Data.Value;
        }

        public static void PdAdr(Sequencer sequencer)
        {
            sequencer.SBus.Data.Value = sequencer.MpmAddressRegister.Data.Value;
        }

        public static void PdT(Sequencer sequencer)
        {
            sequencer.SBus.Data.Value = sequencer.TemporaryRegister.Data.Value;
        }

        public static void PdPc(Sequencer sequencer)
        {
            sequencer.SBus.Data.Value = sequencer.ProgramCounterRegister.Data.Value;
        }

        public static void PdIvr(Sequencer sequencer)
        {
            sequencer.SBus.Data.Value = sequencer.InterruptVectorRegister.Data.Value;
        }

        public static void PdFlag(Sequencer sequencer)
        {
            sequencer.SBus.Data.Value = sequencer.FlagRegister.Data.Value;
        }

        public static void Pd1Positive(Sequencer sequencer)
        {
            sequencer.SBus.Data.Value = 1;
        }

        public static void Pd1Negative(Sequencer sequencer)
        {
            // Can't store negative values in ushort...
            throw new NotImplementedException();
        }
    }
}
