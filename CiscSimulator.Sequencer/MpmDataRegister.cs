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

        public MpmData MpmData { get; set; }
        public ValueDisplayMode ValueDisplayMode { get; [ExcludeFromCodeCoverage]set; } = ValueDisplayMode.Binary;

        public MpmDataRegister()
        {
            InitializeComponent();

            MpmData = new MpmData();
            MpmData.OnValueChanged = OnValueChanged;
        }

        [ExcludeFromCodeCoverage]
        private void OnValueChanged()
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
                throw new NotImplementedException();
            }
        }
    }
}
