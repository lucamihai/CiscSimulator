using System;
using System.Collections.Generic;
using System.Drawing;
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

        public int SelectedRegister { get; set; }
        public GeneralRegisters.GeneralRegisters GeneralRegisters { get; private set; }
        public Register InstructionRegister { get; private set; }
        public MpmDataRegister MpmInstructionRegister { get; private set; }
        public Register MpmAddressRegister { get; private set; }
        public Register MemoryAddressRegister { get; private set; }
        public Register MemoryDataRegister { get; private set; }
        public Register StackPointerRegister { get; private set; }
        public Register TemporaryRegister { get; private set; }
        public Register ProgramCounterRegister { get; private set; }
        public Register InterruptVectorRegister { get; private set; }
        public FlagRegister FlagRegister { get; private set; }

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

        private void InitializeGeneralRegisters()
        {
            GeneralRegisters = new GeneralRegisters.GeneralRegisters();
            GeneralRegisters.Location = new Point(Locations.FirstColumn, 0);
            GeneralRegisters.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeMemory()
        {
            Memory = new Memory.Memory(Constants.MemoryMinimumAddress, Constants.MemoryMaximumAddress);
            Memory.Location = new Point(Locations.SecondColumn, 0);
            Memory.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeRegisters()
        {
            InitializeGeneralRegisters();
            
            InitializeMemoryAddressRegister();
            InitializeMemoryDataRegister();
            InitializeInstructionRegister();
            InitializeStackPointerRegister();
            InitializeTemporaryRegister();
            InitializeProgramCounterRegister();
            InitializeInterruptVectorRegister();
            InitializeFlagRegister();

            InitializeMpmAddressRegister();
            InitializeMpmInstructionRegister();
        }

        private void InitializeArithmeticLogicUnit()
        {
            ArithmeticLogicUnit = new ArithmeticLogicUnit.ArithmeticLogicUnit();
            ArithmeticLogicUnit.Location = new Point(Locations.SecondColumn, FlagRegister.Location.Y + FlagRegister.Size.Height + 40);
            ArithmeticLogicUnit.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeMemoryAddressRegister()
        {
            MemoryAddressRegister = new Register("ADR");
            MemoryAddressRegister.Location = new Point(Locations.SecondColumn, Memory.Location.Y + Memory.Size.Height + 40);
            MemoryAddressRegister.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeMemoryDataRegister()
        {
            MemoryDataRegister = new Register("MDR");
            MemoryDataRegister.Location = new Point(Locations.SecondColumn, MemoryAddressRegister.Location.Y + MemoryAddressRegister.Size.Height + 10);
            MemoryDataRegister.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeInstructionRegister()
        {
            InstructionRegister = new Register("IR");
            InstructionRegister.Location = new Point(Locations.SecondColumn, MemoryDataRegister.Location.Y + MemoryDataRegister.Size.Height + 10);
            InstructionRegister.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeStackPointerRegister()
        {
            StackPointerRegister = new Register("SP");
            StackPointerRegister.Location = new Point(Locations.SecondColumn, InstructionRegister.Location.Y + InstructionRegister.Size.Height + 10);
            StackPointerRegister.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeTemporaryRegister()
        {
            TemporaryRegister = new Register("T");
            TemporaryRegister.Location = new Point(Locations.SecondColumn, StackPointerRegister.Location.Y + StackPointerRegister.Size.Height + 10);
            TemporaryRegister.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeProgramCounterRegister()
        {
            ProgramCounterRegister = new Register("PC");
            ProgramCounterRegister.Location = new Point(Locations.SecondColumn, TemporaryRegister.Location.Y + TemporaryRegister.Size.Height + 10);
            ProgramCounterRegister.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeInterruptVectorRegister()
        {
            InterruptVectorRegister = new Register("IVR");
            InterruptVectorRegister.Location = new Point(Locations.SecondColumn, ProgramCounterRegister.Location.Y + ProgramCounterRegister.Size.Height + 10);
            InterruptVectorRegister.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeFlagRegister()
        {
            FlagRegister = new FlagRegister();
            FlagRegister.Location = new Point(Locations.SecondColumn, InterruptVectorRegister.Location.Y + InterruptVectorRegister.Size.Height + 10);
            FlagRegister.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeMpmAddressRegister()
        {
            MpmAddressRegister = new Register("MAR");
            MpmAddressRegister.Location = new Point(Locations.FirstColumn, GeneralRegisters.Location.Y + GeneralRegisters.Size.Height + 250);
            MpmAddressRegister.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeMpmInstructionRegister()
        {
            MpmInstructionRegister = new MpmDataRegister();
            MpmInstructionRegister.Location = new Point(Locations.FirstColumn, MpmAddressRegister.Location.Y + MpmAddressRegister.Size.Height + 10);
            MpmInstructionRegister.BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeBuses()
        {
            InitializeSBus();
            InitializeDBus();
            InitializeRBus();

            //TODO: Generate locations in design
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

        

        private void InitializeMpmMemory()
        {
            MpmMemory = new MpmMemory();
        }

        #endregion

        private void AddControls()
        {
            Controls.Add(GeneralRegisters);
            Controls.Add(Memory);

            Controls.Add(MemoryAddressRegister);
            Controls.Add(MemoryDataRegister);
            Controls.Add(InstructionRegister);
            Controls.Add(StackPointerRegister);
            Controls.Add(TemporaryRegister);
            Controls.Add(ProgramCounterRegister);
            Controls.Add(InterruptVectorRegister);
            Controls.Add(FlagRegister);

            Controls.Add(ArithmeticLogicUnit);
            Controls.Add(SBus);
            Controls.Add(DBus);
            Controls.Add(RBus);

            Controls.Add(MpmAddressRegister);
            Controls.Add(MpmInstructionRegister);
        }

        private void Fetch()
        {
            MpmInstructionRegister.MpmData.Value = MpmMemory[MpmAddressRegister.Data.Value].Value;
        }

        private void Execute()
        {
            //TODO
        }
    }
}
