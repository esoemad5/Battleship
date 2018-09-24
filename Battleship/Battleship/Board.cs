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
        int spacesBetweenBoards;
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
            secondBoardLabel = "Ships";
            int spacesBetweenBoards = 5;
        }
        private void MakeHeaders()
        {
            // The character length of each board-half is 3*boardSize
            int halfwayThroughBoardHalf = (3 * boardSize) / 2;

            int spacesBeforeFirstBoardLabel = halfwayThroughBoardHalf - (firstBoardLabel.Length / 2);
            for (int i = 0; i < spacesBeforeFirstBoardLabel; i++)
            {
                Console.Write(" ");
            }
            Console.Write(firstBoardLabel);
            int spaceBeforeSecondBoardLabel = spacesBeforeFirstBoardLabel + spacesBetweenBoards + halfwayThroughBoardHalf - (secondBoardLabel.Length / 2);
            for (int i = 0; i < spaceBeforeSecondBoardLabel; i++)
            {
                Console.Write(" ");
            }
            Console.Write(secondBoardLabel);
            Console.WriteLine();
        }
        private void WriteABoard(char[][] boardHalf) // This one is no good
        {
            for (int i = 0; i < boardHalf.Length; i++)
            {
                for (int j = 0; j < boardHalf.Length; j++)
                {
                    Console.Write(boardHalf[i][j]);
                    Console.Write("  ");
                }
            }
        }
        public void DisplayBoard()
        {
            MakeHeaders();
            WriteABoard(hitsMisses);
            WriteABoard(shipPositions);

        }
    }
}
