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
                errorProvider1.SetError(txtPlayer1, null);
            }

            if(txtPlayer2.Text.Length == 0)
            {
                errorProvider1.SetError(txtPlayer2, "Името е задолжително !");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPlayer2, null);
            }

            Connect4 newGame = new Connect4();
            newGame.Show();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
