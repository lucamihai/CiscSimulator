using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using CiscSimulator.Common.Enums;

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

        public Data Data { get; }
        public string DisplayedValue => textBoxValue.Text;

        private ValueDisplayMode valueDisplayMode = ValueDisplayMode.Binary;
        public ValueDisplayMode ValueDisplayMode
        {
            get => valueDisplayMode;
            set
            {
                valueDisplayMode = value;
                DisplayValue();
            }
        }

        public Register(string registerName, Data data = null)
        {
            InitializeComponent();

            RegisterName = registerName;
            Data = data ?? new Data();
            Data.OnValueChanged = DisplayValue;
        }

        private void DisplayValue()
        {
            if (ValueDisplayMode == ValueDisplayMode.Binary)
            {
                textBoxValue.Text = Utilities.GetBinaryStringRepresentation(Data.Value, 16);
            }

            if (ValueDisplayMode == ValueDisplayMode.Decimal)
            {
                textBoxValue.Text = Data.Value.ToString();
            }

            if (ValueDisplayMode == ValueDisplayMode.Hexadecimal)
            {
                textBoxValue.Text = $"0x{Convert.ToString(Data.Value, 16).ToUpper()}";
            }
        }
    }
}
