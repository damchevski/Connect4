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

            if(scena.player1.daliZavrsil || scena.player2.daliZavrsil)
            {
                if(MessageBox.Show("Дали сакате нова игра ?", "Играта заврши !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                    return;
                }
                else
                {
                    return;
                }
            }

            int kolona = -1;
            int igrac = -1;

            if (scena.player1.turn)
            {
                igrac = 1;
            }else if (scena.player2.turn)
            {
                igrac = 2;
            }

            if (e.X > 70 && e.X < 160)
            {
                kolona = 0;
            }  
            else if (e.X > 170 && e.X < 260)
            {
                kolona = 1;
            }
            else if (e.X > 270 && e.X < 360)
            {
                kolona = 2;
            }
            else if (e.X > 370 && e.X < 460)
            {
                kolona = 3;
            }
            else if (e.X > 470 && e.X < 560)
            {
                kolona = 4;
            }

            else if (e.X > 570 && e.X < 660)
            {
                kolona = 5;
            }
               
            else if (e.X > 670 && e.X < 760)
            {
                kolona = 6;
            }

            if(kolona == -1)
            {
                return;
            }
            int sakanoI = -1;
            for (int i = 0; i < 6; i++)
            {
                if (scena.topcinja[kolona, i].active == false)
                {
                    sakanoI = i;
                    break;
                }
            }

            if (sakanoI == -1)
            {
                MessageBox.Show("Колоната е полна","Грешка");
                return;
            }

            if (scena.player1.turn)
            {
                lblPlayer1.Visible = false;
                lblPlayer2.Visible = true;
            }
            else if (scena.player2.turn)
            {
                lblPlayer2.Visible = false;
                lblPlayer1.Visible = true;
            }

            scena.AddBall(kolona, igrac, sakanoI);

            Invalidate();

            if (scena.CheckWin())
            {
                timer1.Start();
            }

            if (scena.checkDraw())
            {
                if (MessageBox.Show("Дали сакате нова игра ?", "Нерешено !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                    Form1 newGame = new Form1();
                    newGame.Show();
                    return;
                }
                else
                {
                    return;
                }
            }
        }


        private void Connect4_Paint(object sender, PaintEventArgs e)
        {
            scena.DrawPlatno(e.Graphics);
            scena.DrawAll(e.Graphics);
        }

        private void Connect4_Load(object sender, EventArgs e)
        {
            lblPlayer1.Text = scena.player1.playerName;
            lblPlayer2.Text = scena.player2.playerName;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scena.ticks++;
            if (scena.forPulse[0].radius >= 65)
            {
                scena.pulseAll(-10);
            }
            else
            {
                scena.pulseAll(10);
            }

            if (scena.ticks == 10)
                timer1.Stop();

            Invalidate();
        }
    }
}
