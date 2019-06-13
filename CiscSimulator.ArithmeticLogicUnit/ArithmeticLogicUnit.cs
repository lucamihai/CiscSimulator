using System;
using System.Windows.Forms;
using CiscSimulator.ArithmeticLogicUnit.Enums;
using CiscSimulator.ArithmeticLogicUnit.Operations;
using CiscSimulator.Common;

namespace CiscSimulator.ArithmeticLogicUnit
{
    public partial class ArithmeticLogicUnit : UserControl
    {
        public Data Operand1 { get; set; }
        public Data Operand2 { get; set; }
        public AluOperator Operator { get; set; }
        public Data Result { get; private set; }

        public ArithmeticLogicUnit()
        {
            InitializeComponent();
            Operator = AluOperator.Undefined;
        }

        public void PerformOperation()
        {
            if (Operand1 == null)
            {
                throw new InvalidOperationException($"Can't perform operation if {nameof(Operand1)} is null");
            }

            if (Operand2 == null)
            {
                throw new InvalidOperationException($"Can't perform operation if {nameof(Operand2)} is null");
            }

            if (Operator == AluOperator.Undefined)
            {
                throw new InvalidOperationException($"Can't perform operation if {nameof(Operator)} is undefined");
            }

            Result = new Data();
            switch (Operator)
            {
                case AluOperator.Add:
                    ArithmeticOperations.Add(Result, Operand1, Operand2);
                    break;
                case AluOperator.Subtract:
                    ArithmeticOperations.Subtract(Result, Operand1, Operand2);
                    break;
                case AluOperator.And:
                    BitWiseOperations.And(Result, Operand1, Operand2);
                    break;
                case AluOperator.Or:
                    BitWiseOperations.Or(Result, Operand1, Operand2);
                    break;
                case AluOperator.ExclusiveOr:
                    BitWiseOperations.ExclusiveOr(Result, Operand1, Operand2);
                    break;
                case AluOperator.Negate:
                    BitWiseOperations.Negate(Result, Operand1);
                    break;
                case AluOperator.ArithmeticShiftRight:
                    BitShiftOperations.ArithmeticShiftRight(Result, Operand1, Operand2);
                    break;
                case AluOperator.ArithmeticShiftLeft:
                    BitShiftOperations.ArithmeticShiftLeft(Result, Operand1, Operand2);
                    break;
                case AluOperator.LogicalShiftRight:
                    BitShiftOperations.LogicalShiftRight(Result, Operand1, Operand2);
                    break;
                case AluOperator.LogicalShiftLeft:
                    BitShiftOperations.LogicalShiftLeft(Result, Operand1, Operand2);
                    break;
                case AluOperator.RotateRight:
                    BitShiftOperations.RotateRight(Result, Operand1, Operand2);
                    break;
                case AluOperator.RotateLeft:
                    BitShiftOperations.RotateLeft(Result, Operand1, Operand2);
                    break;
                case AluOperator.RotateRightThroughCarry:
                    BitShiftOperations.RotateRightThroughCarry(Result, Operand1, Operand2);
                    break;
                case AluOperator.RotateLeftThroughCarry:
                    BitShiftOperations.RotateLeftThroughCarry(Result, Operand1, Operand2);
                    break;
            }
        }
    }
}
