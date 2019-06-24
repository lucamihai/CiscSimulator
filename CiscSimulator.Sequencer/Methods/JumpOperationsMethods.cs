using System;

namespace CiscSimulator.Sequencer.Methods
{
    public static class JumpOperationsMethods
    {
        public static void Step(Sequencer sequencer)
        {
            sequencer.MpmAddressRegister.Data.Value++;
        }

        public static void Jump(Sequencer sequencer)
        {
            throw new NotImplementedException();
        }

        public static void JumpI(Sequencer sequencer)
        {
            throw new NotImplementedException();
        }

        public static void B1(Sequencer sequencer)
        {
            throw new NotImplementedException();
        }

        public static void Ad(Sequencer sequencer)
        {
            throw new NotImplementedException();
        }

        public static void Z(Sequencer sequencer)
        {
            throw new NotImplementedException();
        }

        public static void C(Sequencer sequencer)
        {
            throw new NotImplementedException();
        }

        public static void V(Sequencer sequencer)
        {
            throw new NotImplementedException();
        }

        public static void S(Sequencer sequencer)
        {
            throw new NotImplementedException();
        }

        public static void Intr(Sequencer sequencer)
        {
            throw new NotImplementedException();
        }

    }
}
