using System.Drawing;
using System.Windows.Forms;

namespace CiscSimulator.Common
{
    public class Line
    {
        public Color Color { get; private set; }
        public Point FirstPoint { get; private set; }
        public Point SecondPoint { get; private set; }
        public Data Data { get; set; } = new Data();

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

        public void Draw(PaintEventArgs e)
        {
            using (var pen = new Pen(Color))
            {
                e.Graphics.DrawLine(pen, FirstPoint, SecondPoint);
            }
        }
    }
}
