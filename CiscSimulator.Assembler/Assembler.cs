using System;
using System.Collections.Generic;
using System.Linq;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler
{
    public class Assembler
    {
        public List<string> Lines { get; set; }
        public int LineCount => Lines.Count;
        public List<Instruction> Instructions { get; set; }

        private List<string> B1InstructionNames;
        private List<string> B2InstructionNames;
        private List<string> B3InstructionNames;
        private List<string> B4InstructionNames;

        private Dictionary<string, byte> B1InstructionNumbers;
        private Dictionary<string, byte> B2InstructionNumbers;
        private Dictionary<string, byte> B3InstructionNumbers;
        private Dictionary<string, byte> B4InstructionNumbers;

        public Assembler()
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

        public void ParseText(string text)
        {
            ValidateText(text);

            Lines = SplitTextByNewline(text).ToList();
            RemoveCommentsFromLines();
            GenerateInstructions();
        }

        private void ValidateText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Provided text shouldn't be null or empty");
            }
        }

        private string[] SplitTextByNewline(string text)
        {
            return text.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );
        }

        private void RemoveCommentsFromLines()
        {
            var linesAfterCommentRemoval = new List<string>();
            foreach (var line in Lines)
            {
                if (line.StartsWith(Constants.CommentMarker))
                {
                    continue;
                }

                var lineToInsert = line;
                if (lineToInsert.Contains(Constants.CommentMarker))
                {
                    var indexOfCommentMarker = lineToInsert.IndexOf(Constants.CommentMarker);
                    lineToInsert = lineToInsert.Remove(indexOfCommentMarker);
                }

                linesAfterCommentRemoval.Add(lineToInsert);
            }

            Lines = linesAfterCommentRemoval;
        }

        private void GenerateInstructions()
        {
            Instructions = new List<Instruction>();

            foreach (var line in Lines)
            {
                var instruction = GenerateInstructionFromLine(line);
                Instructions.Add(instruction);
            }
        }

        private Instruction GenerateInstructionFromLine(string line)
        {
            var instructionName = line.Split()[0].ToLower();
            var arguments = GetArgumentsFromLine(line);
            var instructionClass = DetermineInstructionClassByInstructionName(instructionName);
            
            if (instructionClass == InstructionClass.B1)
            {
                if (arguments.Length != Constants.ExpectedArgumentsForInstructionClassB1)
                {
                    throw new Exception(
                        $"Expected {Constants.ExpectedArgumentsForInstructionClassB1} arguments, received {arguments.Length}");
                }

                var destination = arguments[0];
                var source = arguments[1];

                var instruction = new B1Instruction();
                instruction.InstructionNumber = B1InstructionNumbers[instructionName];
                instruction.SourceAddressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(source);
                instruction.DestinationAddressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(destination);

                if (instruction.SourceAddressMode == AddressMode.Immediate)
                {
                    if (int.TryParse(source, out var value))
                    {
                        instruction.Source = (byte) value;
                    }
                }

                if (instruction.SourceAddressMode == AddressMode.Direct)
                {
                    if (int.TryParse(source.Substring(1), out var registerNumber))
                    {
                        instruction.Source = (byte) registerNumber;
                    }
                }

                if (instruction.DestinationAddressMode == AddressMode.Immediate)
                {
                    throw new Exception("Destination cannot be an immediate value");
                }

                if (instruction.DestinationAddressMode == AddressMode.Direct)
                {
                    if (int.TryParse(destination.Substring(1), out var registerNumber))
                    {
                        instruction.Destination = (byte)registerNumber;
                    }
                }

                return instruction;
            }

            return null;
        }

        private string[] GetArgumentsFromLine(string line)
        {
            var spaceIndex = line.IndexOf(' ');
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
