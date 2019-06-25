using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CiscSimulator.Common;
using CiscSimulator.Common.Enums;

namespace CiscSimulator.GeneralRegisters
{
    public partial class GeneralRegisters : UserControl
    {
        private ValueDisplayMode valueDisplayMode;
        public ValueDisplayMode ValueDisplayMode
        {
            get => valueDisplayMode;
            set
            {
                valueDisplayMode = value;
                foreach (var register in registers)
                {
                    register.ValueDisplayMode = ValueDisplayMode;
                }
            }
        }

        public Register R0 { get; private set; }
        public Register R1 { get; private set; }
        public Register R2 { get; private set; }
        public Register R3 { get; private set; }
        public Register R4 { get; private set; }
        public Register R5 { get; private set; }
        public Register R6 { get; private set; }
        public Register R7 { get; private set; }
        public Register R8 { get; private set; }
        public Register R9 { get; private set; }
        public Register R10 { get; private set; }
        public Register R11 { get; private set; }
        public Register R12 { get; private set; }
        public Register R13 { get; private set; }
        public Register R14 { get; private set; }
        public Register R15 { get; private set; }

        private List<Register> registers;

        public Register this[int registerNumber]
        {
            get
            {
                ValidateRegisterNumber(registerNumber);
                return registers[registerNumber];
            }
        }

        private void ValidateRegisterNumber(int registerNumber)
        {
            if (registerNumber < Constants.MinimumRegisterNumber || registerNumber > Constants.MaximumRegisterNumber)
            {
                throw new ArgumentException($"{nameof(registerNumber)} must be at least 0 and at most 15");
            }
        }

        public GeneralRegisters()
        {
            InitializeComponent();
            InitializeRegisters();
            InitializeRegisterProperties();

            AddRegistersToControls();
        }

        private void InitializeRegisters()
        {
            registers = new List<Register>();
            for (int registerNumber = 0; registerNumber < 16; registerNumber++)
            {
                var register = new Register($"R{registerNumber}");
                register.Location = GetRegisterLocationBasedOnRegisterNumber(registerNumber);

                registers.Add(register);
            }
        }

        private Point GetRegisterLocationBasedOnRegisterNumber(int registerNumber)
        {
            var location = new Point
            {
                X = 0,
                Y = 2 + registerNumber * 24
            };

            return location;
        }

        private void InitializeRegisterProperties()
        {
            R0 = registers[0];
            R1 = registers[1];
            R2 = registers[2];
            R3 = registers[3];
            R4 = registers[4];
            R5 = registers[5];
            R6 = registers[6];
            R7 = registers[7];
            R8 = registers[8];
            R9 = registers[9];
            R10 = registers[10];
            R11 = registers[11];
            R12 = registers[12];
            R13 = registers[13];
            R14 = registers[14];
            R15 = registers[15];
        }

        private void AddRegistersToControls()
        {
            foreach (var register in registers)
            {
                Controls.Add(register);
            }
        }
    }
}
