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
            Game game = new Game();
            game.PlayGame();
            

            /*
            for(int i = 0; i < testPlayer.Board.alphabeticCoordinates.Length; i++)
            {
                Console.WriteLine( testPlayer.Board.alphabeticCoordinates[i].ToUpper().ToCharArray()[0] - 64);
            }
            if ('A' > 30)
            {
                Console.WriteLine("Hello World!");
            }
            */

            /*
            var stringCollection = new SampleCollection<string>();
            stringCollection[0, 1] = "Hello, World";
            Console.WriteLine(stringCollection[0, 1]);
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
    class SampleCollection<T>
    {
        // Declare an array to store the data elements.
        //private T[] arr = new T[100];
        private T[][] arr2 = new T[100][];

        // Define the indexer to allow client code to use [] notation.
        public T this[int i, int j]
        {
            get { return arr2[i][j]; }
            set { arr2[i][j] = value; }
        }

    }

    class SampleCollection2<T>
    {
        // Declare an array to store the data elements.
        //private T[] arr = new T[100];
        private T[][] arr2 = new T[100][];

        // Define the indexer to allow client code to use [] notation.
        /*
        public T this[int i][int j]
        {
            get { return arr2[i][j]; }
            set { arr2[i][j] = value; }
        }
        */



    }
}
