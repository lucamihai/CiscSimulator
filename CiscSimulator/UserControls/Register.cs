using System.Windows.Forms;
using CiscSimulator.Classes;

namespace CiscSimulator.UserControls
{
    public partial class Register : UserControl
    {
        public string RegisterName
        {
            get => labelRegisterName.Text;
            private set => labelRegisterName.Text = value;
        }
        public string Value
        {
            get => textBoxValue.Text;
            set => textBoxValue.Text = value;
        }

        public Register(string registerName, string value = null)
        {
            InitializeComponent();

            RegisterName = registerName;
            if (string.IsNullOrEmpty(value))
            {
                Value = Constants.DefaultRegisterValue;
            }
            else
            {
                Value = value;
            }
        }
    }
}
