using CiscSimulator.Common;

namespace CiscSimulator.ArithmeticLogicUnit.Operations
{
    public static class ArithmeticOperations
    {
        public static void Add(Data result, Data operand1, Data operand2)
        {
            result.Value = (ushort)(operand1.Value + operand2.Value);
        }

        public static void Subtract(Data result, Data operand1, Data operand2)
        {
            result.Value = (ushort)(operand1.Value - operand2.Value);
        }
    }
}
