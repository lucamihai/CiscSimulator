using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace CiscSimulator.Common
{
    public partial class Register : UserControl
    {
        [ExcludeFromCodeCoverage]
        public string RegisterName
        {
            get => labelRegisterName.Text;
            private set => labelRegisterName.Text = value;
        }

        public Data Data { get; set; }

        public Register(string registerName, Data data = null)
        {
            InitializeComponent();

            RegisterName = registerName;
            Data = data ?? Data.LowestData;
            Data.OnValueChanged = OnValueChanged;
        }

        [ExcludeFromCodeCoverage]
        private void OnValueChanged()
        {
            textBoxHiByte.Text = Utilities.GetBinaryStringRepresentation(Data.HiByte);
            textBoxLoByte.Text = Utilities.GetBinaryStringRepresentation(Data.LoByte);
        }
    }
}
