using System.Windows.Forms;

namespace CiscSimulator.Common
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
                textBoxHiByte.Text = Utilities.GetBinaryStringRepresentation(value);
            }
        }

        private byte _LoByte;
        public byte LoByte
        {
            get => _LoByte;
            set
            {
                _LoByte = value;
                textBoxLoByte.Text = Utilities.GetBinaryStringRepresentation(value);
            }
        }

        public Register(string registerName, byte loByte = byte.MinValue, byte hiByte = byte.MinValue)
        {
            InitializeComponent();

            RegisterName = registerName;
            LoByte = loByte;
            HiByte = hiByte;
        }
    }
}
