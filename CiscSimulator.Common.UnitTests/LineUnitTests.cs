using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Common.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LineUnitTests
    {
        private Line line;

        [TestInitialize]
        public void Setup()
        {
            line = new Line();
        }

        [TestMethod]
        public void SettingLineToActiveChangesLineColorToActive()
        {
            line.Active = true;

            Assert.AreEqual(Common.Constants.LineActiveColor, line.Color);
        }

        [TestMethod]
        public void SettingLineToInactiveChangesLineColorToInactive()
        {
            line.Active = false;

            Assert.AreEqual(Common.Constants.LineInactiveColor, line.Color);
        }
    }
}
