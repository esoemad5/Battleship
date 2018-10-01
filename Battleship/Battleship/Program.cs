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
            //testPlayer.Board.updateShipPositions(testPlayer.Ships);
           // testPlayer.Board.Display();
            foreach(Ship ship in testPlayer.Ships)
            {
               //ShowLocation(ship.Location);
            }
          //  testPlayer.SetUpShips();
          for(int i = 0; i < testPlayer.Board.alphabeticCoordinates.Length; i++)
            {
                Console.WriteLine( testPlayer.Board.alphabeticCoordinates[i].ToUpper().ToCharArray()[0] - 64);
            }
            if ('A' > 30)
            {
                Console.WriteLine("Hello World!");
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
