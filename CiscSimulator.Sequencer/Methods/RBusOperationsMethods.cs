﻿using System;

namespace CiscSimulator.Sequencer.Methods
{
    public static class RBusOperationsMethods
    {
        public static void PmRg(Sequencer sequencer)
        {
            // Which register should be selected?
            throw new NotImplementedException();
        }

        public static void PmIr(Sequencer sequencer)
        {
            sequencer.InstructionRegister.Data.Value = sequencer.RBus.Data.Value;
        }

        public static void PmMdr(Sequencer sequencer)
        {
            sequencer.MemoryDataRegister.Data.Value = sequencer.RBus.Data.Value;
        }

        public static void PmSp(Sequencer sequencer)
        {
            sequencer.StackPointerRegister.Data.Value = sequencer.RBus.Data.Value;
        }

        public static void PmAdr(Sequencer sequencer)
        {
            sequencer.MemoryAddressRegister.Data.Value = sequencer.RBus.Data.Value;
        }

        public static void PmT(Sequencer sequencer)
        {
            sequencer.TemporaryRegister.Data.Value = sequencer.RBus.Data.Value;
        }

        public static void PmPc(Sequencer sequencer)
        {
            sequencer.ProgramCounterRegister.Data.Value = sequencer.RBus.Data.Value;
        }

        public static void PmIvr(Sequencer sequencer)
        {
            sequencer.InterruptVectorRegister.Data.Value = sequencer.RBus.Data.Value;
        }

        public static void PmFlag(Sequencer sequencer)
        {
            sequencer.FlagRegister.Data.Value = sequencer.RBus.Data.Value;
        }
    }
}
