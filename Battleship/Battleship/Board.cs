using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Board
    {
        private string[][] hitsMisses;
        private string[][] shipPositions;
        private int boardSize;

        private string firstBoardLabel;
        private string secondBoardLabel;
        private int spacesBetweenBoards;
        private int spacesPerEntry;

        public readonly string[] alphabeticCoordinates = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" }; // Going larger than 26x26 is not possible at this time.
        public Board(int boardSize)
        {
            hitsMisses = new string[boardSize][];
            shipPositions = new string[boardSize][];

            for(int i = 0; i < boardSize; i++)
            {
                hitsMisses[i] = new string[boardSize];
                shipPositions[i] = new string[boardSize];

                for(int j = 0; j < boardSize; j++)
                {
                    hitsMisses[i][j] = "-";
                    shipPositions[i][j] = "-";
                }
            }

            this.boardSize = boardSize;
            firstBoardLabel = "Hits/Misses";
            secondBoardLabel = "Ship Positions";
            spacesBetweenBoards = 6;
            spacesPerEntry = 3;
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
                    Console.Write(hitsMisses[i][j]);
                    WriteSpacesBetweenEntries(hitsMisses[i][j].Length);
                }
                WriteSpacesBetweenBoards();
                Console.Write(alphabeticCoordinates[i]);
                WriteSpacesBetweenEntries(alphabeticCoordinates[i].Length);
                for (int j = 0; j < shipPositions.Length; j++)
                {
                    Console.Write(shipPositions[i][j]);
                    WriteSpacesBetweenEntries(shipPositions[i][j].Length);
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
        public void updateHitsMisses(Object squareThatWasAttacked)
        {
        }
        public void updateShipPositions(Ship[] ships, Object squareThatWasAttacked)
        {
            // Different if Ship is horizontal or vertical.
            // Start at nose and go from there
            // Check for dammage each time
            foreach(Ship ship in ships)
            {
                for(int i = 0; i < ship.location.Length; i++)
                {
                    if (ship.isHorizontal)
                    {
                        if (ship.sectionIsDamaged[i])
                        {
                            shipPositions[ship.nose[0] + i][ship.nose[1]] = "X";
                        }
                        else
                        {
                            shipPositions[ship.nose[0] + i][ship.nose[1]] = "@";
                        } 
                    }
                    else
                    {
                        if (ship.sectionIsDamaged[i])
                        {
                            shipPositions[ship.nose[0]][ship.nose[1] + i] = "X";
                        }
                        else
                        {
                            shipPositions[ship.nose[0]][ship.nose[1] + i] = "@";
                        }
                    }
                }
            }
        }
    }
}
