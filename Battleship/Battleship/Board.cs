using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Board // Static class or abstract class?
    {
        char[][] board; // probably a bad variable name.
        // Haven't written anything in this class yet. Get rid of it? Just use the Game class???
        // Store 2 arrays per Board: 1 for Ships, 1 for hit/miss. The real battleship boards are 2 20x20 grids.
        // Or just 1 array for hit/miss and get Ship info from Player. Better to do Player.ships than Player.Board.ships
        // Ships are on the Board, but ultimately, the Ships belong to the Player (the Player HAS Ships).
        public void MakeHitMissBoard()
        {

        }
        public void MakeShipsBoard()
        {

        }
        // 2 similar functions, should us inheretance for a hit/miss Board and a Ship Board?
    }
}
