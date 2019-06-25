using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using CiscSimulator.Common.Enums;

namespace CiscSimulator.Common
{
    public partial class Bus : UserControl
    {
        [ExcludeFromCodeCoverage]
        public string BusName { get; private set; }

        public Data Data { get; }
        public string DisplayedValue => TextBoxDisplayValue.Text;

        private TextBox textBoxDisplayValue;
        public TextBox TextBoxDisplayValue
        {
            get => textBoxDisplayValue;
            set
            {
                textBoxDisplayValue = value;

                if (textBoxDisplayValue != null)
                    DisplayValue();
            }
        }

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

        public Bus(string busName, TextBox textBoxDisplayValue = null)
        {
            InitializeComponent();
            BusName = busName;

            Data = new Data { OnValueChanged = DisplayValue };

            this.TextBoxDisplayValue = textBoxDisplayValue != null
                ? textBoxDisplayValue
                : new TextBox();
        }

        private void DisplayValue()
        {
            if (ValueDisplayMode == ValueDisplayMode.Binary)
            {
                TextBoxDisplayValue.Text = Utilities.GetBinaryStringRepresentation(Data.Value, 16);
            }

            if (ValueDisplayMode == ValueDisplayMode.Decimal)
            {
                TextBoxDisplayValue.Text = Data.Value.ToString();
            }

            if (ValueDisplayMode == ValueDisplayMode.Hexadecimal)
            {
                TextBoxDisplayValue.Text = $"0x{Convert.ToString(Data.Value, 16).ToUpper()}";
            }
        }
    }
}
