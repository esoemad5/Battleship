/* This code is not inteded for use in the final program.
 * It's all code used for various tests during production.
 * It has been saved here for reference and in case any part of it needed in further tests.
 */

 // Tests Game.ShipsOverlap
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
 
 
 // Tests Ship.Move and Ship.Rotate
Console.WriteLine("---------------------------");
Ship testShip = new Ship(4, "Battleship", 20);
ShowLocation(testShip.location);
for(int i = 0; i < 18; i++)
{
	testShip.Move("RightArrow");
}

ShowLocation(testShip.location);

testShip.Rotate();
ShowLocation(testShip.location);
 
 
 // Useful function when the Board class is unfinished.
public static void ShowLocation(int[][] input)
{
	foreach (int[] square in input)
	{
		Console.WriteLine("({0}, {1})", square[0], square[1]);
		
	}
	Console.WriteLine("---------------------------");
}
// How to check for arrow keys.
for(int i = 0; i < 5; i++){
	ConsoleKeyInfo a = Console.ReadKey();
	Console.WriteLine(a.Key.ToString());
	Console.WriteLine(a.KeyChar.ToString());
	if(a.Key.ToString() == "UpArrow")
	{
		Console.WriteLine("Hello World!");

	}
}



// show fake board
for(int i = 0; i < 50; i++)
{
	for(int j = 0; j < 90; j++)
	{
		Console.Write('X');
	}
	Console.WriteLine(i); // fullscreen shows 40 lines for me, not good for a 20x20 board, have to show boards left-right rather than top-bottom
}
