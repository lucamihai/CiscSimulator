using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assembler.UnitTests
{
    [TestClass]
    public class AssemblerUnitTests
    {
        private Assembler assembler;

        [TestInitialize]
        public void Initialize()
        {
            assembler = new Assembler();;
        }

        [TestMethod]
        public void LinesContainingOnlyCommentsAreRemoved()
        {
            assembler.ParseText(Resources.Text1);

            Assert.AreEqual(3, assembler.LineCount);
        }
    }
}
