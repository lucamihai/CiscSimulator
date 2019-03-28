using System;
using System.Windows.Forms;
using CiscSimulator.Classes;
using Common;

namespace CiscSimulator.UserControls
{
    public partial class Memory : UserControl
    {
        public Line LineDataIn { get; }
        public Line LineDataOut { get; }
        public Line LineAddress { get; }

        public Memory(Line lineDataIn, Line lineDataOut, Line lineAddress)
        {
            InitializeComponent();

            LineDataIn = lineDataIn;
            LineDataOut = lineDataOut;
            LineAddress = lineAddress;
        }

        public void AddDataFromDataInToSpecifiedAddress()
        {
            LineDataIn.Active = !LineDataIn.Active;
            var data = LineDataIn.Data;

            var message = $"Got {data} from DataIn";
            MessageBox.Show(message);
        }

        public void PutDataFromSpecifiedAddressInDataOut()
        {
            LineDataOut.Active = !LineDataOut.Active;
            LineDataOut.Data = GetDataFromAddress();
            MessageBox.Show($"Line data out now has data: {LineDataOut.Data}");
        }

        private Data GetDataFromAddress()
        {
            return new Data {HiByte = 100, LoByte = 101};
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDataFromDataInToSpecifiedAddress();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PutDataFromSpecifiedAddressInDataOut();
        }
    }
}
