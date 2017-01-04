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
            Console.SetCursorPosition(2, 0);
            for (int i = 0; i <= 155; i++)
                Console.Write("-");
            for (int a = 1; a <= 41; a++)
            {
                Console.SetCursorPosition(0, a);
                Console.Write("|");
                Console.SetCursorPosition(159, a);
                Console.Write("|");
            }
            Console.SetCursorPosition(2, 42);
            for (int i = 0; i <= 155; i++)
                Console.Write("-");
        }

        public static void characterStatsWindow(Dictionary<string, string> characterStats)
        {
            Console.SetCursorPosition(1, 22);
            Console.WriteLine(characterStats);
        }
    }
}
