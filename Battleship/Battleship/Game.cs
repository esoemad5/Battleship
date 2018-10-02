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
            bool bothPlayersHaveActiveShips = true;
            while (bothPlayersHaveActiveShips)
            {
                bothPlayersHaveActiveShips = Turn(player1, player2);
                bothPlayersHaveActiveShips = Turn(player2, player1);

            }
        }
        private bool Turn(Player playerA, Player playerB)
        {
            playerA.Board.Display();
            Console.WriteLine("Ships I've sunk so far:");
            foreach(string ship in playerA.ShipsIveSunk)
            {
                Console.WriteLine("{0}", ship);
            }
            if(playerA.ShipsIveSunk.Count == 0)
            {
                Console.WriteLine("None yet :(");
            }
            Console.WriteLine();
            playerA.Attack(playerA.DeclareAttackTarget(), playerB);
            playerB.CheckIfNoRemainingShips();
            if (!playerB.HasActiveShips)
            {
                Console.WriteLine("{0} wins!", playerA.Name);
                return false;
            }
            else
            {
                Console.WriteLine("Press enter to pass the turn to {0}", playerB.Name);
                Console.ReadLine();
            }
            return true;
        }

    }
}
