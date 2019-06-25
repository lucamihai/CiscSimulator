using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace CiscSimulator.Common
{
    public class Line
    {
        public Color Color { get; private set; }

        [ExcludeFromCodeCoverage]
        public Point FirstPoint { get; private set; }
        [ExcludeFromCodeCoverage]
        public Point SecondPoint { get; private set; }
        [ExcludeFromCodeCoverage]
        public float Width { get; set; }

        public bool Active
        {
            get => Color == Constants.LineActiveColor;
            set => Color = value ? Constants.LineActiveColor : Constants.LineInactiveColor;
        }

        public Line(Point p1, Point p2)
        {
            Active = false;
            FirstPoint = p1;
            SecondPoint = p2;
        }

        [ExcludeFromCodeCoverage]
        public void Draw(PaintEventArgs e)
        {
            using (var pen = new Pen(Color))
            {
                pen.Width = Width;
                e.Graphics.DrawLine(pen, FirstPoint, SecondPoint);
            }
        }
    }
}
