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
            Console.WriteLine("---------------------------");
            Ship testShip = new Ship(4, "Battleship", 20);
            ShowLocation(testShip.location);
            for(int i = 0; i < 30; i++)
            {
                testShip.Move("RightArrow");
            }
            
            ShowLocation(testShip.location);
            /*
            testShip.Rotate();
            ShowLocation(testShip);
            testShip.Rotate();
            ShowLocation(testShip);
            */

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
