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
            char[][] test = new char[20][];
            for(int i = 0; i < test.Length; i++)
            {
                test[i] = new char[20];
                for(int j = 0; j<test[i].Length; j++)
                {
                    test[i][j] = '-';
                }
            }
            Console.Write("  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20");
            Console.WriteLine();
            foreach(char[] array in test)
            {
                Console.Write("A ");
                foreach(char b in array)
                {
                    Console.Write(b);
                    Console.Write("  ");
                }
                Console.WriteLine();

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
