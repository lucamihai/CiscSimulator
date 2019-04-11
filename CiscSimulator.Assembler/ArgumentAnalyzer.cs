using CiscSimulator.Common;

namespace CiscSimulator.Assembler
{
    public static class ArgumentAnalyzer
    {
        public static AddressMode GetAddressModeBasedOnArgument(string argument)
        {
            if (ArgumentHasAddressModeImmediate(argument))
            {
                return AddressMode.Immediate;
            }

            if (ArgumentHasAddressModeDirect(argument))
            {
                return AddressMode.Direct;
            }

            if (ArgumentHasAddressModeIndirect(argument))
            {
                return AddressMode.Indirect;
            }

            if (ArgumentHasAddressModeIndexed(argument))
            {
                return AddressMode.Indexed;
            }

            return AddressMode.NotRecognized;
        }

        private static bool ArgumentHasAddressModeImmediate(string argument)
        {
            return int.TryParse(argument, out var immediateValue) && immediateValue >= 0;
        }

        private static bool ArgumentHasAddressModeDirect(string argument)
        {
            if (argument.StartsWith("r"))
            {
                if (int.TryParse(argument.Substring(1), out var registerNumber))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ArgumentHasAddressModeIndirect(string argument)
        {
            if (argument.StartsWith("(") && argument.EndsWith(")"))
            {
                var indexOfLastParentheses = argument.Length - 1;
                var stuffBetweenParentheses = Utilities.Slice(argument, 1, indexOfLastParentheses);

                if (stuffBetweenParentheses.StartsWith("r"))
                {
                    if (int.TryParse(stuffBetweenParentheses.Substring(1), out var registerNumber))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool ArgumentHasAddressModeIndexed(string argument)
        {
            if (argument.StartsWith("("))
            {
                var indexOfLastParentheses = argument.LastIndexOf(")");
                var stuffBetweenParentheses = Utilities.Slice(argument, 1, indexOfLastParentheses);

                if (stuffBetweenParentheses.StartsWith("r"))
                {
                    if (int.TryParse(stuffBetweenParentheses.Substring(1), out var registerNumber))
                    {
                        if (indexOfLastParentheses == argument.Length - 1)
                        {
                            return false;
                        }

                        var stuffAfterParentheses = argument.Substring(indexOfLastParentheses + 1);
                        if (int.TryParse(stuffAfterParentheses, out var value))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
