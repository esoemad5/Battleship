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

        /* Create players.
         */
        /* Players set up Ships.
         * Make 5 Ships in default positions. Put them into Player's Ship[].
         * Player can cycle through array with 'a' and 'd', rotate with 'r' move with arrow keys.
         */
        /* Players play the Game.
         * while(player1.hasActiveShips && player2.hasActiveShips)
         * {showBoard(player1); player1.attack(input, player2.ships);
         * showBoard(player2); player2.attack(input, player1.ships);}
         * Player.attack looks at oponent's Ship array, displays results then edits own Player's array?
         * Store some/all arrays in the game class? The Boards are part of the game and the Players interact with them.
         */
        public Game()
        {
            player1 = new Player();
            player2 = new Player();
        }
        private void PlayGame()
        {

        }
        private void SetUpShips() // Should this be in the player class?
        {

        }
    }
}
