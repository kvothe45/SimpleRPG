using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    partial class Menu
    {
        public static void ArenaMenu(GameCharacter f, int enemyPick)
        {
            bool keepGoing = true;
            int xCoord = 1, yCoord = 18, originalYCoord = yCoord;

            do
            {
                CharacterInfoBlock.ClearStatMenuBlock(xCoord);
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("***Arena Menu***");
                yCoord += 2;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("A massive, scarred-up, retired Gladiator looks you");
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("up and down and says: ");
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Welcome to the Arena, runt. What can I do for you? ");
                yCoord += 2;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("P)ractice (***not implemented yet***");
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("F)ight Opponent");
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("E)quipment Store(***not implemented yet***");
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("G)o back to Main Menu");
                var input = Console.ReadKey().Key;
                try
                {
                    switch (input)
                    {
                        case ConsoleKey.P:
                            //goes to Practice Fight vs. Pip (TO-DO)
                            break;
                        //goes to the Combat Menu
                        case ConsoleKey.F:
                            GameCharacter enemy = new GameCharacter();
                            enemy = StaticEnemies.PreMadeEnemies(enemy, f, enemyPick);
                            yCoord += 2;
                            Console.SetCursorPosition(xCoord, yCoord);
                            Console.Write("You will be fighting {0} in the arena!", enemy.CharacterInfo["Name"]);
                            Menu.CombatMenu(f, enemy, enemyPick);
                            break;
                        //goes to Gladiator Store (TO-DO)
                        case ConsoleKey.C:
                            break;
                        //goes to Character View Page (TO-DO)
                        case ConsoleKey.G:
                            Menu.MainMenu(f, enemyPick);
                            break;
                        //throws exception if format is screwy
                        default:
                            //throw new FormatException("Incorrect input, please try again.");
                            break;
                    }//end switch

                }//end try
                catch (FormatException)
                {
                    yCoord++;
                    Console.SetCursorPosition(xCoord, yCoord);
                    Console.Write("Invalid input.  Press any key to try again.");
                    var errorKeystroke = Console.ReadKey().Key;
                    yCoord = originalYCoord;
                }//end catch
            }
            while (keepGoing == true);
        }//end method         
    }
}
