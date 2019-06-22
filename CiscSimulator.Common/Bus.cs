﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using CiscSimulator.Common.Enums;

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
        public ValueDisplayMode ValueDisplayMode { get; [ExcludeFromCodeCoverage]set; } = ValueDisplayMode.Binary;

        public Bus(string busName)
        {
            InitializeComponent();

            BusName = busName;
            Data = new Data {OnValueChanged = OnValueChanged};
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
