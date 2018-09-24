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
            string player1Name = Console.ReadLine();
            string player2Name = Console.ReadLine();
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
        }
        private void PlayGame()
        {

        }
        private void SetUpShips() // Should this be in the player class?
        {

        }
        private bool ShipsOverlap(Ship[] ships)
        {
            for(int i = 0; i < ships.Length; i++) // i is one Ship
            {
                for (int j = i+1; j < ships.Length; j++) // j is another Ship
                {
                    /* smrt solution. Ship length does not affect computational efficiency.
                     * If both horizontal, check if in same row(y-coordinate; .location[1]),
                     * then check if nose/tail of j is between i's nose/tail(.location[0])
                     * 
                     * If both vertical, check if in same column (.location[0]),
                     * then check if nose/tail of j is between i's nose/tail (.location[1])
                     * 
                     * If different orientations, check depends on j horz or vert (always compare j to i).
                     * Horizontal: compare all of j's x (ships[j].location[k][0]) to i's x (Ship[i].location[0][0])
                     *  if a common column is found, if(j's y > i's nose && j's y < i's tail): overlap!
                     * Vertical: comapre all of j's y (ship[j].location[k][1]) to i's y
                     *  if a common row is found, if(j's x > i's nose && j's x < i's tail): overlap!
                     */


                    /* Slow solution
                    for(int k = 0; k < ships[i].location.Length; k++) // k is a coordinate of Ship[i]'s location
                    {
                        for (int l = 0; l < ships[j].location.Length; l++) // l is a coordinate of Ship[j]'s location
                        {
                            if(ships[i].location[k] == ships[j].location[l])
                            {
                                return true;
                            }
                        }
                    }
                    */
                }
            }
            return false; // no overlap
        }
    }
}
