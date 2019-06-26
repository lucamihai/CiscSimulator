using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using CiscSimulator.Common;
using CiscSimulator.Common.Enums;

namespace CiscSimulator.Sequencer
{
    public partial class MpmDataRegister : UserControl
    {
        [ExcludeFromCodeCoverage]
        public string RegisterName
        {
            get => labelRegisterName.Text;
            private set => labelRegisterName.Text = value;
        }

        public MpmData MpmData { get; }
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

        public MpmDataRegister()
        {
            InitializeComponent();

            MpmData = new MpmData();
            MpmData.OnValueChanged = DisplayValue;

            DisplayValue();
        }

        private void DisplayValue()
        {
            if (ValueDisplayMode == ValueDisplayMode.Binary)
            {
                textBoxValue.Text = Utilities.GetBinaryStringRepresentation(MpmData.Value, 39);
            }

            if (ValueDisplayMode == ValueDisplayMode.Decimal)
            {
                textBoxValue.Text = MpmData.Value.ToString();
            }

            if (ValueDisplayMode == ValueDisplayMode.Hexadecimal)
            {
                textBoxValue.Text = $"0x{Convert.ToString(MpmData.Value, 16).ToUpper()}";
            }
        }
    }
}
