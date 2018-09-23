using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Player
    {
        string Name;
        Board hitmiss;
        Ship[] ships;
        bool hasActiveShips;
        /* How to store player Ships?
         * 1 array of booleans for active/sunk
         * 2 arrays of Ship objects (another way to access location and dammage)
         * Give ship a boolean for active/sunk
         */
        // 2D array of Player's misses/hits/un-attacked, should this be part of the Board class? YES!

        public Player (string name)
        {
            Name = name;
            ships[0] = new Ship();
            ships[1] = new Ship();
            ships[2] = new Ship();
            ships[3] = new Ship();
            ships[4] = new Ship();
            // hitmiss = new ???();
            hasActiveShips = true;
        }
        public void Attack(int[] square, Ship[] opponentsShips)// How to convert input (ex. B4) to the array location?
        {

        }
    }
}
