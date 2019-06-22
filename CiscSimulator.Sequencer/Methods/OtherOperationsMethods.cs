namespace CiscSimulator.Sequencer.Methods
{
    public static class OtherOperationsMethods
    {
        public static void IncrementPc(Sequencer sequencer)
        {
            sequencer.ProgramCounterRegister.Data.Value++;
        }

        public static void IncrementSp(Sequencer sequencer)
        {
            sequencer.StackPointerRegister.Data.Value++;
        }

        public static void DecrementSp(Sequencer sequencer)
        {
            sequencer.StackPointerRegister.Data.Value--;
        }
    }
}
