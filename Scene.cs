using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Scene
    {
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public Ball[,] topcinja = new Ball[7, 6];

        public Ball clickedNewBall { get; set; }//momentalnoto topce so go stavame/klikame

        public Scene()
        {
            player1 = new Player();
            player2 = new Player();
           
            Point lokacija = new Point(90,390);
            for(int i = 0; i < 7; i++)
            {

                for (int j = 0; j < 6; j++)
                {
                    Ball b = new Ball(lokacija);
                    topcinja[i, j] = b;

                    lokacija.Y -= 62;
                }
                lokacija.X += 100;
                lokacija.Y = 390;
            }

        }

        public void DrawPlatno(Graphics g)
        {
            Brush b = new SolidBrush(Color.DarkBlue);
            Pen p = new Pen(b);
            Rectangle r = new Rectangle(50, 72, 740, 405);
            g.DrawRectangle(p, r);
            g.FillRectangle(b, r);
            b.Dispose();
            p.Dispose();
        }

        public void DrawAll(Graphics g)
        {
            foreach(Ball b in topcinja)
            {
                b.Draw(g);
            }
        }
    
    }
}
