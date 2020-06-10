using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Ball
    {
        public Color boja { get; set; }
        public bool active { get; set; }
        public Point lokacija { get; set; }
        public int igrac { get; set; }
        public Ball(Point lokacija)
        {
            boja = Color.White;
            active = false;
            this.lokacija = lokacija;
            igrac = 0;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(boja);
            Pen p = new Pen(Color.Black, 2);

            g.FillEllipse(b,lokacija.X,lokacija.Y,55,55);
            g.DrawEllipse(p, lokacija.X, lokacija.Y, 55, 55);

            b.Dispose();
            p.Dispose();
        }
    }
}
