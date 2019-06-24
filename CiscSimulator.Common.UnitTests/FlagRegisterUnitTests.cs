using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Common.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FlagRegisterUnitTests
    {
        private FlagRegister flagRegister;

        [TestInitialize]
        public void Setup()
        {
            flagRegister = new FlagRegister();
        }

        [TestMethod]
        public void RegisterNameHasExpectedValue()
        {
            Assert.AreEqual("FLAG", flagRegister.RegisterName);
        }

        [TestMethod]
        public void CarryFlagReturnsTrueIfCarryFlagIsSet()
        {
            flagRegister.Data.Value = 0;
            flagRegister.CarryFlag = true;

            Assert.IsTrue(flagRegister.CarryFlag);
        }

        [TestMethod]
        public void CarryFlagReturnsFalseIfCarryFlagIsReset()
        {
            flagRegister.Data.Value = ushort.MaxValue;
            flagRegister.CarryFlag = false;

            Assert.IsFalse(flagRegister.CarryFlag);
        }

        [TestMethod]
        public void ParityFlagReturnsTrueIfParityFlagIsSet()
        {
            flagRegister.Data.Value = 0;
            flagRegister.ParityFlag = true;

            Assert.IsTrue(flagRegister.ParityFlag);
        }

        [TestMethod]
        public void ParityFlagReturnsFalseIfParityFlagIsReset()
        {
            flagRegister.Data.Value = ushort.MaxValue;
            flagRegister.ParityFlag = false;

            Assert.IsFalse(flagRegister.ParityFlag);
        }

        [TestMethod]
        public void AdjustFlagReturnsTrueIfAdjustFlagIsSet()
        {
            flagRegister.Data.Value = 0;
            flagRegister.AdjustFlag = true;

            Assert.IsTrue(flagRegister.AdjustFlag);
        }

        [TestMethod]
        public void AdjustFlagReturnsFalseIfAdjustFlagIsReset()
        {
            flagRegister.Data.Value = ushort.MaxValue;
            flagRegister.AdjustFlag = false;

            Assert.IsFalse(flagRegister.AdjustFlag);
        }

        [TestMethod]
        public void ZeroFlagReturnsTrueIfZeroFlagIsSet()
        {
            flagRegister.Data.Value = 0;
            flagRegister.ZeroFlag = true;

            Assert.IsTrue(flagRegister.ZeroFlag);
        }

        [TestMethod]
        public void ZeroFlagReturnsFalseIfZeroFlagIsReset()
        {
            flagRegister.Data.Value = ushort.MaxValue;
            flagRegister.ZeroFlag = false;

            Assert.IsFalse(flagRegister.ZeroFlag);
        }

        [TestMethod]
        public void SignFlagReturnsTrueIfSignFlagIsSet()
        {
            flagRegister.Data.Value = 0;
            flagRegister.SignFlag = true;

            Assert.IsTrue(flagRegister.SignFlag);
        }

        [TestMethod]
        public void SignFlagReturnsFalseIfSignFlagIsReset()
        {
            flagRegister.Data.Value = ushort.MaxValue;
            flagRegister.SignFlag = false;

            Assert.IsFalse(flagRegister.SignFlag);
        }

        [TestMethod]
        public void TrapFlagReturnsTrueIfTrapFlagIsSet()
        {
            flagRegister.Data.Value = 0;
            flagRegister.TrapFlag = true;

            Assert.IsTrue(flagRegister.TrapFlag);
        }

        [TestMethod]
        public void TrapFlagReturnsFalseIfTrapFlagIsReset()
        {
            flagRegister.Data.Value = ushort.MaxValue;
            flagRegister.TrapFlag = false;

            Assert.IsFalse(flagRegister.TrapFlag);
        }

        [TestMethod]
        public void InterruptEnableFlagReturnsTrueIfInterruptEnableFlagIsSet()
        {
            flagRegister.Data.Value = 0;
            flagRegister.InterruptEnableFlag = true;

            Assert.IsTrue(flagRegister.InterruptEnableFlag);
        }

        [TestMethod]
        public void InterruptEnableFlagReturnsFalseIfInterruptEnableFlagIsReset()
        {
            flagRegister.Data.Value = ushort.MaxValue;
            flagRegister.InterruptEnableFlag = false;

            Assert.IsFalse(flagRegister.InterruptEnableFlag);
        }

        [TestMethod]
        public void DirectionFlagReturnsTrueIfDirectionFlagIsSet()
        {
            flagRegister.Data.Value = 0;
            flagRegister.DirectionFlag = true;

            Assert.IsTrue(flagRegister.DirectionFlag);
        }

        [TestMethod]
        public void DirectionFlagReturnsFalseIfDirectionFlagIsReset()
        {
            flagRegister.Data.Value = ushort.MaxValue;
            flagRegister.DirectionFlag = false;

            Assert.IsFalse(flagRegister.DirectionFlag);
        }

        [TestMethod]
        public void OverflowFlagReturnsTrueIfOverflowFlagIsSet()
        {
            flagRegister.Data.Value = 0;
            flagRegister.OverflowFlag = true;

            Assert.IsTrue(flagRegister.OverflowFlag);
        }

        [TestMethod]
        public void OverflowFlagReturnsFalseIfOverflowFlagIsReset()
        {
            flagRegister.Data.Value = ushort.MaxValue;
            flagRegister.OverflowFlag = false;

            Assert.IsFalse(flagRegister.OverflowFlag);
        }
    }
}
