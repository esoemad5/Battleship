using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Player
    {
        private string name;
        public string Name { get => name; }
        private Board board; // May need to change
        public Board Board { get => board; }
        private Ship[] ships;
        public Ship[] Ships { get => ships; }

        private bool hasActiveShips;
        public bool HasActiveShips { get => hasActiveShips; }
        /* How to store player Ships?
         * 1 array of booleans for active/sunk
         * 2 arrays of Ship objects (another way to access location and dammage)
         * Give ship a boolean for active/sunk
         */
        // 2D array of Player's misses/hits/un-attacked, should this be part of the Board class? YES!

        public Player (string name, int boardSize)
        {
            this.name = name;
            ships = new Ship[5];
            ships[0] = new Ship(5, "Carrier", boardSize);
            ships[1] = new Ship(4, "Battleship", boardSize);
            ships[2] = new Ship(3, "Destroyer", boardSize);
            ships[3] = new Ship(3, "Submarine", boardSize);
            ships[4] = new Ship(2, "Patrol Boat", boardSize);
            MoveShipsToDefaultLocations();
            board = new Board(boardSize);
            hasActiveShips = true;
        }
        private void MoveShipsToDefaultLocations()
        {
            for (int i = 1; i < ships.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    ships[i].Move("RightArrow");
                    ships[i].Move("RightArrow");
                }
            }
        }
        public int[] DeclareAttackTarget()
        {
            
            string input = " ";
            while (!InputProcessing.Validate(input, board.Size))
            {
                Console.WriteLine("{0}, which location would you like to attack?", name);
                input = Console.ReadLine();
            }
            return InputProcessing.Translate(input);
        }
        public void Attack(int[] square, Player opponent)
        {
            foreach(Ship ship in opponent.Ships)
            {

                for(int i = 0; i < ship.Location.Length; i++)
                {
                    if (ship.Location[i][0] == square[0] && ship.Location[i][1] == square[1])
                    {
                        ship.SectionIsDamaged[i] = true;
                        board.HitsMisses[square[0]][square[1]] = "X";

                        opponent.board.UpdateShipPositions(opponent.ships);
                        return;
                    }
                    else
                    {
                        board.HitsMisses[square[0]][square[1]] = "O";

                    }
                }
            }
            opponent.board.UpdateShipPositions(opponent.ships);
        }
        public void CheckIfNoRemainingShips()
        {
            foreach(Ship ship in ships)
            {
                ship.CheckIfSunk();
                if (!ship.IsSunk)
                {
                    Console.ReadLine();
                    return;
                }
            }
            hasActiveShips = false;
        }
        public void SetUpShips()
        {
            bool playerIsReady = false;
            int selectedShipsIndex = 0;
            bool overlap = false;
            while (!playerIsReady)
            {
                
                Console.Clear();
                board.Reset();
                board.UpdateShipPositions(ships);
                board.Display();
                Console.WriteLine("Use arrow keys to move ships, r to rotate, a/d to select a different ship. Press p when finished.");
                if (overlap) { Console.WriteLine("Please make sure no ships overlap!"); }
                ConsoleKeyInfo input = Console.ReadKey();

                switch (input.KeyChar)
                {
                    case 'a':
                        if(selectedShipsIndex == 0)
                        {
                            selectedShipsIndex = ships.Length-1;
                        }
                        else
                        {
                            selectedShipsIndex--;
                        }
                        break;
                    case 'd':
                        selectedShipsIndex++;
                        selectedShipsIndex %= ships.Length;
                        break;
                    case 'r':
                        ships[selectedShipsIndex].Rotate();
                        break;
                    case 'p':
                        if (ShipsOverlap())
                        {
                            overlap = true;
                        }
                        else
                        {
                            Console.WriteLine("Are you sure this is the ship configuration you want? Theres no chainging it after this. Press y to coninue or any other key to go back.");
                            if(Console.ReadKey().KeyChar == 'y')
                            {
                                playerIsReady = !playerIsReady;
                            }
                            
                        }
                        break;
                    default:
                        ships[selectedShipsIndex].Move(input.Key.ToString()); // If the input is not arrow keys, Ship.Move does nothing.
                        break;
                }

            }
        }
        private bool ShipsOverlap()
        {
            for (int i = 0; i < ships.Length; i++) // i is one Ship
            {
                for (int j = i + 1; j < ships.Length; j++) // j is another Ship
                {

                    if (ships[i].IsHorizontal && ships[j].IsHorizontal)
                    {
                        if (ships[j].Nose[1] == ships[i].Nose[1])
                        {
                            if (ships[j].Nose[0] <= ships[i].Tail[0] && ships[j].Nose[0] >= ships[i].Nose[0])
                            {
                                return true;
                            }
                            if (ships[j].Tail[0] <= ships[i].Tail[0] && ships[j].Tail[0] >= ships[i].Nose[0])
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                    else if (!ships[i].IsHorizontal && !ships[j].IsHorizontal)
                    {
                        if (ships[j].Nose[0] == ships[i].Nose[0])
                        {
                            if (ships[j].Nose[1] <= ships[i].Tail[1] && ships[j].Nose[1] >= ships[i].Nose[1])
                            {
                                return true;
                            }
                            if (ships[j].Tail[1] <= ships[i].Tail[1] && ships[j].Tail[1] >= ships[i].Nose[1])
                            {
                                return true;
                            }
                        }
                    }
                    else if (ships[j].IsHorizontal && !ships[i].IsHorizontal)
                    {
                        // if j shares a row with i
                        if (ships[j].Nose[1] >= ships[i].Nose[1] && ships[j].Nose[1] <= ships[i].Tail[1])
                        {
                            if (ships[j].Nose[0] <= ships[i].Nose[0] && ships[j].Tail[0] >= ships[i].Nose[0])
                            {
                                return true;
                            }
                        }
                    }
                    else if (!ships[j].IsHorizontal && ships[i].IsHorizontal)
                    {
                        // if j shares a column with i
                        if (ships[j].Nose[0] >= ships[i].Nose[0] && ships[j].Nose[0] <= ships[i].Tail[0])
                        {
                            if (ships[j].Nose[1] <= ships[i].Nose[1] && ships[j].Tail[1] >= ships[i].Nose[1])
                            {
                                return true;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("A 5th combination of 2 booleans has been found.");
                    }
                }
            }
            return false;
        }



    }
}
