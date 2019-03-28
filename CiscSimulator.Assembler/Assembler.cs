using System;
using System.Collections.Generic;
using System.Linq;

namespace CiscSimulator.Assembler
{
    public class Assembler
    {
        public List<string> Lines { get; set; } = new List<string>();
        public int LineCount => Lines.Count;

        public void ParseText(string text)
        {
            ValidateText(text);

            Lines = SplitTextByNewline(text).ToList();
            RemoveCommentsFromLines();
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
                if (line.Contains(Constants.CommentMarker))
                {
                    var indexOfCommentMarker = line.IndexOf(Constants.CommentMarker);
                    lineToInsert = line.Remove(indexOfCommentMarker);
                }

                linesAfterCommentRemoval.Add(lineToInsert);
            }

            Lines = linesAfterCommentRemoval;
        }
    }
}
