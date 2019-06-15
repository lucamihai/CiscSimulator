using System.Collections.Generic;
using CiscSimulator.Assembler.Enums;
using CiscSimulator.Assembler.Instructions;
using CiscSimulator.Assembler.Interfaces;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler.UnitTests
{
    public static class Resources
    {
        public const string Text1 =
            @"mov r0, r1
and r2, r4 # just a comment
add r2, 2  # just another comment
add (r4), 10
add r2, (r1)10
inc (r2)
# A line containing only a comment";

        public static List<IInstruction> ExpectedInstructionList =>
            new List<IInstruction>
            {
                // mov r0, 41
                new B1Instruction
                {
                    InstructionNumber = 0,
                    Destination = new Data{Value = 0},
                    DestinationAddressMode = AddressMode.Direct,
                    Source = new Data{Value = 1},
                    SourceAddressMode = AddressMode.Direct
                },

                // and r2, r4
                new B1Instruction
                {
                    InstructionNumber = 4,
                    Destination = new Data{Value = 2},
                    DestinationAddressMode = AddressMode.Direct,
                    Source = new Data{Value = 4},
                    SourceAddressMode = AddressMode.Direct
                },

                // add r2, 2
                new B1Instruction
                {
                    InstructionNumber = 1,
                    Destination = new Data{Value = 2},
                    DestinationAddressMode = AddressMode.Direct,
                    Source = new Data{Value = 2},
                    SourceAddressMode = AddressMode.Immediate,
                },

                // add (r4), 10
                new B1Instruction
                {
                    InstructionNumber = 1,
                    Destination = new Data{Value = 4},
                    DestinationAddressMode = AddressMode.Indirect,
                    Source = new Data{Value = 10},
                    SourceAddressMode = AddressMode.Immediate,
                },

                // add r2, (r1)10
                new B1Instruction
                {
                    InstructionNumber = 1,
                    Destination = new Data{Value = 2},
                    DestinationAddressMode = AddressMode.Direct,
                    Source = new Data{Value = 1},
                    SourceAddressMode = AddressMode.Indexed,
                    SourceDataExtension = new Data {Value = 10}
                },

                // inc (r2)
                new B2Instruction
                {
                    InstructionNumber = 2,
                    AddressMode = AddressMode.Indirect,
                    Value = new Data {Value = 2},
                }
            };
    }

}
