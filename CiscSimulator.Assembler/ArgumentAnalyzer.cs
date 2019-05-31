using CiscSimulator.Common;

namespace CiscSimulator.Assembler
{
    public static class ArgumentAnalyzer
    {
        public static void GetInformationFromArgument(string argument, out AddressMode addressMode, out byte value, out Data extendedData)
        {
            addressMode = AddressMode.NotRecognized;
            value = 0;
            extendedData = new Data();

            if (int.TryParse(argument, out var immediateValue) && immediateValue >= 0)
            {
                addressMode = AddressMode.Immediate;
                value = (byte)immediateValue;

                return;
            }

            if (argument.StartsWith("r"))
            {
                if (int.TryParse(argument.Substring(1), out var registerNumber))
                {
                    addressMode = AddressMode.Direct;
                    value = (byte)registerNumber;

                    return;
                }
            }

            if (argument.StartsWith("(") && argument.EndsWith(")"))
            {
                var indexOfLastParentheses = argument.Length - 1;
                var stuffBetweenParentheses = Utilities.Slice(argument, 1, indexOfLastParentheses);

                if (stuffBetweenParentheses.StartsWith("r"))
                {
                    if (int.TryParse(stuffBetweenParentheses.Substring(1), out var registerNumber))
                    {
                        addressMode = AddressMode.Indirect;
                        value = (byte) registerNumber;

                        return;
                    }
                }
            }

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
                            return;
                        }

                        var stuffAfterParentheses = argument.Substring(indexOfLastParentheses + 1);
                        if (int.TryParse(stuffAfterParentheses, out var offset))
                        {
                            addressMode = AddressMode.Indexed;
                            value = (byte)registerNumber;
                            extendedData.Value = (ushort)offset;

                            return;
                        }
                    }
                }
            }
        }

    }
}
