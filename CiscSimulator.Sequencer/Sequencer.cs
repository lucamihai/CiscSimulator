using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CiscSimulator.ArithmeticLogicUnit.Enums;
using CiscSimulator.Assembler.Enums;
using CiscSimulator.Assembler.Interfaces;
using CiscSimulator.Common;
using CiscSimulator.Common.Enums;
using CiscSimulator.Sequencer.Enums;
using CiscSimulator.Sequencer.Methods;

namespace CiscSimulator.Sequencer
{
    public partial class Sequencer : UserControl
    {
        public bool Interrupt { get; set; } = false;

        private Label labelStep;
        public Step Step { get; private set; } = Step.Fetch;

        private ValueDisplayMode valueDisplayMode;

        public ValueDisplayMode ValueDisplayMode
        {
            get => valueDisplayMode;
            set
            {
                valueDisplayMode = value;
                UpdateValueDisplayModeForControls();
            }
        }

        public GeneralRegisters.GeneralRegisters GeneralRegisters { get; private set; }
        public int SelectedRegister { get; set; }

        public Memory.Memory Memory { get; private set; }

        #region Registers

        public Register MemoryAddressRegister { get; private set; }
        public Register MemoryDataRegister { get; private set; }
        public Register InstructionRegister { get; private set; }
        public Register StackPointerRegister { get; private set; }
        public Register TemporaryRegister { get; private set; }
        public Register ProgramCounterRegister { get; private set; }
        public Register InterruptVectorRegister { get; private set; }
        public FlagRegister FlagRegister { get; private set; }

        #endregion

        public ArithmeticLogicUnit.ArithmeticLogicUnit ArithmeticLogicUnit { get; private set; }

        private TextBox textBoxDisplayedValueSBus;
        private Label labelSBus;
        public Bus SBus { get; private set; }

        private TextBox textBoxDisplayedValueDBus;
        private Label labelDBus;
        public Bus DBus { get; private set; }

        private TextBox textBoxDisplayedValueRBus;
        private Label labelRBus;
        public Bus RBus { get; private set; }

        public MpmDataRegister MpmInstructionRegister { get; private set; }
        public Register MpmAddressRegister { get; private set; }
        public MpmMemory MpmMemory { get; private set; }

        #region

        private Line lineFromMemoryAddressRegisterToMemory;
        private Line lineFromMemoryAddressRegisterToSBus;
        private Line lineFromMemoryAddressRegisterToDBus;
        private Line lineFromMemoryAddressRegisterToRBus;

        private Line lineFromMemoryDataRegisterToMemory;
        private Line lineFromMemoryDataRegisterToSBus;
        private Line lineFromMemoryDataRegisterToDBus;
        private Line lineFromMemoryDataRegisterToRBus;

        private Line lineFromInstructionRegisterToSBus;
        private Line lineFromInstructionRegisterToDBus;
        private Line lineFromInstructionRegisterToRBus;

        private Line lineFromStackPointerRegisterToSBus;
        private Line lineFromStackPointerRegisterToDBus;
        private Line lineFromStackPointerRegisterToRBus;

        private Line lineFromTemporaryRegisterToSBus;
        private Line lineFromTemporaryRegisterToDBus;
        private Line lineFromTemporaryRegisterToRBus;

        private Line lineFromProgramCounterRegisterToSBus;
        private Line lineFromProgramCounterRegisterToDBus;
        private Line lineFromProgramCounterRegisterToRBus;

        #endregion

        public Sequencer()
        {
            InitializeComponent();

            InitializeLabelStep();

            InitializeMemory();
            InitializeMpmMemory();
            InitializeRegisters();
            InitializeBuses();
            InitializeArithmeticLogicUnit();

            InitializeLines();

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

            ProgramCounterRegister.Data.Value = Constants.MemoryInstructionStartAddress;
        }

        public void NextStep()
        {
            if (Step == Step.Fetch)
            {
                Fetch();

                Step = Step.Execute;
                labelStep.Text = $"Step: {Step.ToString()}";

                return;
            }

            if (Step == Step.Execute)
            {
                Execute();

                Step = Step.Fetch;
                labelStep.Text = $"Step: {Step.ToString()}";

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

        private void InitializeLabelStep()
        {
            labelStep = new Label();
            labelStep.Text = $"Step: {Step.ToString()}";
            labelStep.Location = new Point(this.Width - labelStep.Size.Width, 0);
        }

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
        }

        private void InitializeSBus()
        {
            SBus = new Bus("SBus");

            var x = (GeneralRegisters.Location.X + GeneralRegisters.Size.Width + Locations.SecondColumn) / 2 - 10;
            SBus.Location = new Point(x, 0);

            textBoxDisplayedValueSBus = new TextBox();
            textBoxDisplayedValueSBus.Size = new Size(125, textBoxDisplayedValueSBus.Height);
            textBoxDisplayedValueSBus.TextAlign = HorizontalAlignment.Right;
            textBoxDisplayedValueSBus.ReadOnly = true;
            textBoxDisplayedValueSBus.Location = new Point(SBus.Location.X - 125 - 4, SBus.Location.Y + SBus.Height - textBoxDisplayedValueSBus.Height);

            labelSBus = new Label();
            labelSBus.Text = SBus.BusName;
            labelSBus.Location = new Point(SBus.Location.X - 125, SBus.Location.Y + SBus.Height - textBoxDisplayedValueSBus.Height - labelSBus.Height);

            SBus.TextBoxDisplayValue = textBoxDisplayedValueSBus;
        }

        private void InitializeDBus()
        {
            DBus = new Bus("DBus");

            var x = (GeneralRegisters.Location.X + GeneralRegisters.Size.Width + Locations.SecondColumn) / 2 + 10;
            DBus.Location = new Point(x, 0);

            textBoxDisplayedValueDBus = new TextBox();
            textBoxDisplayedValueDBus.Size = new Size(125, textBoxDisplayedValueDBus.Height);
            textBoxDisplayedValueDBus.TextAlign = HorizontalAlignment.Right;
            textBoxDisplayedValueDBus.ReadOnly = true;
            textBoxDisplayedValueDBus.Location = new Point(DBus.Location.X + DBus.Width + 4, DBus.Location.Y + DBus.Height - textBoxDisplayedValueDBus.Height);

            labelDBus = new Label();
            labelDBus.Text = DBus.BusName;
            labelDBus.Location = new Point(DBus.Location.X + DBus.Width, DBus.Location.Y + DBus.Height - textBoxDisplayedValueDBus.Height - labelDBus.Height);

            DBus.TextBoxDisplayValue = textBoxDisplayedValueDBus;
        }

        private void InitializeRBus()
        {
            RBus = new Bus("RBus");

            var x = (Memory.Location.X + Memory.Size.Width + Locations.ThirdColumn) / 2 - RBus.Width / 2 + 10;
            RBus.Location = new Point(x, 0);

            textBoxDisplayedValueRBus = new TextBox();
            textBoxDisplayedValueRBus.Size = new Size(125, textBoxDisplayedValueRBus.Height);
            textBoxDisplayedValueRBus.TextAlign = HorizontalAlignment.Right;
            textBoxDisplayedValueRBus.ReadOnly = true;
            textBoxDisplayedValueRBus.Location = new Point(RBus.Location.X - 125 - 4, RBus.Location.Y + RBus.Height - textBoxDisplayedValueRBus.Height);

            labelRBus = new Label();
            labelRBus.Text = RBus.BusName;
            labelRBus.Location = new Point(RBus.Location.X - 125, RBus.Location.Y + RBus.Height - textBoxDisplayedValueRBus.Height - labelRBus.Height);

            RBus.TextBoxDisplayValue = textBoxDisplayedValueRBus;
        }

        private void InitializeMpmMemory()
        {
            MpmMemory = new MpmMemory();
        }

        #endregion

        private void InitializeLines()
        {
            InitializeLineFromMemoryAddressRegisterToMemory();
            InitializeLineFromMemoryAddressRegisterToSBus();
            InitializeLineFromMemoryAddressRegisterToDBus();
            InitializeLineFromMemoryAddressRegisterToRBus();

            InitializeLineFromMemoryDataRegisterToMemory();
            InitializeLineFromMemoryDataRegisterToSBus();
            InitializeLineFromMemoryDataRegisterToDBus();
            InitializeLineFromMemoryDataRegisterToRBus();

            InitializeLineFromInstructionRegisterToSBus();
            InitializeLineFromInstructionRegisterToDBus();
            InitializeLineFromInstructionRegisterToRBus();

            InitializeLineFromStackPointerRegisterToSBus();
            InitializeLineFromStackPointerRegisterToDBus();
            InitializeLineFromStackPointerRegisterToRBus();

            InitializeLineFromTemporaryRegisterToSBus();
            InitializeLineFromTemporaryRegisterToDBus();
            InitializeLineFromTemporaryRegisterToRBus();

            InitializeLineFromProgramCounterRegisterToSBus();
            InitializeLineFromProgramCounterRegisterToDBus();
            InitializeLineFromProgramCounterRegisterToRBus();
        }

        #region Lines initialization

        private void InitializeLineFromMemoryAddressRegisterToMemory()
        {
            lineFromMemoryAddressRegisterToMemory = new Line();
            lineFromMemoryAddressRegisterToMemory.Points.Add(new Point(MemoryAddressRegister.Location.X + MemoryAddressRegister.Width / 2, MemoryAddressRegister.Location.Y));
            lineFromMemoryAddressRegisterToMemory.Points.Add(new Point(MemoryAddressRegister.Location.X + MemoryAddressRegister.Width / 2, Memory.Location.Y + Memory.Height));
        }

        private void InitializeLineFromMemoryAddressRegisterToSBus()
        {
            lineFromMemoryAddressRegisterToSBus = new Line();
            lineFromMemoryAddressRegisterToSBus.Points.AddRange(GetLinePointsFromProvidedRegisterToSBus(MemoryAddressRegister));
        }

        private void InitializeLineFromMemoryAddressRegisterToDBus()
        {
            lineFromMemoryAddressRegisterToDBus = new Line();
            lineFromMemoryAddressRegisterToDBus.Points.AddRange(GetLinePointsFromProvidedRegisterToDBus(MemoryAddressRegister));
        }

        private void InitializeLineFromMemoryAddressRegisterToRBus()
        {
            lineFromMemoryAddressRegisterToRBus = new Line();
            lineFromMemoryAddressRegisterToRBus.Points.AddRange(GetLinePointsFromProvidedRegisterToRBus(MemoryAddressRegister));
        }

        private void InitializeLineFromMemoryDataRegisterToMemory()
        {
            lineFromMemoryDataRegisterToMemory = new Line();
            lineFromMemoryDataRegisterToMemory.Points.Add(new Point(MemoryDataRegister.Location.X + MemoryDataRegister.Width / 2 - 20, MemoryDataRegister.Location.Y));
            lineFromMemoryDataRegisterToMemory.Points.Add(new Point(MemoryDataRegister.Location.X + MemoryDataRegister.Width / 2 - 20, Memory.Location.Y + Memory.Height));
        }

        private void InitializeLineFromMemoryDataRegisterToSBus()
        {
            lineFromMemoryDataRegisterToSBus = new Line();
            lineFromMemoryDataRegisterToSBus.Points.AddRange(GetLinePointsFromProvidedRegisterToSBus(MemoryDataRegister));
        }

        private void InitializeLineFromMemoryDataRegisterToDBus()
        {
            lineFromMemoryDataRegisterToDBus = new Line();
            lineFromMemoryDataRegisterToDBus.Points.AddRange(GetLinePointsFromProvidedRegisterToDBus(MemoryDataRegister));
        }

        private void InitializeLineFromMemoryDataRegisterToRBus()
        {
            lineFromMemoryDataRegisterToRBus = new Line();
            lineFromMemoryDataRegisterToRBus.Points.AddRange(GetLinePointsFromProvidedRegisterToRBus(MemoryDataRegister));
        }

        private void InitializeLineFromInstructionRegisterToSBus()
        {
            lineFromInstructionRegisterToSBus = new Line();
            lineFromInstructionRegisterToSBus.Points.AddRange(GetLinePointsFromProvidedRegisterToSBus(InstructionRegister));
        }

        private void InitializeLineFromInstructionRegisterToDBus()
        {
            lineFromInstructionRegisterToDBus = new Line();
            lineFromInstructionRegisterToDBus.Points.AddRange(GetLinePointsFromProvidedRegisterToDBus(InstructionRegister));
        }

        private void InitializeLineFromInstructionRegisterToRBus()
        {
            lineFromInstructionRegisterToRBus = new Line();
            lineFromInstructionRegisterToRBus.Points.AddRange(GetLinePointsFromProvidedRegisterToRBus(InstructionRegister));
        }

        private void InitializeLineFromStackPointerRegisterToSBus()
        {
            lineFromStackPointerRegisterToSBus = new Line();
            lineFromStackPointerRegisterToSBus.Points.AddRange(GetLinePointsFromProvidedRegisterToSBus(StackPointerRegister));
        }

        private void InitializeLineFromStackPointerRegisterToDBus()
        {
            lineFromStackPointerRegisterToDBus = new Line();
            lineFromStackPointerRegisterToDBus.Points.AddRange(GetLinePointsFromProvidedRegisterToDBus(StackPointerRegister));
        }

        private void InitializeLineFromStackPointerRegisterToRBus()
        {
            lineFromStackPointerRegisterToRBus = new Line();
            lineFromStackPointerRegisterToRBus.Points.AddRange(GetLinePointsFromProvidedRegisterToRBus(StackPointerRegister));
        }

        private void InitializeLineFromTemporaryRegisterToSBus()
        {
            lineFromTemporaryRegisterToSBus = new Line();
            lineFromTemporaryRegisterToSBus.Points.AddRange(GetLinePointsFromProvidedRegisterToSBus(TemporaryRegister));
        }

        private void InitializeLineFromTemporaryRegisterToDBus()
        {
            lineFromTemporaryRegisterToDBus = new Line();
            lineFromTemporaryRegisterToDBus.Points.AddRange(GetLinePointsFromProvidedRegisterToDBus(TemporaryRegister));
        }

        private void InitializeLineFromTemporaryRegisterToRBus()
        {
            lineFromTemporaryRegisterToRBus = new Line();
            lineFromTemporaryRegisterToRBus.Points.AddRange(GetLinePointsFromProvidedRegisterToRBus(TemporaryRegister));
        }

        private void InitializeLineFromProgramCounterRegisterToSBus()
        {
            lineFromProgramCounterRegisterToSBus = new Line();
            lineFromProgramCounterRegisterToSBus.Points.AddRange(GetLinePointsFromProvidedRegisterToSBus(ProgramCounterRegister));
        }

        private void InitializeLineFromProgramCounterRegisterToDBus()
        {
            lineFromProgramCounterRegisterToDBus = new Line();
            lineFromProgramCounterRegisterToDBus.Points.AddRange(GetLinePointsFromProvidedRegisterToDBus(ProgramCounterRegister));
        }

        private void InitializeLineFromProgramCounterRegisterToRBus()
        {
            lineFromProgramCounterRegisterToRBus = new Line();
            lineFromProgramCounterRegisterToRBus.Points.AddRange(GetLinePointsFromProvidedRegisterToRBus(ProgramCounterRegister));
        }

        private List<Point> GetLinePointsFromProvidedRegisterToSBus(Register register)
        {
            var points = new List<Point>();

            points.Add(new Point(register.Location.X, register.Location.Y + 4));
            points.Add(new Point(SBus.Location.X, register.Location.Y + 4));

            return points;
        }

        private List<Point> GetLinePointsFromProvidedRegisterToDBus(Register register)
        {
            var points = new List<Point>();

            points.Add(new Point(register.Location.X, register.Location.Y + register.Height - 4));
            points.Add(new Point(DBus.Location.X, register.Location.Y + register.Height - 4));

            return points;
        }

        private List<Point> GetLinePointsFromProvidedRegisterToRBus(Register register)
        {
            var points = new List<Point>();

            points.Add(new Point(register.Location.X, register.Location.Y + register.Height / 2));
            points.Add(new Point(RBus.Location.X, register.Location.Y + register.Height / 2));

            return points;
        }

        #endregion

        private void AddControls()
        {
            Controls.Add(labelStep);

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
            Controls.Add(textBoxDisplayedValueSBus);
            Controls.Add(labelSBus);

            Controls.Add(DBus);
            Controls.Add(textBoxDisplayedValueDBus);
            Controls.Add(labelDBus);

            Controls.Add(RBus);
            Controls.Add(textBoxDisplayedValueRBus);
            Controls.Add(labelRBus);

            Controls.Add(MpmAddressRegister);
            Controls.Add(MpmInstructionRegister);
        }

        private void UpdateValueDisplayModeForControls()
        {
            GeneralRegisters.ValueDisplayMode = ValueDisplayMode;
            MemoryAddressRegister.ValueDisplayMode = ValueDisplayMode;
            MemoryDataRegister.ValueDisplayMode = ValueDisplayMode;
            InstructionRegister.ValueDisplayMode = ValueDisplayMode;
            StackPointerRegister.ValueDisplayMode = ValueDisplayMode;
            TemporaryRegister.ValueDisplayMode = ValueDisplayMode;
            ProgramCounterRegister.ValueDisplayMode = ValueDisplayMode;
            InterruptVectorRegister.ValueDisplayMode = ValueDisplayMode;
            FlagRegister.ValueDisplayMode = ValueDisplayMode;

            SBus.ValueDisplayMode = ValueDisplayMode;
            DBus.ValueDisplayMode = ValueDisplayMode;
            RBus.ValueDisplayMode = ValueDisplayMode;

            MpmAddressRegister.ValueDisplayMode = ValueDisplayMode;
            MpmInstructionRegister.ValueDisplayMode = ValueDisplayMode;
        }

        private void Fetch()
        {
            MpmInstructionRegister.MpmData.Value = MpmMemory[MpmAddressRegister.Data.Value].Value;
        }

        private void Execute()
        {
            var mpmData = MpmInstructionRegister.MpmData;

            #region SBUS Operations

            if (mpmData.SBusOperation == SBusDBusOperations.PD0)
            {
                SBusOperationsMethods.Pd0(this);
            }

            if (mpmData.SBusOperation == SBusDBusOperations.PD1Positive)
            {
                SBusOperationsMethods.Pd1Positive(this);
            }

            if (mpmData.SBusOperation == SBusDBusOperations.PdAdr)
            {
                SBusOperationsMethods.PdAdr(this);
            }

            if (mpmData.SBusOperation == SBusDBusOperations.PdRG)
            {
                SBusOperationsMethods.PdRg(this);
            }

            if (mpmData.SBusOperation == SBusDBusOperations.PdT)
            {
                SBusOperationsMethods.PdT(this);
            }

            if (mpmData.SBusOperation == SBusDBusOperations.PdMdr)
            {
                SBusOperationsMethods.PdMdr(this);
            }

            #endregion

            #region DBUS Operations

            if (mpmData.DBusOperation == SBusDBusOperations.PD0)
            {
                DBusOperationsMethods.Pd0(this);
            }

            if (mpmData.DBusOperation == SBusDBusOperations.PD1Positive)
            {
                DBusOperationsMethods.Pd1Positive(this);
            }

            if (mpmData.DBusOperation == SBusDBusOperations.PdAdr)
            {
                DBusOperationsMethods.PdAdr(this);
            }

            if (mpmData.DBusOperation == SBusDBusOperations.PdRG)
            {
                DBusOperationsMethods.PdRg(this);
            }

            if (mpmData.DBusOperation == SBusDBusOperations.PdT)
            {
                DBusOperationsMethods.PdT(this);
            }

            if (mpmData.DBusOperation == SBusDBusOperations.PdMdr)
            {
                DBusOperationsMethods.PdMdr(this);
            }

            #endregion

            #region ALU Operations

            ArithmeticLogicUnit.Operand1 = SBus.Data;
            ArithmeticLogicUnit.Operand2 = DBus.Data;
            ArithmeticLogicUnit.Operator = mpmData.AluOperator;

            if (ArithmeticLogicUnit.Operator != AluOperator.Undefined)
            {
                ArithmeticLogicUnit.PerformOperation();
                RBus.Data.Value = ArithmeticLogicUnit.Result.Value;
            }
                

            #endregion

            #region RBus Operations

            if (mpmData.RBusOperation == RBusOperations.PmRG)
            {
                RBusOperationsMethods.PmRg(this);
            }

            if (mpmData.RBusOperation == RBusOperations.PmT)
            {
                RBusOperationsMethods.PmT(this);
            }

            if (mpmData.RBusOperation == RBusOperations.PmMdr)
            {
                RBusOperationsMethods.PmMdr(this);
            }

            #endregion

            #region Memory Operations

            if (mpmData.MemoryOperation == MemoryOperations.IfCh)
            {
                InstructionRegister.Data.Value = Memory[ProgramCounterRegister.Data.Value].Value;
            }

            #endregion

            #region OtherOperations

            if (mpmData.OtherOperation == OtherOperations.IncrementPC)
            {
                ProgramCounterRegister.Data.Value++;
            }

            #endregion

            if (mpmData.JumpOperation == JumpOperations.STEP)
            {
                MpmAddressRegister.Data.Value++;

                return;
            }

            if (mpmData.JumpOperation == JumpOperations.JUMP)
            {
                MpmAddressRegister.Data.Value = MpmInstructionRegister.MpmData.JumpLocation;

                return;
            }

            if (mpmData.JumpOperation == JumpOperations.JUMPI)
            {
                MpmAddressRegister.Data.Value = MpmInstructionRegister.MpmData.JumpLocation;

                if (mpmData.JumpIndex == Indexes.Index1)
                {
                    var instructionClass = InstructionValueParser.GetInstructionClass(InstructionRegister.Data.Value);
                    MpmAddressRegister.Data.Value += (ushort)instructionClass;
                }

                if (mpmData.JumpIndex == Indexes.Index2)
                {
                    var addressMode = InstructionValueParser.GetAddressModeSource(InstructionRegister.Data.Value);
                    var index = (ushort)((ushort)addressMode * 2);
                    MpmAddressRegister.Data.Value += index;

                    if (addressMode != AddressMode.Immediate)
                    {
                        SelectedRegister = InstructionValueParser.GetRegisterNumberSourceB1(InstructionRegister.Data.Value);
                    }
                }

                if (mpmData.JumpIndex == Indexes.Index3)
                {
                    var addressMode = InstructionValueParser.GetAddressModeDestination(InstructionRegister.Data.Value);
                    var index = (ushort)((ushort)addressMode * 2);
                    MpmAddressRegister.Data.Value += index;

                    if (addressMode != AddressMode.Immediate)
                    {
                        SelectedRegister = InstructionValueParser.GetRegisterNumberDestinationB1(InstructionRegister.Data.Value);
                    }
                }

                if (mpmData.JumpIndex == Indexes.Index4)
                {
                    var instructionClass = InstructionValueParser.GetInstructionClass(InstructionRegister.Data.Value);
                    var opCode = 0;

                    if (instructionClass == InstructionClass.B1)
                    {
                        opCode = InstructionValueParser.GetInstructionNumberB1(InstructionRegister.Data.Value);
                    }

                    if (instructionClass == InstructionClass.B2)
                    {
                        opCode = InstructionValueParser.GetInstructionNumberB2(InstructionRegister.Data.Value);
                    }

                    if (instructionClass == InstructionClass.B3)
                    {
                        opCode = InstructionValueParser.GetInstructionNumberB3(InstructionRegister.Data.Value);
                    }

                    if (instructionClass == InstructionClass.B4)
                    {
                        opCode = InstructionValueParser.GetInstructionNumberB4(InstructionRegister.Data.Value);
                    }

                    MpmAddressRegister.Data.Value += (ushort)opCode;
                }
            }

            if (mpmData.JumpOperation == JumpOperations.B1)
            {
                if (mpmData.JumpIndex == Indexes.Index4)
                {
                    var instructionClass = InstructionValueParser.GetInstructionClass(InstructionRegister.Data.Value);
                    var offset = 0;

                    if (instructionClass == InstructionClass.B1)
                    {
                        MpmAddressRegister.Data.Value = MpmInstructionRegister.MpmData.JumpLocation;
                        offset = InstructionValueParser.GetInstructionNumberB1(InstructionRegister.Data.Value);
                    }
                    else
                    {
                        offset = 1;
                    }

                    MpmAddressRegister.Data.Value += (ushort)((ushort)offset * 2);

                    return;
                }
            }

            if (mpmData.JumpOperation == JumpOperations.AD)
            {
                var addressMode = InstructionValueParser.GetAddressModeDestination(InstructionRegister.Data.Value);

                if (addressMode == AddressMode.Direct)
                {
                    MpmAddressRegister.Data.Value = 23;
                }
                else
                {
                    MpmAddressRegister.Data.Value++;
                }
            }

            if (mpmData.JumpOperation == JumpOperations.INTR)
            {
                if (!Interrupt)
                {
                    MpmAddressRegister.Data.Value = 0;
                }
            }
        }

        private void EventPaint(object sender, PaintEventArgs e)
        {
            lineFromMemoryAddressRegisterToMemory.Draw(e);
            lineFromMemoryAddressRegisterToSBus.Draw(e);
            lineFromMemoryAddressRegisterToDBus.Draw(e);
            lineFromMemoryAddressRegisterToRBus.Draw(e);

            lineFromMemoryDataRegisterToMemory.Draw(e);
            lineFromMemoryDataRegisterToSBus.Draw(e);
            lineFromMemoryDataRegisterToDBus.Draw(e);
            lineFromMemoryDataRegisterToRBus.Draw(e);

            lineFromInstructionRegisterToSBus.Draw(e);
            lineFromInstructionRegisterToDBus.Draw(e);
            lineFromInstructionRegisterToRBus.Draw(e);

            lineFromStackPointerRegisterToSBus.Draw(e);
            lineFromStackPointerRegisterToDBus.Draw(e);
            lineFromStackPointerRegisterToRBus.Draw(e);

            lineFromTemporaryRegisterToSBus.Draw(e);
            lineFromTemporaryRegisterToDBus.Draw(e);
            lineFromTemporaryRegisterToRBus.Draw(e);

            lineFromProgramCounterRegisterToSBus.Draw(e);
            lineFromProgramCounterRegisterToDBus.Draw(e);
            lineFromProgramCounterRegisterToRBus.Draw(e);
        }
    }
}
