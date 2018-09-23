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
            /* How to check for arrow keys.
            for(int i = 0; i < 5; i++){
                ConsoleKeyInfo a = Console.ReadKey();
                Console.WriteLine(a.Key.ToString());
                Console.WriteLine(a.KeyChar.ToString());
                if(a.Key.ToString() == "UpArrow")
                {
                    Console.WriteLine("Hello World!");

                }
            }
            */
            
            
            /* show fake board
            for(int i = 0; i < 50; i++)
            {
                for(int j = 0; j < 90; j++)
                {
                    Console.Write('X');
                }
                Console.WriteLine(i); // fullscreen shows 40 lines for me, not good for a 20x20 board, have to show boards left-right rather than top-bottom
            }
            */
        }
    }
}
