using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MpmDataRegisterUnitTests
    {
        private MpmDataRegister mpmDataRegister;

        [TestMethod]
        public void BusConstructorSetsMpmDataToMinimumValue()
        {
            mpmDataRegister = new MpmDataRegister();

            Assert.AreEqual(0, mpmDataRegister.MpmData.Value);
        }

        [TestMethod]
        public void BusConstructorSetsValueDisplayModeToBinary()
        {
            mpmDataRegister = new MpmDataRegister();

            Assert.AreEqual(mpmDataRegister.ValueDisplayMode, ValueDisplayMode.Binary);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeBinary1()
        {
            mpmDataRegister = new MpmDataRegister();
            mpmDataRegister.MpmData.Value = Constants.Value1;
            mpmDataRegister.ValueDisplayMode = ValueDisplayMode.Binary;

            Assert.AreEqual(Constants.DisplayedValueBinary1, mpmDataRegister.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeBinary2()
        {
            mpmDataRegister = new MpmDataRegister();
            mpmDataRegister.MpmData.Value = Constants.Value2;
            mpmDataRegister.ValueDisplayMode = ValueDisplayMode.Binary;

            Assert.AreEqual(Constants.DisplayedValueBinary2, mpmDataRegister.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeDecimal1()
        {
            mpmDataRegister = new MpmDataRegister();
            mpmDataRegister.MpmData.Value = Constants.Value1;
            mpmDataRegister.ValueDisplayMode = ValueDisplayMode.Decimal;

            Assert.AreEqual(Constants.DisplayedValueDecimal1, mpmDataRegister.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeDecimal2()
        {
            mpmDataRegister = new MpmDataRegister();
            mpmDataRegister.MpmData.Value = Constants.Value2;
            mpmDataRegister.ValueDisplayMode = ValueDisplayMode.Decimal;

            Assert.AreEqual(Constants.DisplayedValueDecimal2, mpmDataRegister.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeHexadecimal1()
        {
            mpmDataRegister = new MpmDataRegister();
            mpmDataRegister.MpmData.Value = Constants.Value1;
            mpmDataRegister.ValueDisplayMode = ValueDisplayMode.Hexadecimal;

            Assert.AreEqual(Constants.DisplayedValueHexadecimal1, mpmDataRegister.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeHexadecimal2()
        {
            mpmDataRegister = new MpmDataRegister();
            mpmDataRegister.MpmData.Value = Constants.Value2;
            mpmDataRegister.ValueDisplayMode = ValueDisplayMode.Hexadecimal;

            Assert.AreEqual(Constants.DisplayedValueHexadecimal2, mpmDataRegister.DisplayedValue);
        }

        [TestMethod]
        public void ChangingValueDisplayModeWillUpdateDisplayedValue1()
        {
            mpmDataRegister = new MpmDataRegister();
            mpmDataRegister.MpmData.Value = Constants.Value1;

            mpmDataRegister.ValueDisplayMode = ValueDisplayMode.Binary;
            Assert.AreEqual(Constants.DisplayedValueBinary1, mpmDataRegister.DisplayedValue);

            mpmDataRegister.ValueDisplayMode = ValueDisplayMode.Decimal;
            Assert.AreEqual(Constants.DisplayedValueDecimal1, mpmDataRegister.DisplayedValue);

            mpmDataRegister.ValueDisplayMode = ValueDisplayMode.Hexadecimal;
            Assert.AreEqual(Constants.DisplayedValueHexadecimal1, mpmDataRegister.DisplayedValue);
        }

        [TestMethod]
        public void ChangingValueDisplayModeWillUpdateDisplayedValue2()
        {
            mpmDataRegister = new MpmDataRegister();
            mpmDataRegister.MpmData.Value = Constants.Value2;

            mpmDataRegister.ValueDisplayMode = ValueDisplayMode.Binary;
            Assert.AreEqual(Constants.DisplayedValueBinary2, mpmDataRegister.DisplayedValue);

            mpmDataRegister.ValueDisplayMode = ValueDisplayMode.Decimal;
            Assert.AreEqual(Constants.DisplayedValueDecimal2, mpmDataRegister.DisplayedValue);

            mpmDataRegister.ValueDisplayMode = ValueDisplayMode.Hexadecimal;
            Assert.AreEqual(Constants.DisplayedValueHexadecimal2, mpmDataRegister.DisplayedValue);
        }
    }
}
