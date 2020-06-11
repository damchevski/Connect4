using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    [Serializable]
    public class Ball
    {
        public Color boja { get; set; }
        public bool active { get; set; }
        public Point lokacija { get; set; }
        public int radius = 55;
        public int igrac { get; set; }
        public Ball(Point lokacija)
        {
            boja = Color.White;
            active = false;
            this.lokacija = lokacija;
            igrac = 0;
        }

        public void Pulse(int x)
        {
            this.radius += x;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(boja);
            Pen p = new Pen(Color.Black, 2);

            g.FillEllipse(b,lokacija.X,lokacija.Y,radius,radius);
            g.DrawEllipse(p, lokacija.X, lokacija.Y, radius,radius);

            b.Dispose();
            p.Dispose();
        }
    }
}
