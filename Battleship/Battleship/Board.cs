using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Board // Static class or abstract class?
    {
        // Haven't written anything in this class yet. Get rid of it? Just use the Game class???
        // Store 2 arrays per Board: 1 for Ships, 1 for hit/miss. The real battleship boards are 2 20x20 grids.
        // Or just 1 array for hit/miss and get Ship info from Player. Better to do Player.ships than Player.Board.ships
        // Ships are on the Board, but ultimately, the Ships belong to the Player (the Player HAS Ships).


        /* New Board outline (after writing most of Game and Ship).
         * 2 char[][] one for Player's Ships and one for Player's hits/misses.
         * Player.Attack edits Player's hit/miss array and opponents ships array.
         * Display board will always display both (even in setup part of game).
         */

        private char[][] hitsMisses;
        private char[][] shipPositions;
        private int boardSize;

        private string firstBoardLabel;
        private string secondBoardLabel;
        private int spacesBetweenBoards;
        private int spacesPerEntry;

        private readonly char[] alphabeticCoordinates = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }; // Boards can be up to 26x26
        public Board(int boardSize)
        {
            hitsMisses = new char[boardSize][];
            shipPositions = new char[boardSize][];
            for(int i = 0; i < boardSize; i++)
            {
                for(int j = 0; j < boardSize; j++)
                {
                    hitsMisses[i] = new char[boardSize];
                    shipPositions[i] = new char[boardSize];
                    hitsMisses[i][j] = '-';
                    shipPositions[i][j] = '-';
                }
            }

            this.boardSize = boardSize;
            firstBoardLabel = "Hits/Misses";
            secondBoardLabel = "Ship Positions";
            spacesBetweenBoards = 7;
            spacesPerEntry = 4;
        }
        private void WriteHeaders()
        {
            // The character length of each board-half is 3*boardSize
            int halfwayTHroughBoardSection =  spacesPerEntry* boardSize / 2;

            int spacesBeforeFirstBoardLabel = halfwayTHroughBoardSection - (firstBoardLabel.Length / 2);
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
        private void WriteBoardsAndAlphabeticCoordinates()
        {
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write(alphabeticCoordinates[i]);
                WriteSpacesBetweenEntries(alphabeticCoordinates[i].Length);
                Console.WriteLine();
                /*
                for (int j = 0; j < hitsMisses.Length; j++)
                {
                    Console.Write(hitsMisses[j]);
                }
                WriteSpacesBetweenBoards();
                for (int j = 0; j < shipPositions.Length; j++)
                {
                    Console.Write(shipPositions[j]);
                }
                */
            }
        }
        public void Display()
        {
            WriteHeaders();
            WriteNumericalCoordinates();
            WriteSpacesBetweenBoards();
            WriteNumericalCoordinates();
            Console.WriteLine();
            WriteBoardsAndAlphabeticCoordinates();
        }
    }
}
