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
    public partial class Form1 : Form
    {
        public static string player1Name = "";
        public static string player2Name = "";
        public Form1()
        {
            InitializeComponent();
        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(txtPlayer1.Text.Length == 0)
            {
                errorProvider1.SetError(txtPlayer1, "Името е задолжително !");
                return;
            }
            else
            {
                if (txtPlayer1.Text.Length >= 4 && txtPlayer1.Text.Length <= 10)
                {
                    errorProvider1.SetError(txtPlayer1, null);
                }else
                {
                    errorProvider1.SetError(txtPlayer1, "Името мора да биде од 6 до 10 карактери !");
                    return;
                }
            }

            if(txtPlayer2.Text.Length == 0)
            {
                errorProvider1.SetError(txtPlayer2, "Името е задолжително !");
                return;
            }
            else
            {
                if (txtPlayer2.Text.Length >= 4 && txtPlayer2.Text.Length <= 10)
                {
                    errorProvider1.SetError(txtPlayer2, null);
                }
                else
                {
                    errorProvider1.SetError(txtPlayer2, "Името мора да биде од 6 до 10 карактери !");
                    return;
                }
            }

            player1Name = txtPlayer1.Text;
            player2Name = txtPlayer2.Text;
            
            Connect4 newGame = new Connect4();
            newGame.Show();

            txtPlayer1.Text = "";
            txtPlayer2.Text = "";
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
