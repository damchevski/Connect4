using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    [Serializable]
    public class Player
    {
        public string playerName { get; set; }
        public bool turn { get; set; }
        public int brojtopcinja { get; set; }
        public bool daliZavrsil { get; set; }
       
        public Player(string playerName,bool turn)
        {
            this.playerName = playerName;
            this.turn = turn;
            this.brojtopcinja = 0;
            this.daliZavrsil = false;
        }
        public void Click(Point lokacija)
        {

        //opredelenotopcekegopravidekaeodnegokliknato   
        }



    }
}
