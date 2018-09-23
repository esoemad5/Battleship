using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Ship
    {
        bool isSunk;
        int length;
        int[][][] location; // 1 2D array for each square it occupies.
        // Boolean parameter for active/sunk.
        // 5 Kinds of Ships, different lengths.
        // Carrier 5, Battleship 4, Submarine 3, Destroyer 3, Patrol Boat 2 (remembered all that from childhood, wow).
        // Store nose and tail locations instead of whole boat. Easier to read overlap if all points are stored.
        // Function that checks for hits needs to look between all Ship pairs?
        /* For setting up the game:
         * Constructor sets them to default locations.
         * Function to move Ships around the board.
         * Arrows to move, 'r' to rotate.
         * Don't ever allow overlap, even in setup phase.
         * Allow overlap, but dont allow game to start if there is overlap?
         * How to handle overlap when rotating?
         */
        public void move(ConsoleKeyInfo direction)
        {

        }
        public void rotate()
        {

        }
        public void checkIfSunk()
        {

        }
    }
}
