using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Sequencer.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests.MethodsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class OtherOperationsMethodsUnitTests
    {
        private Sequencer sequencer;

        [TestInitialize]
        public void Setup()
        {
            sequencer = new Sequencer();
            sequencer.ProgramCounterRegister.Data.Value = 10;
            sequencer.StackPointerRegister.Data.Value = 10;
        }

        [TestMethod]
        public void IncrementPcIncrementsProgramCounterRegisterValue()
        {
            var valueBeforeIncrement = sequencer.ProgramCounterRegister.Data.Value;

            OtherOperationsMethods.IncrementPc(sequencer);

            Assert.IsTrue(sequencer.ProgramCounterRegister.Data.Value == valueBeforeIncrement + 1);
        }

        [TestMethod]
        public void IncrementSpIncrementsStackPointerRegisterValue()
        {
            var valueBeforeIncrement = sequencer.StackPointerRegister.Data.Value;

            OtherOperationsMethods.IncrementSp(sequencer);

            Assert.IsTrue(sequencer.StackPointerRegister.Data.Value == valueBeforeIncrement + 1);
        }

        [TestMethod]
        public void DecrementSpDecrementsStackPointerRegisterValue()
        {
            var valueBeforeDecrement = sequencer.StackPointerRegister.Data.Value;

            OtherOperationsMethods.DecrementSp(sequencer);

            Assert.IsTrue(sequencer.StackPointerRegister.Data.Value == valueBeforeDecrement - 1);
        }
    }
}
