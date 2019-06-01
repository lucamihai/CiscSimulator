using System;
using System.Collections.Generic;
using CiscSimulator.Assembler.Enums;
using CiscSimulator.Assembler.Instructions;
using CiscSimulator.Assembler.Interfaces;

namespace CiscSimulator.Assembler
{
    public class InstructionGenerator
    {
        private List<string> B1InstructionNames;
        private List<string> B2InstructionNames;
        private List<string> B3InstructionNames;
        private List<string> B4InstructionNames;

        private Dictionary<string, byte> B1InstructionNumbers;
        private Dictionary<string, byte> B2InstructionNumbers;
        private Dictionary<string, byte> B3InstructionNumbers;
        private Dictionary<string, byte> B4InstructionNumbers;

        public InstructionGenerator()
        {
            InitializeInstructionNames();
            InitializeInstructionNumbers();
        }

        private void InitializeInstructionNames()
        {
            B1InstructionNames = new List<string>
            {
                "mov", "add", "sub", "cmp", "and", "or", "xor"
            };

            B2InstructionNames = new List<string>
            {
                "clr", "neg", "inc", "dec", "asl", "asr", "lsr", "rol", "ror", "rlc", "rrc", "jmp", "call", "push", "pop"
            };

            B3InstructionNames = new List<string>
            {
                "br", "bne", "beq", "bpl", "bmi", "bcs", "bcc", "bvs", "bvc"
            };

            B4InstructionNames = new List<string>
            {
                "clc", "clv", "clz", "cls", "ccc", "sec", "sev", "sez", "ses", "scc", "nop", "ret", "reti", "halt", "wait", "push pc", "pop pc", "push flag", "pop flag"
            };
        }

        private void InitializeInstructionNumbers()
        {
            B1InstructionNumbers = new Dictionary<string, byte>
            {
                ["mov"] = 0,
                ["add"] = 1,
                ["sub"] = 2,
                ["cmp"] = 3,
                ["and"] = 4,
                ["or"] = 5,
                ["xor"] = 6
            };

            B2InstructionNumbers = new Dictionary<string, byte>
            {
                ["clr"] = 0,
                ["neg"] = 1,
                ["inc"] = 2,
                ["dec"] = 3,
                ["asl"] = 4,
                ["asr"] = 5,
                ["lsr"] = 6,
                ["rol"] = 7,
                ["ror"] = 8,
                ["rlc"] = 9,
                ["rrc"] = 10,
                ["jmp"] = 11,
                ["call"] = 12,
                ["push"] = 13,
                ["pop"] = 14
            };

            B3InstructionNumbers = new Dictionary<string, byte>
            {
                ["br"] = 0,
                ["bne"] = 1,
                ["beq"] = 2,
                ["bpl"] = 3,
                ["bmi"] = 4,
                ["bcs"] = 5,
                ["bcc"] = 6,
                ["bvs"] = 7,
                ["bvc"] = 8
            };

            B4InstructionNumbers = new Dictionary<string, byte>
            {
                ["clc"] = 0,
                ["clv"] = 1,
                ["clz"] = 2,
                ["cls"] = 3,
                ["ccc"] = 4,
                ["sec"] = 5,
                ["sev"] = 6,
                ["sez"] = 7,
                ["ses"] = 8,
                ["scc"] = 9,
                ["nop"] = 10,
                ["ret"] = 11,
                ["reti"] = 12,
                ["halt"] = 13,
                ["wait"] = 14,
                ["push pc"] = 15,
                ["pop pc"] = 16,
                ["push flag"] = 17,
                ["pop flag"] = 18
            };
        }

        public IInstruction GenerateInstructionFromLine(string line)
        {
            var instructionName = line.Split()[0].ToLower();
            var arguments = GetArgumentsFromLine(line);
            var instructionClass = DetermineInstructionClassByInstructionName(instructionName);

            if (instructionClass == InstructionClass.B1)
            {
                return GenerateB1Instruction(instructionName, arguments);
            }

            if (instructionClass == InstructionClass.B2)
            {
                return GenerateB2Instruction(instructionName, arguments);
            }

            if (instructionClass == InstructionClass.B3)
            {
                return GenerateB3Instruction(instructionName, arguments);
            }

            if (instructionClass == InstructionClass.B4)
            {
                return GenerateB4Instruction(instructionName, arguments);
            }

            return null;
        }

        private B1Instruction GenerateB1Instruction(string instructionName, string[] arguments)
        {
            if (arguments.Length != Constants.ExpectedArgumentsForInstructionClassB1)
            {
                throw new ArgumentException(
                    $"Expected {Constants.ExpectedArgumentsForInstructionClassB1} arguments, received {arguments.Length}");
            }

            var destination = arguments[0];
            var source = arguments[1];

            ArgumentAnalyzer.GetInformationFromArgument(
                source, 
                out var sourceAddressMode, 
                out var sourceValue, 
                out var sourceExtendedData
            );

            ArgumentAnalyzer.GetInformationFromArgument(
                destination, 
                out var destinationAddressMode, 
                out var destinationValue, 
                out var destinationExtendedData
            );

            var instruction = new B1Instruction();
            instruction.InstructionNumber = B1InstructionNumbers[instructionName];

            instruction.SourceAddressMode = sourceAddressMode;
            instruction.Source = sourceValue;

            instruction.DestinationAddressMode = destinationAddressMode;
            instruction.Destination = destinationValue;

            instruction.SourceDataExtension = sourceExtendedData;
            instruction.DestinationDataExtension = destinationExtendedData;

            if (instruction.DestinationAddressMode == AddressMode.Immediate)
            {
                throw new InvalidOperationException("Destination cannot be an immediate value");
            }

            return instruction;
        }

        private B2Instruction GenerateB2Instruction(string instructionName, string[] arguments)
        {
            if (arguments.Length != Constants.ExpectedArgumentsForInstructionClassB2)
            {
                throw new ArgumentException(
                    $"Expected {Constants.ExpectedArgumentsForInstructionClassB2} arguments, received {arguments.Length}");
            }

            var argument = arguments[0];
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            var instruction = new B2Instruction();
            instruction.InstructionNumber = B2InstructionNumbers[instructionName];

            instruction.AddressMode = addressMode;
            instruction.Value = value;
            instruction.DataExtension = extendedData;

            return instruction;
        }

        private B3Instruction GenerateB3Instruction(string instructionName, string[] arguments)
        {
            if (arguments.Length != Constants.ExpectedArgumentsForInstructionClassB3)
            {
                throw new ArgumentException(
                    $"Expected {Constants.ExpectedArgumentsForInstructionClassB3} arguments, received {arguments.Length}");
            }

            var argument = arguments[0];
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            var instruction = new B3Instruction();
            instruction.InstructionNumber = B3InstructionNumbers[instructionName];
            instruction.Offset = value.LoByte;
            instruction.DataExtension = extendedData;

            return instruction;
        }

        private B4Instruction GenerateB4Instruction(string instructionName, string[] arguments)
        {
            if (arguments.Length != Constants.ExpectedArgumentsForInstructionClassB4)
            {
                throw new ArgumentException(
                    $"Expected {Constants.ExpectedArgumentsForInstructionClassB4} arguments, received {arguments.Length}");
            }

            var instruction = new B4Instruction();
            instruction.InstructionNumber = B4InstructionNumbers[instructionName];

            return instruction;
        }

        private string[] GetArgumentsFromLine(string line)
        {
            var spaceIndex = line.IndexOf(' ');
            if (spaceIndex < 0)
            {
                return new string[0];
            }
            var argumentsString = line.Substring(spaceIndex + 1);
            var arguments = argumentsString.Split(Constants.ArgumentSeparator);

            for (int index = 0; index < arguments.Length; index++)
            {
                arguments[index] = arguments[index].Trim();
            }

            return arguments;
        }

        private InstructionClass DetermineInstructionClassByInstructionName(string instructionName)
        {
            if (B1InstructionNames.Contains(instructionName))
            {
                return InstructionClass.B1;
            }

            if (B2InstructionNames.Contains(instructionName))
            {
                return InstructionClass.B2;
            }

            if (B3InstructionNames.Contains(instructionName))
            {
                return InstructionClass.B3;
            }

            if (B4InstructionNames.Contains(instructionName))
            {
                return InstructionClass.B4;
            }

            return InstructionClass.NotRecognized;
        }
    }
}
