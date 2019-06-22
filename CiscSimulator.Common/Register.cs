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

        public Data Data { get; set; }
        public ValueDisplayMode ValueDisplayMode { get; [ExcludeFromCodeCoverage]set; } = ValueDisplayMode.Binary;

        public Register(string registerName, Data data = null)
        {
            InitializeComponent();

            RegisterName = registerName;
            Data = data ?? new Data();
            Data.OnValueChanged = OnValueChanged;
        }

        [ExcludeFromCodeCoverage]
        private void OnValueChanged()
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
                throw new NotImplementedException();
            }
        }
    }
}
