using System;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.ArithmeticLogicUnit.Operations;
using CiscSimulator.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.ArithmeticLogicUnit.UnitTests.OperationsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BitShiftOperationsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ArithmeticShiftRightThrowsNotImplementedException()
        {
            var operand1 = Constants.Operand1;
            var operand2 = Constants.Operand2;
            var result = new Data();

            BitShiftOperations.ArithmeticShiftRight(result, operand1, operand2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ArithmeticShiftLeftThrowsNotImplementedException()
        {
            var operand1 = Constants.Operand1;
            var operand2 = Constants.Operand2;
            var result = new Data();

            BitShiftOperations.ArithmeticShiftLeft(result, operand1, operand2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void LogicalShiftRightThrowsNotImplementedException()
        {
            var operand1 = Constants.Operand1;
            var operand2 = Constants.Operand2;
            var result = new Data();

            BitShiftOperations.LogicalShiftRight(result, operand1, operand2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void LogicalShiftLeftThrowsNotImplementedException()
        {
            var operand1 = Constants.Operand1;
            var operand2 = Constants.Operand2;
            var result = new Data();

            BitShiftOperations.LogicalShiftLeft(result, operand1, operand2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void RotateRightThrowsNotImplementedException()
        {
            var operand1 = Constants.Operand1;
            var operand2 = Constants.Operand2;
            var result = new Data();

            BitShiftOperations.RotateRight(result, operand1, operand2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void RotateLeftThrowsNotImplementedException()
        {
            var operand1 = Constants.Operand1;
            var operand2 = Constants.Operand2;
            var result = new Data();

            BitShiftOperations.RotateLeft(result, operand1, operand2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void RotateRightThroughCarryThrowsNotImplementedException()
        {
            var operand1 = Constants.Operand1;
            var operand2 = Constants.Operand2;
            var result = new Data();

            BitShiftOperations.RotateRightThroughCarry(result, operand1, operand2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void RotateLeftThroughCarryThrowsNotImplementedException()
        {
            var operand1 = Constants.Operand1;
            var operand2 = Constants.Operand2;
            var result = new Data();

            BitShiftOperations.RotateLeftThroughCarry(result, operand1, operand2);
        }
    }
}
