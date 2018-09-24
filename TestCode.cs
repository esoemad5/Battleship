/* This code is not inteded for use in the final program.
 * It's all code used for various tests during production.
 * It has been saved here for reference and in case any part of it needed in further tests.
 */

 
// Exploring options for displaying Boards
int p = 5;
p = p / 2;
Console.WriteLine("{0}", p);
char[][] test = new char[20][];
for(int i = 0; i < test.Length; i++)
{
	test[i] = new char[20];
	for(int j = 0; j<test[i].Length; j++)
	{
		test[i][j] = '-';
	}
}
Console.Write("  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20"); //60 characters, 3 per number
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
			
// Spacing for displaying boards
for(int i = 0; i < 20; i++)
{
	//Console.WriteLine("--------------------");
	Console.WriteLine("....................");
}
for (int i = 0; i < 20; i++)
{
	Console.WriteLine(". . . . @ @ x @ . o o . . . . . . . . ."); // this spacing is good
}
 
 
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
