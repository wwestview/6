using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovingCircle
{
    public partial class MainForm : Form
    {
        private Timer timer;
        private int circleX;
        private int circleY;
        private int circleRadius;
        private Color circleColor;

        public MainForm()
        {
            InitializeCircle();
            SetTimer();
        }

        private void InitializeCircle()
        {
            Random random = new Random();
            circleRadius = random.Next(10, 50); // Випадковий радіус кола від 10 до 50
            circleX = 0;
            circleY = random.Next(0, ClientSize.Height - circleRadius); // Випадкова координата y в межах висоти вікна
            circleColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)); // Випадковий колір
        }

        private void SetTimer()
        {
            timer = new Timer();
            timer.Interval = 10; // Інтервал оновлення таймера (в мілісекундах)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            circleX += 10; // Переміщення кола вправо на 1 піксель

            if (circleX > ClientSize.Width) // Перевірка чи коло не вийшло за межі екрана справа
            {
                InitializeCircle(); // Якщо так, ініціалізуємо нове коло
            }

            Invalidate(); // Перемалювання вікна
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            Brush brush = new SolidBrush(circleColor);
            graphics.FillEllipse(brush, circleX, circleY, circleRadius * 2, circleRadius * 2); // Малюємо коло
        }

        [STAThread]
       public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
