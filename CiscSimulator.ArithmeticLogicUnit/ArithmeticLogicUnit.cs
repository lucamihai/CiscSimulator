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
        public Operator Operator { get; set; }
        public Data Result { get; private set; }

        public ArithmeticLogicUnit()
        {
            InitializeComponent();
            Operator = Operator.Undefined;
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

            if (Operator == Operator.Undefined)
            {
                throw new InvalidOperationException($"Can't perform operation if {nameof(Operator)} is undefined");
            }

            Result = new Data();
            switch (Operator)
            {
                case Operator.Add:
                    ArithmeticOperations.Add(Result, Operand1, Operand2);
                    break;
                case Operator.Subtract:
                    ArithmeticOperations.Subtract(Result, Operand1, Operand2);
                    break;
                case Operator.And:
                    BitWiseOperations.And(Result, Operand1, Operand2);
                    break;
                case Operator.Or:
                    BitWiseOperations.Or(Result, Operand1, Operand2);
                    break;
                case Operator.ExclusiveOr:
                    BitWiseOperations.ExclusiveOr(Result, Operand1, Operand2);
                    break;
                case Operator.Negate:
                    BitWiseOperations.Negate(Result, Operand1);
                    break;
                case Operator.ArithmeticShiftRight:
                    BitShiftOperations.ArithmeticShiftRight(Result, Operand1, Operand2);
                    break;
                case Operator.ArithmeticShiftLeft:
                    BitShiftOperations.ArithmeticShiftLeft(Result, Operand1, Operand2);
                    break;
                case Operator.LogicalShiftRight:
                    BitShiftOperations.LogicalShiftRight(Result, Operand1, Operand2);
                    break;
                case Operator.LogicalShiftLeft:
                    BitShiftOperations.LogicalShiftLeft(Result, Operand1, Operand2);
                    break;
                case Operator.RotateRight:
                    BitShiftOperations.RotateRight(Result, Operand1, Operand2);
                    break;
                case Operator.RotateLeft:
                    BitShiftOperations.RotateLeft(Result, Operand1, Operand2);
                    break;
                case Operator.RotateRightThroughCarry:
                    BitShiftOperations.RotateRightThroughCarry(Result, Operand1, Operand2);
                    break;
                case Operator.RotateLeftThroughCarry:
                    BitShiftOperations.RotateLeftThroughCarry(Result, Operand1, Operand2);
                    break;
            }
        }
    }
}
