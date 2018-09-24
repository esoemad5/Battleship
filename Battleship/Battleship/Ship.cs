using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    // The class does NOT check for overlap with other Ships. This should probably be done in the Game class.
    class Ship
    {
        private int boardSize;
        public bool isSunk;
        public int[][] location; // an array of length 2 arrays, or null if that spot is hit. (0,0) is top left, (20, 20) is bottom right. (x,y)
        public bool[] sectionIsDamaged;
        string name;
        public bool isHorizontal;
        public int[] nose;
        public int[] tail;
        public Ship(int length, string name, int boardSize)
        {
            isSunk = false;
            location = new int[length][];
            for(int i = 0; i < location.Length; i++)// initilize ships to vertical in the top left
            {
                location[i] = new int[2];
                location[i][0] = 0;
                location[i][1] = i;
            }
            sectionIsDamaged = new bool[length];
            for(int i = 0; i < sectionIsDamaged.Length; i++)
            {
                sectionIsDamaged[i] = false;
            }
            this.name = name;
            isHorizontal = false;
            UpdateNoseAndTail();
            this.boardSize = boardSize;
            
        }
        private bool AtTopEdge()
        {
            for(int i = 0; i< location.Length; i++)
            {
                if(location[i][1] == 0)
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
                if (location[i][1] == boardSize)
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
                if (location[i][0] == 0)
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
                if (location[i][0] == boardSize)
                {
                    return true;
                }
            }
            return false;
        }
        public void Move(string direction) // Done, tested, works!
        {
            switch (direction)
            {
                case "UpArrow":
                    if (!AtTopEdge())
                    {
                        for (int i = 0; i < location.Length; i++)
                        {
                            location[i][1]--;
                        }
                    }

                    break;
                case "DownArrow":
                    if (!AtBottomEdge())
                    {
                        for (int i = 0; i < location.Length; i++)
                        {
                            location[i][1]++;
                        }
                    }
                    break;
                case "LeftArrow":
                    if (!AtLeftEdge())
                    {
                        for (int i = 0; i < location.Length; i++)
                        {
                            location[i][0]--;
                        }
                    }
                    break;
                case "RightArrow":
                    if (!AtRightEdge())
                    {
                        for (int i = 0; i < location.Length; i++)
                        {
                            location[i][0]++ ;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Error in Ship.Move: input was not a direction.");
                    break;
            }
            UpdateNoseAndTail();
        }
        public void Rotate() // Done, UNTESTED. Ship.location[0] has to be the closest point to (0, 0)!!!
        {
            if (location[0][1] == location[1][1]) // Horizontal to vertical
            {
                if (!AtBottomEdge())
                {
                    for (int i = 1; i < location.Length; i++)
                    {
                        location[i][0] -= i;
                        location[i][1] += i;
                        isHorizontal = false;
                    }
                }
                
            }
            else // Vertical to horizontal
            {
                if (!AtRightEdge())
                {
                    for (int i = 1; i < location.Length; i++)
                    {
                        location[i][0] += i;
                        location[i][1] -= i;
                        isHorizontal = true;
                    }
                }
                
            }
            UpdateNoseAndTail();
        }
        public void CheckIfSunk() // Done, UNTESTED.
        {
            foreach(bool b in sectionIsDamaged)
            {
                if(b == false)
                {
                    return;
                }
            }
            isSunk = true;
        }
        private void UpdateNoseAndTail()
        {
            nose = location[0];
            tail = location[location.Length-1];
        }
    }
}
