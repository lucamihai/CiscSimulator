using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CiscSimulator.Common;

namespace CiscSimulator.Memory
{
    public partial class Memory : UserControl
    {
        public Line LineDataIn { get; }
        public Line LineDataOut { get; }
        public Line LineAddress { get; }
        public bool WaitingEnabled { get; set; } = true;

        private Dictionary<ushort, Data> dataDictionary;
        // TODO: Will use LineAddress in order to return data
        public Data Data
        {
            get
            {
                ValidateAddress();
                return dataDictionary[LineAddress.Data.Value];
            }
        }

        private void ValidateAddress()
        {
            if (LineAddress.Data.Value < Constants.MinimumAddress.Value)
            {
                var message =
                    $"{nameof(LineAddress.Data.Value)} shouldn't be smaller than {Constants.MinimumAddress.Value}";
                throw new ArgumentException(message);
            }

            if (LineAddress.Data.Value > Constants.MaximumAddress.Value)
            {
                var message =
                    $"{nameof(LineAddress.Data.Value)} shouldn't be bigger than {Constants.MaximumAddress.Value}";
                throw new ArgumentException(message);
            }
        }

        public Memory(Line lineDataIn, Line lineDataOut, Line lineAddress, bool waitingEnabled = true)
        {
            InitializeComponent();

            LineDataIn = lineDataIn;
            LineDataOut = lineDataOut;
            LineAddress = lineAddress;

            WaitingEnabled = true;

            InitializeDataDictionary();
        }

        private void InitializeDataDictionary()
        {
            dataDictionary = new Dictionary<ushort, Data>();
            for (var i = Constants.MinimumAddress.Value; i <= Constants.MaximumAddress.Value; i++)
            {
                dataDictionary[i] = new Data();
            }
        }

        public void AddDataFromDataInToSpecifiedAddress()
        {
            ValidateAddress();

            LineDataIn.Active = true;
            WaitIfWaitingEnabled();

            LineDataIn.Active = false;
            dataDictionary[LineAddress.Data.Value] = LineDataIn.Data;
            WaitIfWaitingEnabled();
        }

        public void PutDataFromSpecifiedAddressInDataOut()
        {
            ValidateAddress();

            LineDataOut.Active = true;
            LineDataOut.Data = (Data)this.Data.Clone();
            WaitIfWaitingEnabled();
        }

        private void WaitIfWaitingEnabled()
        {
            if (WaitingEnabled)
                System.Threading.Thread.Sleep(Common.Constants.WaitIntervalInMilliseconds);
        }
    }
}
