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

       private char [][] hitsMisses;
       private char[][] shipPositions;
    }
}
