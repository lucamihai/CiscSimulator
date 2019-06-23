using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Sequencer.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests.MethodsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MemoryOperationsMethodsUnitTests
    {
        private Sequencer sequencer;

        [TestInitialize]
        public void Setup()
        {
            sequencer = new Sequencer();

            sequencer.Memory[Constants.MemoryAddress1].Value = Constants.MemoryValue1;
            sequencer.Memory[Constants.MemoryAddress2].Value = Constants.MemoryValue2;

            sequencer.Memory[Constants.MemoryInstructionAddress1].Value = Constants.MemoryInstructionValue1;
            sequencer.Memory[Constants.MemoryInstructionAddress2].Value = Constants.MemoryInstructionValue2;
        }

        [TestMethod]
        public void IfChLoadsInstructionRegisterWithValueFoundInMemoryAtProgramCounter1()
        {
            sequencer.ProgramCounterRegister.Data.Value = Constants.MemoryInstructionAddress1;

            MemoryOperationsMethods.IfCh(sequencer);

            Assert.AreEqual(Constants.MemoryInstructionValue1, sequencer.InstructionRegister.Data.Value);
        }

        [TestMethod]
        public void IfChLoadsInstructionRegisterWithValueFoundInMemoryAtProgramCounter2()
        {
            sequencer.ProgramCounterRegister.Data.Value = Constants.MemoryInstructionAddress2;

            MemoryOperationsMethods.IfCh(sequencer);

            Assert.AreEqual(Constants.MemoryInstructionValue2, sequencer.InstructionRegister.Data.Value);
        }

        [TestMethod]
        public void ReadLoadsMemoryDataRegisterWithValueFoundInMemoryAtMemoryAddressRegister1()
        {
            sequencer.MpmAddressRegister.Data.Value = Constants.MemoryAddress1;

            MemoryOperationsMethods.Read(sequencer);

            Assert.AreEqual(Constants.MemoryValue1, sequencer.MemoryDataRegister.Data.Value);
        }

        [TestMethod]
        public void ReadLoadsMemoryDataRegisterWithValueFoundInMemoryAtMemoryAddressRegister2()
        {
            sequencer.MpmAddressRegister.Data.Value = Constants.MemoryAddress2;

            MemoryOperationsMethods.Read(sequencer);

            Assert.AreEqual(Constants.MemoryValue2, sequencer.MemoryDataRegister.Data.Value);
        }

        [TestMethod]
        public void WriteLoadsInMemoryAtMemoryAddressRegisterValueFoundInMemoryDataRegister1()
        {
            sequencer.MpmAddressRegister.Data.Value = Constants.MemoryAddress1;
            sequencer.MemoryDataRegister.Data.Value = Constants.Value1;

            MemoryOperationsMethods.Write(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.Memory[sequencer.MpmAddressRegister.Data.Value].Value);
        }

        [TestMethod]
        public void WriteLoadsInMemoryAtMemoryAddressRegisterValueFoundInMemoryDataRegister2()
        {
            sequencer.MpmAddressRegister.Data.Value = Constants.MemoryAddress2;
            sequencer.MemoryDataRegister.Data.Value = Constants.Value2;

            MemoryOperationsMethods.Write(sequencer);

            Assert.AreEqual(Constants.Value2, sequencer.Memory[sequencer.MpmAddressRegister.Data.Value].Value);
        }
    }
}
