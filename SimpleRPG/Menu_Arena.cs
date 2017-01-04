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

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("***Arena Menu***");
                Console.WriteLine();
                Console.WriteLine("A massive, scarred-up, retired Gladiator looks you up and down and says: ");
                Console.WriteLine("Welcome to the Arena, runt. What can I do for you? ");
                Console.WriteLine();
                Console.WriteLine("P)ractice (***not implemented yet***");
                Console.WriteLine("F)ight Opponent");
                Console.WriteLine("E)quipment Store(***not implemented yet***");
                Console.WriteLine("G)o back to Main Menu");
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
                            Console.WriteLine();
                            Console.WriteLine("You will be fighting {0} in the arena!", enemy.CharacterInfo["Name"]);
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
                    Console.WriteLine("Invalid input, try again.");
                }//end catch
            }
            while (keepGoing == true);
        }//end method         
    }
}
