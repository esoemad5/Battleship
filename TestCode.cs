/* This code is not inteded for use in the final program.
 * It's all code used for various tests during production.
 * It has been saved here for reference and in case any part of it needed in further tests.
 */

 // Useful function when the Board class is unfinished.
 static void ShowLocation(Ship ship)
{
	foreach (int[] square in ship.location)
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
