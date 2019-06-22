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
    }
}
