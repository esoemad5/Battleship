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

        public Player (string name, int boardSize)
        {
            this.name = name;
            ships = new Ship[5];
            ships[0] = new Ship(5, "Carrier", boardSize);
            ships[1] = new Ship(4, "Battleship", boardSize);
            ships[2] = new Ship(3, "Destroyer", boardSize);
            ships[3] = new Ship(3, "Submarine", boardSize);
            ships[4] = new Ship(2, "Patrol Boat", boardSize); 
            // hitmiss = new ???();
            hasActiveShips = true;
        }
        public void Attack(int[] square, Ship[] opponentsShips)// How to convert input (ex. B4) to the array location?
        {

        }
        public void CheckIfNoRemainingShips()
        {
            foreach(Ship ship in ships)
            {
                if (!ship.isSunk)
                {
                    return;
                }
            }
            hasActiveShips = false;
        }
    }
}
