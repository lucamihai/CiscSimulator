using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Common.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RegisterUnitTests
    {
        private Register register;

        [TestMethod]
        public void RegisterConstructorSetsDataAsExpectedIfDataIsProvided()
        {
            register = new Register("R0", Constants.Data1);

            Assert.IsTrue(register.Data.Equals(Constants.Data1));
        }

        [TestMethod]
        public void RegisterConstructorSetsDataToMinimumValueIfDataIsNotProvided()
        {
            register = new Register("R0");

            Assert.AreEqual(0, register.Data.Value);
        }

        [TestMethod]
        public void RegisterConstructorSetsValueDisplayModeInitializedToBinary()
        {
            register = new Register("R0");

            Assert.AreEqual(register.ValueDisplayMode, ValueDisplayMode.Binary);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeBinary1()
        {
            register = new Register("R0");
            register.Data.Value = Constants.Value1;
            register.ValueDisplayMode = ValueDisplayMode.Binary;

            Assert.AreEqual(Constants.DisplayedValueBinary1, register.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeBinary2()
        {
            register = new Register("R0");
            register.Data.Value = Constants.Value2;
            register.ValueDisplayMode = ValueDisplayMode.Binary;

            Assert.AreEqual(Constants.DisplayedValueBinary2, register.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeDecimal1()
        {
            register = new Register("R0");
            register.Data.Value = Constants.Value1;
            register.ValueDisplayMode = ValueDisplayMode.Decimal;

            Assert.AreEqual(Constants.DisplayedValueDecimal1, register.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeDecimal2()
        {
            register = new Register("R0");
            register.Data.Value = Constants.Value2;
            register.ValueDisplayMode = ValueDisplayMode.Decimal;

            Assert.AreEqual(Constants.DisplayedValueDecimal2, register.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeHexadecimal1()
        {
            register = new Register("R0");
            register.Data.Value = Constants.Value1;
            register.ValueDisplayMode = ValueDisplayMode.Hexadecimal;

            Assert.AreEqual(Constants.DisplayedValueHexadecimal1, register.DisplayedValue);
        }

        [TestMethod]
        public void ValueDisplayedReturnsExceptedStringForValueDisplayModeHexadecimal2()
        {
            register = new Register("R0");
            register.Data.Value = Constants.Value2;
            register.ValueDisplayMode = ValueDisplayMode.Hexadecimal;

            Assert.AreEqual(Constants.DisplayedValueHexadecimal2, register.DisplayedValue);
        }

        [TestMethod]
        public void ChangingValueDisplayModeWillUpdateDisplayedValue1()
        {
            register = new Register("R0");
            register.Data.Value = Constants.Value1;

            register.ValueDisplayMode = ValueDisplayMode.Binary;
            Assert.AreEqual(Constants.DisplayedValueBinary1, register.DisplayedValue);

            register.ValueDisplayMode = ValueDisplayMode.Decimal;
            Assert.AreEqual(Constants.DisplayedValueDecimal1, register.DisplayedValue);

            register.ValueDisplayMode = ValueDisplayMode.Hexadecimal;
            Assert.AreEqual(Constants.DisplayedValueHexadecimal1, register.DisplayedValue);
        }

        [TestMethod]
        public void ChangingValueDisplayModeWillUpdateDisplayedValue2()
        {
            register = new Register("R0");
            register.Data.Value = Constants.Value2;

            register.ValueDisplayMode = ValueDisplayMode.Binary;
            Assert.AreEqual(Constants.DisplayedValueBinary2, register.DisplayedValue);

            register.ValueDisplayMode = ValueDisplayMode.Decimal;
            Assert.AreEqual(Constants.DisplayedValueDecimal2, register.DisplayedValue);

            register.ValueDisplayMode = ValueDisplayMode.Hexadecimal;
            Assert.AreEqual(Constants.DisplayedValueHexadecimal2, register.DisplayedValue);
        }
    }
}
