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
            // Need to make Game.ShipsOverlap public and static for testing to work
            Console.WriteLine("---------------------------");
            Ship testShip0 = new Ship(4, "Battleship", 20);
            ShowLocation(testShip0.location);
            Ship testShip1 = new Ship(3, "Submarine", 20);
            ShowLocation(testShip1.location);
            Ship[] testArray = { testShip0, testShip1 };
            testShip1.Move("DownArrow");
            testShip1.Move("DownArrow");
            testShip1.Move("DownArrow");
            //testShip1.Move("DownArrow");
            ShowLocation(testShip1.location);
            Console.WriteLine(Game.ShipsOverlap(testArray));

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
