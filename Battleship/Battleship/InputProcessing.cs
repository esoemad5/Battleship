using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    static class InputProcessing
    {

        public static bool Validate(string input, int boardSize)
        {
            try
            {


                if (Char.ToUpper(input[0]) - 64 <= boardSize && Char.ToUpper(input[0]) - 64 >= 1)
                {

                    if (Convert.ToInt32(input.Substring(1)) < boardSize)
                    {
                        return true;
                    }

                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public static int[] Translate(string input)
        {
            int[] output = new int[2];
            output[1] = Char.ToUpper(input[0]) - 65; // Converts a to 0, B to 1, c to 2, etc... regardless of casing
            output[0] = Convert.ToInt32(input.Substring(1)) - 1;
            return output;
        }
    }
}
