using System;
using System.Drawing;
using System.Windows.Forms;

public class FlyingBird : Form
{
    private Timer timer;
    private int birdX;
    private bool wingUp;
    private int cloud1X, cloud2X, cloud3X, cloud4X;
    private int sunX;

    public FlyingBird()
    {
        this.DoubleBuffered = true;
        this.Width = 800;
        this.Height = 600;
        this.Text = "Flying Bird";

        timer = new Timer();
        timer.Interval = 50; // Інтервал оновлення кадру, 20 кадрів на секунду
        timer.Tick += new EventHandler(OnTimerTick);
        timer.Start();

        birdX = 0;
        wingUp = true;
        cloud1X = 100;
        cloud2X = 300;
        cloud3X = 500;
        cloud4X = 700;
        sunX = 700;

        this.Paint += new PaintEventHandler(OnPaint);
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        birdX += 5; // Швидкість руху птаха

        if (birdX > this.Width)
        {
            birdX = -100; // Повертаємо птаха на початок екрану
        }

        // Оновлюємо позиції хмар та сонця разом з птахом
        cloud1X += 2;
        cloud2X += 2;
        cloud3X += 2;
        cloud4X += 2;
        sunX += 2;

        // Якщо хмари та сонце долітають до краю екрану, перемістимо їх знову зліва
        if (cloud1X > this.Width)
            cloud1X = -60;
        if (cloud2X > this.Width)
            cloud2X = -60;
        if (cloud3X > this.Width)
            cloud3X = -60;
        if (cloud4X > this.Width)
            cloud4X = -60;
        if (sunX > this.Width)
            sunX = -60;

        wingUp = !wingUp; // Змінюємо стан крил

        this.Invalidate(); // Викликаємо перерисовку форми
    }

    private void DrawCloud(Graphics g, int x, int y)
    {
        g.FillEllipse(Brushes.White, x, y, 60, 40);
        g.FillEllipse(Brushes.White, x + 20, y - 10, 60, 40);
        g.FillEllipse(Brushes.White, x + 40, y, 60, 40);
    }

    private void OnPaint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        // Блакитне небо
        g.Clear(Color.SkyBlue);

        // Сонце
        g.FillEllipse(Brushes.Yellow, sunX, 50, 80, 80);

        // Хмари
        DrawCloud(g, cloud1X, 100);
        DrawCloud(g, cloud2X, 50);
        DrawCloud(g, cloud3X, 120);
        DrawCloud(g, cloud4X, 80);

        // Тіло птаха
        g.FillEllipse(Brushes.Blue, birdX, 250, 100, 50);

        // Крила птаха
        if (wingUp)
        {
            g.FillPolygon(Brushes.Blue, new Point[] {
                new Point(birdX + 25, 250),
                new Point(birdX + 50, 200),
                new Point(birdX + 75, 250)
            });
        }
        else
        {
            g.FillPolygon(Brushes.Blue, new Point[] {
                new Point(birdX + 25, 300),
                new Point(birdX + 50, 350),
                new Point(birdX + 75, 300)
            });
        }

        // Голова птаха
        g.FillEllipse(Brushes.Yellow, birdX + 75, 247, 45, 45);

        // Очі птаха (по центру голови)
        g.FillEllipse(Brushes.White, birdX + 85, 260, 10, 10); // Ліве око
        g.FillEllipse(Brushes.White, birdX + 105, 260, 10, 10); // Праве око
        g.FillEllipse(Brushes.Black, birdX + 89, 264, 4, 4); // Лівий зіниця
        g.FillEllipse(Brushes.Black, birdX + 109, 264, 4, 4); // Правий зіниця

        // Дзьоб птаха (дотикається голови та направлений у напрямку руху)
        g.FillPolygon(Brushes.Orange, new Point[] {
            new Point(birdX + 115, 267), // Верхній кінець дзьоба
            new Point(birdX + 135, 275), // Кінець дзьоба
            new Point(birdX + 115, 283)  // Нижній кінець дзьоба
        });

        // Червоний хвіст птаха у формі трапеції, повернутий на 90 градусів
        g.FillPolygon(Brushes.Red, new Point[] {
            new Point(birdX, 270),       // Верхній лівий кінець хвоста
            new Point(birdX, 280),       // Нижній лівий кінець хвоста
            new Point(birdX - 30, 290),  // Нижній правий кінець хвоста
            new Point(birdX - 30, 260)   // Верхній правий кінець хвоста
        });
    }

    [STAThread]
    public static void Main()
    {
        Application.Run(new FlyingBird());
    }
}
