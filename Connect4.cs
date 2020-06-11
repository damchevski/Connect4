using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4
{
    public partial class Connect4 : Form
    {
        Scene scena = new Scene();
        public string FileName = null;
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
                lblPlayer1.Visible = true;
                lblPlayer2.Visible = true;
                timer1.Start();
            }

            if (scena.checkDraw())
            {
                if (MessageBox.Show("Дали сакате нова игра ?", "Нерешено !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                    
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

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Играта Connect4 е стратегиска игра и се состои од двајца играчи (жолт и црвен)." +
                " Целта на играта е едниот од играчите да нареди четири од неговите топчиња последователно (хоризонтално, вертикално или дијагонално)." +
                " Играчите наизменично се менуваат. Играчот кој е моментално на ред е прикажан со неговото име над таблата." +
                " Играчот поставува топче така што клика над/врз колоната во која што сака да постави топче (топчето се поставува на првото слободно место од горе).",
                "Помош за играта",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            scena = new Scene();
            lblPlayer1.Visible = true;
            lblPlayer2.Visible = false;
            Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Дали сте сигурни дека сакате да излезете од играта ?", "Потврди излез", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
            else return;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Connect4 (*.ct4)|*.ct4";
                saveFileDialog.Title = "Зачувај игра";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                }
            }
            if (FileName != null)
            {
                using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    
                    formatter.Serialize(fileStream, scena);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Connect4 (*.ct4)|*.ct4";
            openFileDialog.Title = "Отвори игра";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                try
                {
                    using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                    {
                        IFormatter formater = new BinaryFormatter();
                       
                        scena = (Scene)formater.Deserialize(fileStream);
                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Играта неможе да се отвори: " + FileName);
                    FileName = null;
                    return;
                }
                if (scena.player1.turn)
                {
                   
                    lblPlayer1.Visible = true;
                    lblPlayer2.Visible = false;
                }
                else
                {
                    lblPlayer1.Visible = false;
                    lblPlayer2.Visible = true;
                }
                lblPlayer1.Text = scena.player1.playerName;

                lblPlayer2.Text = scena.player2.playerName;

                Invalidate(true);
            }
        }
    }
}
