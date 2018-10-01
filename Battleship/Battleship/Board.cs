using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Board
    {
        private int test;
        public int Test { set => test = value; }
        private string[][] hitsMisses;
        public string[][] HitsMisses { get => hitsMisses; set{ hitsMisses = value;} }
        private string[][] shipPositions;
        private int boardSize;

        private string firstBoardLabel;
        private string secondBoardLabel;
        private int spacesBetweenBoards;
        private int spacesPerEntry;

        public readonly string[] alphabeticCoordinates = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" }; // Going larger than 26x26 is not possible at this time.
        public Board(int boardSize)
        {
            this.boardSize = boardSize;
            hitsMisses = new string[boardSize][];
            shipPositions = new string[boardSize][];

            Reset();
            firstBoardLabel = "Hits/Misses";
            secondBoardLabel = "Ship Positions";
            spacesBetweenBoards = 6;
            spacesPerEntry = 3;
        }
        public void Reset()
        {
            for (int i = 0; i < boardSize; i++)
            {
                hitsMisses[i] = new string[boardSize];
                shipPositions[i] = new string[boardSize];

                for (int j = 0; j < boardSize; j++)
                {
                    hitsMisses[i][j] = "-";
                    shipPositions[i][j] = "-";
                }
            }
            
        }
        private void WriteHeaders()
        {
            int halfwayTHroughBoardSection =  spacesPerEntry* boardSize / 2;

            int spacesBeforeFirstBoardLabel = spacesPerEntry + halfwayTHroughBoardSection - (firstBoardLabel.Length / 2);
            for (int i = 0; i < spacesBeforeFirstBoardLabel; i++)
            {
                Console.Write(" ");
            }
            Console.Write(firstBoardLabel);
            int spaceBeforeSecondBoardLabel = spacesBeforeFirstBoardLabel + spacesBetweenBoards + halfwayTHroughBoardSection - (secondBoardLabel.Length / 2);
            for (int i = 0; i < spaceBeforeSecondBoardLabel; i++)
            {
                Console.Write(" ");
            }
            Console.Write(secondBoardLabel);

            Console.WriteLine();
        }
        private void WriteNumericalCoordinates()
        {
            WriteSpacesBetweenEntries(0);
            for(int i = 0; i < boardSize; i++)
            {
                if(i < 9)
                {
                    Console.Write("{0}", i + 1);
                    for(int j = 0; j < spacesPerEntry -1; j++)
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    Console.Write("{0}", i + 1);
                    for (int j = 0; j < spacesPerEntry - 2; j++)
                    {
                        Console.Write(" ");
                    }
                } 
            }
        }
        private void WriteSpacesBetweenBoards()
        {
            for (int i = 0; i < spacesBetweenBoards; i++)
            {
                Console.Write(" ");
            }
        }
        private void WriteSpacesBetweenEntries(int entryLength)
        {
            for (int i = 0; i < spacesPerEntry - entryLength; i++)
            {
                Console.Write(" ");
            }
        }
        private void WriteBoardSectionAndAlphabeticCoordinates()
        {
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write(alphabeticCoordinates[i]);
                WriteSpacesBetweenEntries(alphabeticCoordinates[i].Length);

                for (int j = 0; j < hitsMisses.Length; j++)
                {
                    Console.Write(hitsMisses[j][i]);
                    WriteSpacesBetweenEntries(hitsMisses[j][i].Length);
                }
                WriteSpacesBetweenBoards();
                Console.Write(alphabeticCoordinates[i]);
                WriteSpacesBetweenEntries(alphabeticCoordinates[i].Length);
                for (int j = 0; j < shipPositions.Length; j++)
                {
                    Console.Write(shipPositions[j][i]);
                    WriteSpacesBetweenEntries(shipPositions[j][i].Length);
                }

                Console.WriteLine();
            } 
        }
        public void Display()
        {
            WriteHeaders();
            WriteNumericalCoordinates();
            WriteSpacesBetweenBoards();
            WriteNumericalCoordinates();
            Console.WriteLine();
            WriteBoardSectionAndAlphabeticCoordinates();
        }

        /* TODO: Both of these functions will recieve information from Player.Attack
         * squareThatWasAttacked should NOT be of type Object
         */
        public void updateHitsMisses()
        {
        }
        public void updateShipPositions(Ship[] ships) // Does not deal with attacks!
        {
            foreach(Ship ship in ships)
            {
                for(int i = 0; i < ship.Location.Length; i++)
                {
                    if (ship.IsHorizontal)
                    {
                        if (ship.SectionIsDamaged[i])
                        {
                            shipPositions[ship.Nose[0] + i][ship.Nose[1]] = "X";
                        }
                        else
                        {
                            shipPositions[ship.Nose[0] + i][ship.Nose[1]] = "@";
                        } 
                    }
                    else
                    {
                        if (ship.SectionIsDamaged[i])
                        {
                            shipPositions[ship.Nose[0]][ship.Nose[1] + i] = "X";
                        }
                        else
                        {
                            shipPositions[ship.Nose[0]][ship.Nose[1] + i] = "@";
                        }
                    }
                }
            }
        }
    }
}
