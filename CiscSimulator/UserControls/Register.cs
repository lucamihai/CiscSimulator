using System;
using System.Windows.Forms;

namespace CiscSimulator.UserControls
{
    public partial class Register : UserControl
    {
        public string RegisterName
        {
            get => labelRegisterName.Text;
            private set => labelRegisterName.Text = value;
        }

        private byte _HiByte;
        public byte HiByte
        {
            get => _HiByte;
            set
            {
                _HiByte = value;
                textBoxHiByte.Text = GetBinaryStringRepresentation(value);
            }
        }

        private byte _LoByte;
        public byte LoByte
        {
            get => _LoByte;
            set
            {
                _LoByte = value;
                textBoxLoByte.Text = GetBinaryStringRepresentation(value);
            }
        }

        public Register(string registerName, byte loByte = byte.MinValue, byte hiByte = byte.MinValue)
        {
            InitializeComponent();

            RegisterName = registerName;
            LoByte = loByte;
            HiByte = hiByte;
        }

        private string GetBinaryStringRepresentation(byte value)
        {
            return Convert.ToString(value, 2).PadLeft(8, '0');
        }
    }
}
