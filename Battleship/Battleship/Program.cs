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
            for(int i = 0; i < 20; i++)
            {
                //Console.WriteLine("--------------------");
                Console.WriteLine("....................");
            }
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(". . . . @ @ x @ . o o . . . . . . . . ."); // this spacing is good
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
