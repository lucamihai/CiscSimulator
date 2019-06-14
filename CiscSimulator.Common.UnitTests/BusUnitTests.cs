using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Common.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BusUnitTests
    {
        private Bus bus;

        [TestMethod]
        public void RegisterConstructorSetsDataToMinimumValue()
        {
            bus = new Bus("R0");

            Assert.AreEqual(0, bus.Data.Value);
        }
    }
}
