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
        int length; // may not need this
        int[][] location; // an array of length 2 arrays, or null if that spot is hit. (0,0) is top left, (20, 20) is bottom right.
        //null doesn't work because damaged part of Ship has to move with the rest of it.
        bool[] sectionIsDamaged;
        string name;
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
        public Ship(int length, string name)
        {
            isSunk = false;
            this.length = length;
            location = new int[length][];
            sectionIsDamaged = new bool[length];
            for(int i = 0; i < sectionIsDamaged.Length; i++)
            {
                sectionIsDamaged[i] = false;
            }
            this.name = name;
            
        }
        private bool AtTopEdge()
        {
            for(int i = 0; i< location.Length; i++)
            {
                if(location[i][0] == 0)
                {
                    return true;
                }
            }
            return false;
        }
        private bool AtBottomEdge()
        {
            for (int i = 0; i < location.Length; i++)
            {
                if (location[i][0] == 20)
                {
                    return true;
                }
            }
            return false;
        }
        private bool AtLeftEdge()
        {
            for (int i = 0; i < location.Length; i++)
            {
                if (location[i][1] == 0)
                {
                    return true;
                }
            }
            return false;
        }
        private bool AtRightEdge()
        {
            for (int i = 0; i < location.Length; i++)
            {
                if (location[i][1] == 20)
                {
                    return true;
                }
            }
            return false;
        }
        public void Move(string direction) // Done, UNTESTED
        {
            switch (direction)
            {
                case "UpArrow":
                    if (!AtTopEdge())
                    {
                        for (int i = 0; i < location.Length; i++)
                        {
                            location[i][0]--;
                        }
                    }

                    break;
                case "DownArrow":
                    if (!AtBottomEdge())
                    {
                        for (int i = 0; i < location.Length; i++)
                        {
                            location[i][0]++;
                        }
                    }
                    break;
                case "LeftArrow":
                    if (!AtLeftEdge())
                    {
                        for (int i = 0; i < location.Length; i++)
                        {
                            location[i][1]--;
                        }
                    }
                    break;
                case "RightArrow":
                    if (!AtRightEdge())
                    {
                        for (int i = 0; i < location.Length; i++)
                        {
                            location[i][1]++ ;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Error in Ship.Move input was not a direction.");
                    break;
            }
        }
        public void Rotate()
        {

        }
        public void CheckIfSunk()
        {

        }
    }
}
