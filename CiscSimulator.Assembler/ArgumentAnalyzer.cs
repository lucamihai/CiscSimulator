using System;
using CiscSimulator.Assembler.Enums;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler
{
    public static class ArgumentAnalyzer
    {
        public static void GetInformationFromArgument(string argument, out AddressMode addressMode, out Data value, out Data extendedData)
        {
            value = new Data();

            addressMode = AddressMode.NotRecognized;
            value.Value = 0;
            extendedData = new Data();

            if (ushort.TryParse(argument, out var immediateValue) && immediateValue >= 0)
            {
                addressMode = AddressMode.Immediate;
                value.Value = immediateValue;

                return;
            }

            if (argument.StartsWith("r"))
            {
                if (int.TryParse(argument.Substring(1), out var registerNumber))
                {
                    addressMode = AddressMode.Direct;
                    value.Value = (byte)registerNumber;

                    return;
                }
            }

            if (argument.StartsWith("(") && argument.EndsWith(")"))
            {
                var indexOfLastParentheses = argument.Length - 1;
                var stuffBetweenParentheses = argument.Slice(1, indexOfLastParentheses);

                if (stuffBetweenParentheses.StartsWith("r"))
                {
                    if (int.TryParse(stuffBetweenParentheses.Substring(1), out var registerNumber))
                    {
                        addressMode = AddressMode.Indirect;
                        value.Value = (byte) registerNumber;

                        return;
                    }
                }
            }

            if (argument.StartsWith("("))
            {
                var indexOfLastParentheses = argument.LastIndexOf(")", StringComparison.Ordinal);
                if (indexOfLastParentheses == argument.Length - 1)
                {
                    return;
                }

                var stuffBetweenParentheses = argument.Slice(1, indexOfLastParentheses);
                if (stuffBetweenParentheses.StartsWith("r"))
                {
                    if (int.TryParse(stuffBetweenParentheses.Substring(1), out var registerNumber))
                    {
                        var stuffAfterParentheses = argument.Substring(indexOfLastParentheses + 1);
                        if (int.TryParse(stuffAfterParentheses, out var offset))
                        {
                            addressMode = AddressMode.Indexed;
                            value.Value = (byte)registerNumber;
                            extendedData.Value = (ushort)offset;

                            return;
                        }
                    }
                }
            }
        }

    }
}
