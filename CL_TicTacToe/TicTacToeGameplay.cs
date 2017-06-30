using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Böge, Kaufhold
namespace CL_TicTacToe
{
    public class TicTacToeGameplay
    {
        public int Player { get; set; }                          // public only describes the properties, the variable will be created in the background
        public symbol[,] Gamefield { get; set; }
        public symbol Playersicon { get; set; }
        public bool Playerwon { get; set; }
        
        uint fullfields;
        public uint Fullfields
        {
            get { return this.fullfields; }
            set { if (value >= 0 && value <= 9) this.fullfields = value; }
        }

        /// <summary>
        /// Constructur
        /// </summary>
        public TicTacToeGameplay()
        {
            Gamefield = new symbol[3, 3];
            Playersicon = symbol.x;
            Player = 1;
            Playerwon = false;
            Fullfields = 0;
        }

        /// <summary>
        /// To save the input of the user
        /// </summary>
        /// <param name="inumber">x-position of the button</param>
        /// <param name="ynumber">y-position of the button</param>
        public void SaveClick(int xnumber, int ynumber)
        {
            Gamefield[xnumber, ynumber] = Playersicon;
            Fullfields++;
            Comparison();
        }

        /// <summary>
        /// Check, whether somebody has already won
        /// </summary>
        public void Comparison()
        {
            for (int i = 0; i < 3; i++)
            {
                //vertical check
                if (Gamefield[0, i] == Gamefield[1, i] && Gamefield[1, i] == Gamefield[2, i] && Gamefield[0, i] == Gamefield[2, i] && Gamefield[1, i] == Gamefield[2, i] && Gamefield[0, i] != symbol.empty)
                {
                    Playerwon = true;
                    break;
                }

                //horizontal check
                if (Gamefield[i, 0] == Gamefield[i, 1] && Gamefield[i, 1] == Gamefield[i, 2] && Gamefield[i, 0] == Gamefield[i, 2] && Gamefield[i, 1] == Gamefield[i, 2] && Gamefield[i, 0] != symbol.empty)
                {
                    Playerwon = true;
                    break;
                }
            }

            //diagonal check
            if (Gamefield[0, 0] == Gamefield[1, 1] && Gamefield[1, 1] == Gamefield[2, 2] && Gamefield[0, 0] == Gamefield[2, 2] && Gamefield[1, 1] == Gamefield[2, 2] && Gamefield[0, 0] != symbol.empty)
            {
                Playerwon = true;
            }
            if (Gamefield[2, 0] == Gamefield[1, 1] && Gamefield[1, 1] == Gamefield[0, 2] && Gamefield[2, 0] == Gamefield[0, 2] && Gamefield[1, 1] == Gamefield[0, 2] && Gamefield[2, 0] != symbol.empty)
            {
                Playerwon = true;
            }


        }

        /// <summary>
        /// Next player shall turn
        /// </summary>
        public void Changeplayer()
        {
            if (Player == 1)
            {
                Playersicon = symbol.o;
                Player = 2;
            }

            else if (Player == 2)
            {
                Playersicon = symbol.x;
                Player = 1;
            }

        }

    }
}
