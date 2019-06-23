namespace CiscSimulator.Sequencer.Methods
{
    public static class MemoryOperationsMethods
    {
        public static void IfCh(Sequencer sequencer)
        {
            var memoryAddress = sequencer.ProgramCounterRegister.Data.Value;
            sequencer.InstructionRegister.Data.Value = sequencer.Memory[memoryAddress].Value;
        }

        public static void Read(Sequencer sequencer)
        {
            var memoryAddress = sequencer.MpmAddressRegister.Data.Value;
            sequencer.MemoryDataRegister.Data.Value = sequencer.Memory[memoryAddress].Value;
        }

        public static void Write(Sequencer sequencer)
        {
            var memoryAddress = sequencer.MpmAddressRegister.Data.Value;
            sequencer.Memory[memoryAddress].Value = sequencer.MemoryDataRegister.Data.Value;
        }
    }
}
