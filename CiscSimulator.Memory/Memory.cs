using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CiscSimulator.Common;

namespace CiscSimulator.Memory
{
    public partial class Memory : UserControl
    {
        private Dictionary<ushort, Data> dataDictionary;
        public Data this[ushort address]
        {
            get
            {
                ValidateAddress(address);
                return dataDictionary[address];
            }
        }

        private void ValidateAddress(ushort address)
        {
            if (address < Constants.MinimumAddress.Value)
            {
                var message = $"{nameof(address)} shouldn't be smaller than {Constants.MinimumAddress.Value}";
                throw new ArgumentException(message);
            }

            if (address > Constants.MaximumAddress.Value)
            {
                var message = $"{nameof(address)} shouldn't be bigger than {Constants.MaximumAddress.Value}";
                throw new ArgumentException(message);
            }
        }

        public Memory()
        {
            InitializeComponent();

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
    }
}
