using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CiscSimulator.Common;

namespace CiscSimulator.Memory
{
    public partial class Memory : UserControl
    {
        public ushort MinimumAddress { get; }
        public ushort MaximumAddress { get; }

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
            if (address < MinimumAddress)
            {
                var message = $"{nameof(address)} shouldn't be smaller than {MinimumAddress}";
                throw new ArgumentException(message);
            }

            if (address > MaximumAddress)
            {
                var message = $"{nameof(address)} shouldn't be bigger than {MaximumAddress}";
                throw new ArgumentException(message);
            }
        }

        public Memory(ushort minimumAddress, ushort maximumAddress)
        {
            InitializeComponent();
            MinimumAddress = minimumAddress;
            MaximumAddress = maximumAddress;
            ValidateAddressLimits();

            InitializeDataDictionary();
        }

        private void ValidateAddressLimits()
        {
            if (MinimumAddress == MaximumAddress)
            {
                var message = $"{nameof(MinimumAddress)} shouldn't be equal to {nameof(MaximumAddress)}";
                throw new ArgumentException(message);
            }

            if (MinimumAddress > MaximumAddress)
            {
                var message = $"{nameof(MinimumAddress)} shouldn't be smaller than {nameof(MaximumAddress)}";
                throw new ArgumentException(message);
            }
        }

        private void InitializeDataDictionary()
        {
            dataDictionary = new Dictionary<ushort, Data>();
            for (var i = MinimumAddress; i <= MaximumAddress; i++)
            {
                dataDictionary[i] = new Data();
            }
        }
    }
}
