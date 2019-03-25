using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CiscSimulator.UserControls
{
    public partial class GeneralRegisters : UserControl
    {
        public Register R1 { get; set; }
        public Register R2 { get; set; }
        public Register R3 { get; set; }
        public Register R4 { get; set; }
        public Register R5 { get; set; }
        public Register R6 { get; set; }
        public Register R7 { get; set; }
        public Register R8 { get; set; }
        public Register R9 { get; set; }
        public Register R10 { get; set; }
        public Register R11 { get; set; }
        public Register R12 { get; set; }
        public Register R13 { get; set; }
        public Register R14 { get; set; }
        public Register R15 { get; set; }
        public Register R16 { get; set; }

        private List<Register> registers;

        public GeneralRegisters()
        {
            InitializeComponent();
            InitializeRegisters();
            InitializeProperties();

            AddRegistersToControls();
        }

        private void InitializeRegisters()
        {
            registers = new List<Register>();
            for (int registerNumber = 1; registerNumber <= 16; registerNumber++)
            {
                var register = new Register($"R{registerNumber}");
                register.Location = GetRegisterLocationBasedOnRegisterNumber(registerNumber);
                registers.Add(register);
            }
        }

        private Point GetRegisterLocationBasedOnRegisterNumber(int registerNumber)
        {
            var location = new Point();
            location.X = 0;
            location.Y = (registerNumber - 1) * 25;

            return location;
        }

        private void AddRegistersToControls()
        {
            foreach (var register in registers)
            {
                Controls.Add(register);
            }
        }

        private void InitializeProperties()
        {
            R1 = registers[0];
            R2 = registers[1];
            R3 = registers[2];
            R4 = registers[3];
            R5 = registers[4];
            R6 = registers[5];
            R7 = registers[6];
            R8 = registers[7];
            R9 = registers[8];
            R10 = registers[9];
            R11 = registers[10];
            R12 = registers[11];
            R13 = registers[12];
            R14 = registers[13];
            R15 = registers[14];
            R16 = registers[15];
        }
    }
}
