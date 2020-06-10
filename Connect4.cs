using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4
{
    public partial class Connect4 : Form
    {
        Scene scena = new Scene();
        public Connect4()
        {
            InitializeComponent();
        }

        private void Connect4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > 70 && e.X < 160)
            {
                MessageBox.Show("PRVA KOLONA");
                this.scena.clickedNewBall = new Ball(new Point(e.X, e.X));//new
                this.scena.clickedNewBall.pozicijaNaKolonaIliJod = 0;
            }  
            else if (e.X > 170 && e.X < 260)
            {
                MessageBox.Show("VTORA KOLONA");
                this.scena.clickedNewBall = new Ball(new Point(e.X, e.X));//new
                this.scena.clickedNewBall.pozicijaNaKolonaIliJod = 1;
                //znaci pocnujme od najdolnoto topce belo, i gledame vo pozicijaNaKolonaIliJod kolonata, ako
                // imame slobodno topce najdole go stavame odma novoto kreirano topce za toj player (ke tr da se update kaj soodvetniot PLAYER).
                //ako ne go najdime go barame nanagore za poslobodno mesto, i ka ce najdime prazno WHITE , dodavame topce na taa pozicija vrz nego Crveno/Plavo vo zavisnost od playerot

                for (int i = 5; i >= 0; i--)
                {
                    if (scena.topcinja[i, this.scena.clickedNewBall.pozicijaNaKolonaIliJod].boja == Color.White)
                    {
                        Ball b = new Ball(new Point(e.X, e.Y));
                        b.boja = Player.topceBoja;
                        scena.topcinja[i, this.scena.clickedNewBall.pozicijaNaKolonaIliJod] = b;
                    }

                }
            }
            else if (e.X > 270 && e.X < 360)
            {
                     MessageBox.Show("Treta KOLONA");
                    this.scena.clickedNewBall = new Ball(new Point(e.X, e.X));//new
                    this.scena.clickedNewBall.pozicijaNaKolonaIliJod = 2;
                
            }
            else if (e.X > 370 && e.X < 460)
            {                
                MessageBox.Show("Cetvrta KOLONA");
                this.scena.clickedNewBall = new Ball(new Point(e.X, e.X));//new
                this.scena.clickedNewBall.pozicijaNaKolonaIliJod = 3;
            
        }
            else if (e.X > 470 && e.X < 560)
            {
                MessageBox.Show("Petta KOLONA");
                this.scena.clickedNewBall = new Ball(new Point(e.X, e.X));//new
                this.scena.clickedNewBall.pozicijaNaKolonaIliJod = 4;
            }

            else if (e.X > 570 && e.X < 660)
            {
                MessageBox.Show("Sesta KOLONA");
                this.scena.clickedNewBall = new Ball(new Point(e.X, e.X));//new
                this.scena.clickedNewBall.pozicijaNaKolonaIliJod = 5;
            }
               
            else if (e.X > 670 && e.X < 760)
            {
                MessageBox.Show("Sedma KOLONA");
                this.scena.clickedNewBall = new Ball(new Point(e.X, e.X));//new
                this.scena.clickedNewBall.pozicijaNaKolonaIliJod = 6;
            }

            //da napravime sega //UpdateNewClickedBall() vo Scene klasata, za da go azurirame novoto topce - 
            // ke tr da a izvrtime cela matrica so a imame u scena i spored poziciite via pozicijaNaKolonaIliJod da smestime topce
            // da napr Invalidate





            Invalidate();
        }

        private void Connect4_Paint(object sender, PaintEventArgs e)
        {
            scena.DrawPlatno(e.Graphics);
            scena.DrawAll(e.Graphics);
        }

        private void Connect4_Load(object sender, EventArgs e)
        {
            
        }
    }
}
