using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace CiscSimulator.Common
{
    public partial class Bus : UserControl
    {
        [ExcludeFromCodeCoverage]
        public string BusName
        {
            get => labelBusName.Text;
            private set => labelBusName.Text = value;
        }

        public Data Data { get; set; }

        public Bus(string busName)
        {
            InitializeComponent();

            BusName = busName;
            Data = new Data {OnValueChanged = OnValueChanged};
        }

        [ExcludeFromCodeCoverage]
        private void OnValueChanged()
        {
            textBoxHiByte.Text = Utilities.GetBinaryStringRepresentation(Data.HiByte);
            textBoxLoByte.Text = Utilities.GetBinaryStringRepresentation(Data.LoByte);
        }
    }
}
