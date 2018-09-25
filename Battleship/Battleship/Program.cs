using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Player testPlayer = new Player("Player", 20);
            //testPlayer.ships[4].Move("RightArrow");
            testPlayer.board.updateShipPositions(testPlayer.ships, null);
            testPlayer.board.Display();
            foreach(Ship ship in testPlayer.ships)
            {
               ShowLocation(ship.location);
            }
    
        }
        public static void ShowLocation(int[][] input)
        {
            foreach (int[] square in input)
            {
                Console.WriteLine("({0}, {1})", square[0], square[1]);
                
            }
            Console.WriteLine("---------------------------");
        }
    }
}
