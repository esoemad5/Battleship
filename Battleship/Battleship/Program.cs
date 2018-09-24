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
            Ship testShip = new Ship(4, "Battleship");
            ShowLocation(testShip);
            for(int i = 0; i < 20; i++)
            {
                testShip.Move("RightArrow");
            }
            
            ShowLocation(testShip);
            testShip.Rotate();
            ShowLocation(testShip);
            testShip.Rotate();
            ShowLocation(testShip);

        }
        static void ShowLocation(Ship ship)
        {
            foreach (int[] square in ship.location)
            {
                Console.WriteLine("({0}, {1})", square[0], square[1]);
                
            }
            Console.WriteLine("---------------------------");
        }
    }
}
