using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CiscSimulator.Assembler.Interfaces;
using CiscSimulator.Common;
using CiscSimulator.Sequencer.Enums;

namespace CiscSimulator.Sequencer
{
    public partial class Sequencer : UserControl
    {
        public Step Step { get; private set; } = Step.Fetch;

        public Memory.Memory Memory { get; private set; }
        public MpmMemory MpmMemory { get; private set; }

        public GeneralRegisters.GeneralRegisters GeneralRegisters { get; private set; }
        public Register InstructionRegister { get; private set; }
        public Register MpmInstruction { get; private set; }
        public Register MemoryAddressRegister { get; private set; }
        public Register MemoryDataRegister { get; private set; }
        public Register StackPointerRegister { get; private set; }
        public Register TemporaryRegister { get; private set; }
        public Register ProgramCounterRegister { get; private set; }
        public Register InterruptVectorRegister { get; private set; }
        public Register FlagRegister { get; private set; }

        public ArithmeticLogicUnit.ArithmeticLogicUnit ArithmeticLogicUnit { get; private set; }
        public Bus SBus { get; private set; }
        public Bus DBus { get; private set; }
        public Bus RBus { get; private set; }

        public Sequencer()
        {
            InitializeComponent();
            InitializeMemory();
            InitializeMpmMemory();
            InitializeRegisters();
            InitializeBuses();
            InitializeArithmeticLogicUnit();

            AddControls();
        }

        public void LoadInstructionsInMemory(List<IInstruction> instructions)
        {
            ValidateInstructionList(instructions);
            ClearInstructionDataFromMemory();

            var currentAddress = Constants.MemoryInstructionStartAddress;
            foreach (var instruction in instructions)
            {
                foreach (var data in instruction.Data)
                {
                    Memory[currentAddress++].Value = data.Value;
                }
            }
        }

        public void NextStep()
        {
            if (Step == Step.Fetch)
            {
                Fetch();

                Step = Step.Execute;
                return;
            }

            if (Step == Step.Execute)
            {
                Execute();

                Step = Step.Fetch;
                return;
            }
        }

        private void ValidateInstructionList(List<IInstruction> instructions)
        {
            if (instructions == null)
            {
                throw new ArgumentNullException($"{nameof(instructions)} can't be null");
            }

            if (instructions.Count == 0)
            {
                throw new ArgumentException($"{nameof(instructions)} can't be empty");
            }

            if (!InstructionsCanBeAddedToMemory(instructions))
            {
                throw new ArgumentException($"{nameof(instructions)} can't fit into memory");
            }
        }

        private bool InstructionsCanBeAddedToMemory(List<IInstruction> instructions)
        {
            var memoryEntryCount = 0;
            foreach (var instruction in instructions)
            {
                memoryEntryCount += instruction.Data.Count;
            }

            var allowedMemoryEntryCount = 1 + Constants.MemoryInstructionEndAddress - Constants.MemoryInstructionStartAddress;

            return memoryEntryCount <= allowedMemoryEntryCount;
        }

        private void ClearInstructionDataFromMemory()
        {
            for (var address = Constants.MemoryInstructionStartAddress; address <= Constants.MemoryInstructionEndAddress; address++)
            {
                Memory[address].Value = 0;
            }
        }

        #region Controls initialization

        private void InitializeMemory()
        {
            Memory = new Memory.Memory(Constants.MemoryMinimumAddress, Constants.MemoryMaximumAddress);

            //TODO: Generate location in design
        }

        private void InitializeMpmMemory()
        {
            MpmMemory = new MpmMemory();
        }

        private void InitializeRegisters()
        {
            InitializeGeneralRegisters();
            InitializeInstructionRegister();
            InitializeMemoryAddressRegister();
            InitializeMemoryDataRegister();
            InitializeMemoryInstructionRegister();
            InitializeFlagRegister();
            InitializeStackPointerRegister();
            InitializeTemporaryRegister();
            InitializeInterruptVectorRegister();
            InitializeProgramCounterRegister();
        }

        private void InitializeGeneralRegisters()
        {
            GeneralRegisters = new GeneralRegisters.GeneralRegisters();
        }

        private void InitializeInstructionRegister()
        {
            InstructionRegister = new Register("IR");

            //TODO: Generate location in design
        }

        private void InitializeMemoryAddressRegister()
        {
            MemoryAddressRegister = new Register("MAR");

            //TODO: Generate location in design
        }

        private void InitializeMemoryDataRegister()
        {
            MemoryDataRegister = new Register("MDR");

            //TODO: Generate location in design
        }

        private void InitializeMemoryInstructionRegister()
        {
            MpmInstruction = new Register("MIR");

            //TODO: Generate location in design
        }

        private void InitializeFlagRegister()
        {
            FlagRegister = new Register("FLAG");

            //TODO: Generate location in design
        }

        private void InitializeStackPointerRegister()
        {
            StackPointerRegister = new Register("SP");

            //TODO: Generate location in design
        }

        private void InitializeTemporaryRegister()
        {
            TemporaryRegister = new Register("T");

            //TODO: Generate location in design
        }

        private void InitializeInterruptVectorRegister()
        {
            InterruptVectorRegister = new Register("IVR");

            //TODO: Generate location in design
        }

        private void InitializeProgramCounterRegister()
        {
            ProgramCounterRegister = new Register("PC");

            //TODO: Generate location in design
        }

        private void InitializeBuses()
        {
            InitializeSBus();
            InitializeDBus();
            InitializeRBus();
        }

        private void InitializeSBus()
        {
            SBus = new Bus("SBus");

            //TODO: Generate location in design
        }

        private void InitializeDBus()
        {
            DBus = new Bus("DBus");

            //TODO: Generate location in design
        }

        private void InitializeRBus()
        {
            RBus = new Bus("RBus");

            //TODO: Generate location in design
        }

        private void InitializeArithmeticLogicUnit()
        {
            ArithmeticLogicUnit = new ArithmeticLogicUnit.ArithmeticLogicUnit();

            //TODO: Generate location in design
        }

        #endregion

        private void AddControls()
        {
            //TODO
        }

        private void Fetch()
        {
            //TODO
        }

        private void Execute()
        {
            //TODO
        }
    }
}
