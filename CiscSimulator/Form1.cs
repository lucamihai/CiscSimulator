using System;
using System.Drawing;
using System.Windows.Forms;
using CiscSimulator.Classes;

namespace CiscSimulator
{
    public partial class Form1 : Form
    {
        private Line testLine1;
        private Line testLine2;
        private Line testLine3;

        public Form1()
        {
            InitializeComponent();

            testLine1 = new Line(new Point(10, 10), new Point(200, 10));
            testLine2 = new Line(new Point(20, 20), new Point(20, 200));
            testLine3 = new Line(new Point(30, 30), new Point(200, 200));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            testLine1.Draw(e);
            testLine2.Draw(e);
            testLine3.Draw(e);
        }

        private void buttonChangeLine1State_Click(object sender, EventArgs e)
        {
            testLine1.Active = !testLine1.Active;
            Refresh();
        }

        private void buttonChangeLine2State_Click(object sender, EventArgs e)
        {
            testLine2.Active = !testLine2.Active;
            Refresh();
        }

        private void buttonChangeLine3State_Click(object sender, EventArgs e)
        {
            testLine3.Active = !testLine3.Active;
            Refresh();
        }
    }
}
