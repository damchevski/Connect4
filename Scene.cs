using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4
{
    public class Scene
    {
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public int ticks { get; set; }
        public Ball[,] topcinja = new Ball[7, 6];
        public List<Ball> forPulse = new List<Ball>();
        public Scene()
        {
            player1 = new Player(Form1.player1Name,true);
            player2 = new Player(Form1.player2Name,false);

            ticks = 0;

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

            forPulse = new List<Ball>();
        }


        public void pulseAll(int x)
        {
            foreach(Ball b in forPulse)
            {
                b.Pulse(x);
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

        public void AddBall(int kolona,int igrac,int sakanoI)
        { 

            if (igrac == 1)
            {
                topcinja[kolona,sakanoI].igrac = 1;
                topcinja[kolona, sakanoI].boja = Color.Yellow;

                player1.turn = false;
                player2.turn = true;
                
            }
            else if (igrac == 2)
            {
                topcinja[kolona, sakanoI].igrac = 2;
                topcinja[kolona, sakanoI].boja = Color.Red;

                player1.turn = true;
                player2.turn = false;
               
            }

            topcinja[kolona,sakanoI].active = true;

        }

        public bool CheckWin()
        {
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    checkHorizontalno(i, j);
                    bool end = checkWinner();

                    if (end)
                    {
                        return true;
                    }

                    checkVertikalno(i, j);
                    end = checkWinner();

                    if (end)
                    {
                        return true;
                    }

                    checkDijagonalno1(i, j);
                     end = checkWinner();

                    if (end)
                    {
                        return true;
                    }

                    checkDijagonalno2(i, j);
                    end = checkWinner();

                    if (end)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void checkDijagonalno2(int i, int j)
        {
            if (topcinja[i, j].active)
            {
                int brojac = 0;
                if(i+3 <=6 && j+3 <=5)
                {
                    if (topcinja[i, j].igrac == 1)
                    {
                        brojac++;
                        if (topcinja[i + 1, j + 1].igrac == 1)
                            brojac++;
                        if (topcinja[i + 2, j + 2].igrac == 1)
                            brojac++;
                        if (topcinja[i + 3, j + 3].igrac == 1)
                            brojac++;

                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i+1, j+1]);
                            forPulse.Add(topcinja[i+2, j+2]);
                            forPulse.Add(topcinja[i+3, j+3]);
                            forPulse.Add(topcinja[i, j]);

                            player1.daliZavrsil = true;
                            return;
                        }

                    }
                    else if (topcinja[i, j].igrac == 2)
                    {
                        brojac++;
                        if (topcinja[i + 1, j + 1].igrac == 2)
                            brojac++;
                        if (topcinja[i + 2, j + 2].igrac == 2)
                            brojac++;
                        if (topcinja[i + 3, j + 3].igrac == 2)
                            brojac++;

                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i + 1, j + 1]);
                            forPulse.Add(topcinja[i + 2, j + 2]);
                            forPulse.Add(topcinja[i + 3, j + 3]);
                            forPulse.Add(topcinja[i, j]);

                            player2.daliZavrsil = true;
                            return;
                        }
                    }

                }


                brojac = 0;
                if (i - 3 >= 0 && j - 3 >= 0)
                {
                    if (topcinja[i, j].igrac == 1)
                    {
                        brojac++;
                        if (topcinja[i - 1, j - 1].igrac == 1)
                            brojac++;
                        if (topcinja[i - 2, j - 2].igrac == 1)
                            brojac++;
                        if (topcinja[i - 3, j - 3].igrac == 1)
                            brojac++;

                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i - 1, j - 1]);
                            forPulse.Add(topcinja[i - 2, j - 2]);
                            forPulse.Add(topcinja[i - 3, j - 3]);
                            forPulse.Add(topcinja[i, j]);

                            player1.daliZavrsil = true;
                            return;
                        }

                    }
                    else if (topcinja[i, j].igrac == 2)
                    {
                        brojac++;
                        if (topcinja[i - 1, j - 1].igrac == 2)
                            brojac++;
                        if (topcinja[i - 2, j - 2].igrac == 2)
                            brojac++;
                        if (topcinja[i - 3, j - 3].igrac == 2)
                            brojac++;

                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i - 1, j - 1]);
                            forPulse.Add(topcinja[i - 2, j - 2]);
                            forPulse.Add(topcinja[i - 3, j - 3]);
                            forPulse.Add(topcinja[i, j]);

                            player2.daliZavrsil = true;
                            return;
                        }
                    }

                }


            }

        }

        public void checkDijagonalno1(int i, int j)
        {
            if (topcinja[i, j].active)
            {
                int brojac = 0;
                if(i+3 <= 6 && j-3 >= 0)
                {
                    if (topcinja[i, j].igrac == 1)
                    {
                        brojac++;
                        if (topcinja[i+1, j - 1].igrac == 1)
                            brojac++;
                        if (topcinja[i+2, j - 2].igrac == 1)
                            brojac++;
                        if (topcinja[i+3, j - 3].igrac == 1)
                            brojac++;

                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i + 1, j - 1]);
                            forPulse.Add(topcinja[i + 2, j - 2]);
                            forPulse.Add(topcinja[i + 3, j - 3]);
                            forPulse.Add(topcinja[i, j]);

                            player1.daliZavrsil = true;
                            return;
                        }
                    }
                    else if (topcinja[i, j].igrac == 2)
                    {
                        brojac++;
                        if (topcinja[i+1, j - 1].igrac == 2)
                            brojac++;
                        if (topcinja[i+2, j - 2].igrac == 2)
                            brojac++;
                        if (topcinja[i+3, j - 3].igrac == 2)
                            brojac++;

                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i + 1, j - 1]);
                            forPulse.Add(topcinja[i + 2, j - 2]);
                            forPulse.Add(topcinja[i + 3, j - 3]);
                            forPulse.Add(topcinja[i, j]);

                            player2.daliZavrsil = true;
                            return;
                        }
                    }

                }

                brojac = 0;
                if(i-3>=0 && j + 3 <= 5)
                {
                    if (topcinja[i, j].igrac == 1)
                    {
                        brojac++;
                        if (topcinja[i - 1, j + 1].igrac == 1)
                            brojac++;
                        if (topcinja[i - 2, j + 2].igrac == 1)
                            brojac++;
                        if (topcinja[i - 3, j + 3].igrac == 1)
                            brojac++;

                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i - 1, j + 1]);
                            forPulse.Add(topcinja[i - 2, j + 2]);
                            forPulse.Add(topcinja[i - 3, j + 3]);
                            forPulse.Add(topcinja[i, j]);

                            player1.daliZavrsil = true;
                            return;
                        }
                    }
                    else if (topcinja[i, j].igrac == 2)
                    {
                        brojac++;
                        if (topcinja[i - 1, j + 1].igrac == 2)
                            brojac++;
                        if (topcinja[i - 2, j + 2].igrac == 2)
                            brojac++;
                        if (topcinja[i - 3, j + 3].igrac == 2)
                            brojac++;
                        
                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i - 1, j + 1]);
                            forPulse.Add(topcinja[i - 2, j + 2]);
                            forPulse.Add(topcinja[i - 3, j + 3]);
                            forPulse.Add(topcinja[i, j]);

                            player2.daliZavrsil = true;
                            return;
                        }
                    }


                }
            }
        }

        private void checkVertikalno(int i,int j)
        {
            if (topcinja[i, j].active)
            {
                int brojac = 0;
                if (j+3<=5)
                {
                    if (topcinja[i, j].igrac == 1)
                    {
                        brojac++;
                        if (topcinja[i, j + 1].igrac == 1)
                            brojac++;
                        if (topcinja[i, j + 2].igrac == 1)
                            brojac++;
                        if (topcinja[i, j + 3].igrac == 1)
                            brojac++;

                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i , j + 1]);
                            forPulse.Add(topcinja[i , j + 2]);
                            forPulse.Add(topcinja[i , j + 3]);
                            forPulse.Add(topcinja[i, j]);

                            player1.daliZavrsil = true;
                            return;
                        }
                    }
                    else if (topcinja[i, j].igrac == 2)
                    {
                        brojac++;
                        if (topcinja[i, j + 1].igrac == 2)
                            brojac++;
                        if (topcinja[i, j + 2].igrac == 2)
                            brojac++;
                        if (topcinja[i, j + 3].igrac == 2)
                            brojac++;

                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i, j + 1]);
                            forPulse.Add(topcinja[i, j + 2]);
                            forPulse.Add(topcinja[i, j + 3]);
                            forPulse.Add(topcinja[i, j]);

                            player2.daliZavrsil = true;
                            return;
                        }
                    }
                }

                brojac = 0;
                if (j - 3 >= 0)
                {
                    if (topcinja[i, j].igrac == 1)
                    {
                        brojac++;
                        if (topcinja[i, j - 1].igrac == 1)
                            brojac++;
                        if (topcinja[i, j - 2].igrac == 1)
                            brojac++;
                        if (topcinja[i, j - 3].igrac == 1)
                            brojac++;

                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i, j - 1]);
                            forPulse.Add(topcinja[i, j - 2]);
                            forPulse.Add(topcinja[i, j - 3]);
                            forPulse.Add(topcinja[i, j]);

                            player1.daliZavrsil = true;
                            return;
                        }
                    }
                    else if (topcinja[i, j].igrac == 2)
                    {
                        brojac++;
                        if (topcinja[i, j - 1].igrac == 2)
                            brojac++;
                        if (topcinja[i, j - 2].igrac == 2)
                            brojac++;
                        if (topcinja[i, j - 3].igrac == 2)
                            brojac++;

                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i, j - 1]);
                            forPulse.Add(topcinja[i, j - 2]);
                            forPulse.Add(topcinja[i, j - 3]);
                            forPulse.Add(topcinja[i, j]);

                            player2.daliZavrsil = true;
                            return;
                        }
                    }
                }
            }
        }

        private void checkHorizontalno(int i,int j)
        {
            if (topcinja[i, j].active)
            {
                int brojac = 0;
                if (i + 3 <= 5)
                {
                    if (topcinja[i, j].igrac == 1)
                    {
                        brojac++;
                        if (topcinja[i + 1, j].igrac == 1)
                            brojac++;
                        if (topcinja[i + 2, j].igrac == 1)
                            brojac++;
                        if (topcinja[i + 3, j].igrac == 1)
                            brojac++;

                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i+1, j ]);
                            forPulse.Add(topcinja[i+2, j]);
                            forPulse.Add(topcinja[i+3, j]);
                            forPulse.Add(topcinja[i, j]);

                            player1.daliZavrsil = true;
                            return;
                        }

                    }
                    else if (topcinja[i, j].igrac == 2)
                    {
                        brojac++;
                        if (topcinja[i + 1, j].igrac == 2)
                            brojac++;
                        if (topcinja[i + 2, j].igrac == 2)
                            brojac++;
                        if (topcinja[i + 3, j].igrac == 2)
                            brojac++;


                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i + 1, j]);
                            forPulse.Add(topcinja[i + 2, j]);
                            forPulse.Add(topcinja[i + 3, j]);
                            forPulse.Add(topcinja[i, j]);

                            player2.daliZavrsil = true;
                            return;
                        }
                    }
                }

                brojac = 0;
                if (i - 3 >= 0)
                {
                    if (topcinja[i, j].igrac == 1)
                    {
                        brojac++;
                        if (topcinja[i - 1, j].igrac == 1)
                            brojac++;
                        if (topcinja[i - 2, j].igrac == 1)
                            brojac++;
                        if (topcinja[i - 3, j].igrac == 1)
                            brojac++;


                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i - 1, j]);
                            forPulse.Add(topcinja[i - 2, j]);
                            forPulse.Add(topcinja[i - 3, j]);
                            forPulse.Add(topcinja[i, j]);

                            player1.daliZavrsil = true;
                            return;
                        }

                    }
                    else if (topcinja[i, j].igrac == 2)
                    {
                        brojac++;
                        if (topcinja[i - 1, j].igrac == 2)
                            brojac++;
                        if (topcinja[i - 2, j].igrac == 2)
                            brojac++;
                        if (topcinja[i - 3, j].igrac == 2)
                            brojac++;


                        if (brojac == 4)
                        {
                            forPulse.Add(topcinja[i - 1, j]);
                            forPulse.Add(topcinja[i - 2, j]);
                            forPulse.Add(topcinja[i - 3, j]);
                            forPulse.Add(topcinja[i, j]);

                            player2.daliZavrsil = true;
                            return;
                        }
                    }
                }

            }
        }
        public bool checkWinner()
        {
            if (player1.daliZavrsil)
            {
                MessageBox.Show("Победи " + player1.playerName);
                return true;
            }

            if (player2.daliZavrsil)
            {
                MessageBox.Show("Победи " + player2.playerName);
                return true;
            }

            return false;
        }

        public bool checkDraw()
        {
            foreach(Ball b in topcinja)
            {
                if (b.active == true)
                    return false;
            }

            return true;
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
