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
    }
}
