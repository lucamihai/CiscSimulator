using System;
using System.Collections.Generic;
using System.Linq;
using CiscSimulator.Assembler.Interfaces;

namespace CiscSimulator.Assembler
{
    public class Assembler
    {
        private readonly InstructionGenerator instructionGenerator;

        public List<string> Lines { get; set; }
        public int LineCount => Lines.Count;
        public List<IInstruction> Instructions { get; set; }

        public Assembler()
        {
            instructionGenerator = new InstructionGenerator();
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
            Instructions = new List<IInstruction>();

            foreach (var line in Lines)
            {
                var instruction = instructionGenerator.GenerateInstructionFromLine(line);
                Instructions.Add(instruction);
            }
        }
    }
}
