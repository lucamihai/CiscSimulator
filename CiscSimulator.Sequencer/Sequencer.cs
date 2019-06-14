using System.Windows.Forms;
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
        public Register MemoryAddressRegister { get; private set; }
        public Register MemoryInstructionRegister { get; private set; }
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

            //TODO: Add controls to this.Controls
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
            InitializeMemoryAddressRegister();
            InitializeMemoryInstructionRegister();
        }

        private void InitializeGeneralRegisters()
        {
            GeneralRegisters = new GeneralRegisters.GeneralRegisters();
        }

        private void InitializeMemoryAddressRegister()
        {
            MemoryAddressRegister = new Register("MAR");

            //TODO: Generate location in design
        }

        private void InitializeMemoryInstructionRegister()
        {
            MemoryInstructionRegister = new Register("MIR");

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
