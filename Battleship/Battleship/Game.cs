using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Game
    {
        Player player1;
        Player player2;
        int boardSize;

        public Game()
        {
            boardSize = 20;
            // Console.WriteLine(); boardSize = Console.ReadLine(); if we wanted to change the size of the board
            Console.WriteLine("Player 1, please enter your name:");
            string player1Name = Console.ReadLine();
            Console.WriteLine("Player 2, please enter your name:");
            string player2Name = Console.ReadLine();
            player1 = new Player(player1Name, boardSize);
            player2 = new Player(player2Name, boardSize);
        }
        public void PlayGame()
        {
            player1.SetUpShips();
            player2.SetUpShips();
            while (player1.HasActiveShips && player2.HasActiveShips)
            {
                player1.Board.Display();
                player1.Attack(player1.DeclareAttackTarget(), player2);
                player2.CheckIfNoRemainingShips();
                if (!player2.HasActiveShips)
                {
                    Console.WriteLine("{0} wins!", player1.Name);
                    return;
                }

                player2.Board.Display();
                player2.Attack(player2.DeclareAttackTarget(), player1);
                player1.CheckIfNoRemainingShips();
                if (!player1.HasActiveShips)
                {
                    Console.WriteLine("{0} wins!", player2.Name);
                    return;
                }
            }
        }
    }
}
