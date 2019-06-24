using System;

namespace CiscSimulator.Sequencer.Methods
{
    public static class DBusOperationsMethods
    {
        public static void Pd0(Sequencer sequencer)
        {
            sequencer.DBus.Data.Value = 0;
        }

        public static void PdRg(Sequencer sequencer)
        {
            sequencer.DBus.Data.Value = sequencer.GeneralRegisters[sequencer.SelectedRegister].Data.Value;
        }

        public static void PdIr(Sequencer sequencer)
        {
            sequencer.DBus.Data.Value = sequencer.InstructionRegister.Data.Value;
        }

        public static void PdMdr(Sequencer sequencer)
        {
            sequencer.DBus.Data.Value = sequencer.MemoryDataRegister.Data.Value;
        }

        public static void PdSp(Sequencer sequencer)
        {
            sequencer.DBus.Data.Value = sequencer.StackPointerRegister.Data.Value;
        }

        public static void PdAdr(Sequencer sequencer)
        {
            sequencer.DBus.Data.Value = sequencer.MpmAddressRegister.Data.Value;
        }

        public static void PdT(Sequencer sequencer)
        {
            sequencer.DBus.Data.Value = sequencer.TemporaryRegister.Data.Value;
        }

        public static void PdPc(Sequencer sequencer)
        {
            sequencer.DBus.Data.Value = sequencer.ProgramCounterRegister.Data.Value;
        }

        public static void PdIvr(Sequencer sequencer)
        {
            sequencer.DBus.Data.Value = sequencer.InterruptVectorRegister.Data.Value;
        }

        public static void PdFlag(Sequencer sequencer)
        {
            sequencer.DBus.Data.Value = sequencer.FlagRegister.Data.Value;
        }

        public static void Pd1Positive(Sequencer sequencer)
        {
            sequencer.DBus.Data.Value = 1;
        }

        public static void Pd1Negative(Sequencer sequencer)
        {
            // Can't store negative values in ushort...
            throw new NotImplementedException();
        }
    }
}
