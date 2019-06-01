using CiscSimulator.Common;

namespace CiscSimulator.ArithmeticLogicUnit.Operations
{
    public static class BitWiseOperations
    {
        public static void And(Data result, Data operand1, Data operand2)
        {
            result.Value = (ushort)(operand1.Value & operand2.Value);
        }

        public static void Or(Data result, Data operand1, Data operand2)
        {
            result.Value = (ushort)(operand1.Value | operand2.Value);
        }

        public static void ExclusiveOr(Data result, Data operand1, Data operand2)
        {
            result.Value = (ushort)(operand1.Value ^ operand2.Value);
        }
    }
}
