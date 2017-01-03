using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    class GameScreen
    {
        public static void drawScreen()
        {
            // Draw GUI;
            // Draw Stats;

            // Draw game area
            Console.SetCursorPosition(2, 0);
            for (int i = 0; i <= 155; i++)
                Console.Write("_");
            for (int a = 1; a <= 39; a++)
            {
                Console.SetCursorPosition(0, a);
                Console.WriteLine("|");
                Console.SetCursorPosition(159, a);
                Console.WriteLine("|");
                Console.SetCursorPosition(41, a);
                Console.WriteLine("|");
            }
            Console.SetCursorPosition(2, 40);
            for (int i = 0; i <= 155; i++)
                Console.Write("_");
            Console.SetCursorPosition(1, 21);
            for (int i = 1; i <= 40; i++)
                Console.Write("-");

            //added to show the bottom two lines that can be used for extra info if needed
            Console.SetCursorPosition(0, 41);
            Console.WriteLine("this is just to put some text at the bottom of the screen to");
            Console.Write("illustrate the two spare lines at the bottom of the screen");
        }

        public static void characterStatsWindow(Dictionary<string, string> characterStats)
        {
            Console.SetCursorPosition(1, 22);
            Console.WriteLine(characterStats);
        }
    }
}
