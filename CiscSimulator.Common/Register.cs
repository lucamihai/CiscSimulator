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

        private Data _Data;
        public Data Data
        {
            get => _Data;
            set
            {
                _Data = value;
                textBoxHiByte.Text = Utilities.GetBinaryStringRepresentation(_Data.HiByte);
                textBoxLoByte.Text = Utilities.GetBinaryStringRepresentation(_Data.LoByte);
            }
        }

        public Register(string registerName, Data data = null)
        {
            InitializeComponent();

            RegisterName = registerName;
            Data = data != null ? data : Data.LowestData;
        }
    }
}
