using System;
using System.Drawing;
using System.Windows.Forms;

namespace HouseDrawing
{
    public class MainForm : Form
    {
        public MainForm()
        {
            this.Text = "House Drawing";
            this.Size = new Size(800, 600);
            this.Paint += new PaintEventHandler(OnPaint);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Малюємо основну частину будинку
            Rectangle houseBody = new Rectangle(200, 300, 400, 200);
            g.FillRectangle(Brushes.LightGray, houseBody);
            g.DrawRectangle(Pens.Black, houseBody);

            // Малюємо дах будинку
            Point[] roofPoints = {
                new Point(200, 300),
                new Point(400, 150),
                new Point(600, 300)
            };
            g.FillPolygon(Brushes.Brown, roofPoints);
            g.DrawPolygon(Pens.Black, roofPoints);

            // Малюємо двері
            Rectangle door = new Rectangle(370, 400, 60, 100);
            g.FillRectangle(Brushes.Brown, door);
            g.DrawRectangle(Pens.Black, door);

            // Малюємо вікна
            Rectangle leftWindow = new Rectangle(250, 350, 70, 50);
            Rectangle rightWindow = new Rectangle(480, 350, 70, 50);
            g.FillRectangle(Brushes.White, leftWindow);
            g.DrawRectangle(Pens.Black, leftWindow);
            g.FillRectangle(Brushes.White, rightWindow);
            g.DrawRectangle(Pens.Black, rightWindow);

            // Малюємо віконні рами
            g.DrawLine(Pens.Black, 250, 375, 320, 375);
            g.DrawLine(Pens.Black, 285, 350, 285, 400);
            g.DrawLine(Pens.Black, 480, 375, 550, 375);
            g.DrawLine(Pens.Black, 515, 350, 515, 400);
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
