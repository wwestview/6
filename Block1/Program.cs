using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShapesDrawing
{
    public class MainForm : Form
    {
        public MainForm()
        {
            this.Text = "Shapes Drawing";
            this.Size = new Size(800, 600);
            this.Paint += new PaintEventHandler(OnPaint);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Малюємо трикутник
            Point[] trianglePoints = { new Point(50, 50), new Point(100, 50), new Point(75, 100) };
            g.DrawPolygon(Pens.Black, trianglePoints);

            // Малюємо квадрат зі сторонами, паралельними осям координат
            Rectangle square = new Rectangle(150, 50, 100, 100);
            g.DrawRectangle(Pens.Black, square);

            // Малюємо еліпс
            Rectangle ellipseRect = new Rectangle(300, 50, 150, 100);
            g.DrawEllipse(Pens.Black, ellipseRect);

            // Малюємо зафарбоване коло
            SolidBrush brush = new SolidBrush(Color.Blue);
            Rectangle circleRect = new Rectangle(500, 50, 100, 100);
            g.FillEllipse(brush, circleRect);
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
