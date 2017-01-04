using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    public static class Roller
    {

        //creates a static Random object that can be called throughout the entire namespace without red squigglies.
        private static Random rnd = new Random();
        //instance variable that is the return variable for rollXSidedDice() 
        public static int result;
        // get the corresponding die type from the method call 
        // and set diceType to the value of the argument 
        // passed
        public static int rollXSidedDice(int diceType, int minRoll, int numberOfDice)
        {

            result = 0;

            for (int i = 0; i < numberOfDice; i++)
            {
                result += rnd.Next(minRoll, diceType + 1);
            }

            return result;

        }//end method rollXSIdedDice      


       
    }//end class
}
