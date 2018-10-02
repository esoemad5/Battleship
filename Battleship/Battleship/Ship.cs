using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Ship
    {
        private int boardSize;
        private bool isSunk;
        public bool IsSunk { get => isSunk; }

        // An array of length 2 arrays. (0,0) is top left, (20, 20) is bottom right. [ [x, y], [x, y], [x, y],... ]
        private int[][] location;
        public int[][] Location { get => location; }
        private bool[] sectionIsDamaged;
        public bool[] SectionIsDamaged { get => sectionIsDamaged; }
        private string name;
        public string Name { get => name; }
        private bool isHorizontal;
        public bool IsHorizontal { get => isHorizontal; }
        private int[] nose;
        public int[] Nose { get => nose; }
        private int[] tail;
        public int[] Tail { get => tail; }


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
            this.boardSize = boardSize - 1;
            
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
        private bool OutOfBounds()
        {
            foreach(int[] square in location)
            {
                if(square[0] < 0 || square[0] > boardSize || square[1] < 0 || square[1] > boardSize)
                {
                    return true;
                }
            }
            return false;
        }
        public void Move(string direction)
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
                    break;
            }
            UpdateNoseAndTail();
        }
        public void Rotate()
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
            if (OutOfBounds())
            {
                Rotate();
            }
            UpdateNoseAndTail();
        }
        public void CheckIfSunk()
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
