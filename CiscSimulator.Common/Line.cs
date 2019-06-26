using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace CiscSimulator.Common
{
    public class Line
    {
        public Color Color { get; private set; }

        [ExcludeFromCodeCoverage]
        public float Width { get; set; }
        public List<Point> Points { get; private set; }

        public bool Active
        {
            get => Color == Constants.LineActiveColor;
            set => Color = value ? Constants.LineActiveColor : Constants.LineInactiveColor;
        }

        public Line()
        {
            Active = false;
            Points = new List<Point>();
        }

        [ExcludeFromCodeCoverage]
        public void Draw(PaintEventArgs e)
        {
            using (var pen = new Pen(Color))
            {
                pen.Width = Width;
                for (int pointNumber = 0; pointNumber < Points.Count - 1; pointNumber++)
                {
                    var firstPoint = Points[pointNumber];
                    var secondPoint = Points[pointNumber + 1];

                    e.Graphics.DrawLine(pen, firstPoint, secondPoint);
                }
            }
        }
    }
}
