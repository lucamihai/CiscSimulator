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
            bus = new Bus("R0");

            Assert.AreEqual(0, bus.Data.Value);
        }

        [TestMethod]
        public void BusConstructorSetsValueDisplayModeToBinary()
        {
            bus = new Bus("R0");

            Assert.AreEqual(bus.ValueDisplayMode, ValueDisplayMode.Binary);
        }
    }
}
