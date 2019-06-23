using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Common.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BusUnitTests
    {
        private Bus bus;

        [TestMethod]
        public void BusConstructorSetsDataToMinimumValue()
        {
            bus = new Bus("SBus");

            Assert.AreEqual(0, bus.Data.Value);
        }

        [TestMethod]
        public void BusConstructorSetsValueDisplayModeToBinary()
        {
            bus = new Bus("SBus");

            Assert.AreEqual(bus.ValueDisplayMode, ValueDisplayMode.Binary);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeBinary1()
        {
            bus = new Bus("SBus");
            bus.Data.Value = Constants.Value1;
            bus.ValueDisplayMode = ValueDisplayMode.Binary;

            Assert.AreEqual(Constants.DisplayedValueBinary1, bus.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeBinary2()
        {
            bus = new Bus("SBus");
            bus.Data.Value = Constants.Value2;
            bus.ValueDisplayMode = ValueDisplayMode.Binary;

            Assert.AreEqual(Constants.DisplayedValueBinary2, bus.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeDecimal1()
        {
            bus = new Bus("SBus");
            bus.Data.Value = Constants.Value1;
            bus.ValueDisplayMode = ValueDisplayMode.Decimal;

            Assert.AreEqual(Constants.DisplayedValueDecimal1, bus.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeDecimal2()
        {
            bus = new Bus("SBus");
            bus.Data.Value = Constants.Value2;
            bus.ValueDisplayMode = ValueDisplayMode.Decimal;

            Assert.AreEqual(Constants.DisplayedValueDecimal2, bus.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeHexadecimal1()
        {
            bus = new Bus("SBus");
            bus.Data.Value = Constants.Value1;
            bus.ValueDisplayMode = ValueDisplayMode.Hexadecimal;

            Assert.AreEqual(Constants.DisplayedValueHexadecimal1, bus.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeHexadecimal2()
        {
            bus = new Bus("SBus");
            bus.Data.Value = Constants.Value2;
            bus.ValueDisplayMode = ValueDisplayMode.Hexadecimal;

            Assert.AreEqual(Constants.DisplayedValueHexadecimal2, bus.DisplayedValue);
        }

        [TestMethod]
        public void ChangingValueDisplayModeWillUpdateDisplayedValue1()
        {
            bus = new Bus("SBus");
            bus.Data.Value = Constants.Value1;

            bus.ValueDisplayMode = ValueDisplayMode.Binary;
            Assert.AreEqual(Constants.DisplayedValueBinary1, bus.DisplayedValue);

            bus.ValueDisplayMode = ValueDisplayMode.Decimal;
            Assert.AreEqual(Constants.DisplayedValueDecimal1, bus.DisplayedValue);

            bus.ValueDisplayMode = ValueDisplayMode.Hexadecimal;
            Assert.AreEqual(Constants.DisplayedValueHexadecimal1, bus.DisplayedValue);
        }

        [TestMethod]
        public void ChangingValueDisplayModeWillUpdateDisplayedValue2()
        {
            bus = new Bus("SBus");
            bus.Data.Value = Constants.Value2;

            bus.ValueDisplayMode = ValueDisplayMode.Binary;
            Assert.AreEqual(Constants.DisplayedValueBinary2, bus.DisplayedValue);

            bus.ValueDisplayMode = ValueDisplayMode.Decimal;
            Assert.AreEqual(Constants.DisplayedValueDecimal2, bus.DisplayedValue);

            bus.ValueDisplayMode = ValueDisplayMode.Hexadecimal;
            Assert.AreEqual(Constants.DisplayedValueHexadecimal2, bus.DisplayedValue);
        }
    }
}
