using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Player
    {
        string name;
        Board hitmiss; // May need to change
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
            this.name = name;
            ships = new Ship[5];
            ships[0] = new Ship(5, "Carrier");
            ships[1] = new Ship(4, "Battleship");
            ships[2] = new Ship(3, "Destroyer");
            ships[3] = new Ship(3, "Submarine");
            ships[4] = new Ship(2, "Patrol Boat"); 
            // hitmiss = new ???();
            hasActiveShips = true;
        }
        public void Attack(int[] square, Ship[] opponentsShips)// How to convert input (ex. B4) to the array location?
        {

        }
    }
}
