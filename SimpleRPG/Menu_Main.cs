using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    partial class Menu
    {
        public static void introDescription()
        {
            Console.Clear();
            Console.WriteLine("***Welcome to the world of Gladius***");
            Console.WriteLine();
            //TO-DO write story
            Console.WriteLine("Insert beginning story here, how did character get here?  I think I want to be oppressed by the Caesar, ");
            Console.WriteLine("Maybe have an intimite family relationship with him, and fight him in the end. Yes, just like the movie.");
            Console.WriteLine();
            Console.WriteLine("***Roll your character stats until satisfied, Gladiator***");
            Console.WriteLine();
            Console.WriteLine("Can you fight, or are you just another morsel for Caesar's lions?");
            Console.WriteLine();
        }

        public static void MainMenu(GameCharacter f, int enemyPick)
        {
            bool keepGoing = true;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("***Gladius Main Menu***");
                Console.WriteLine();
                Console.WriteLine("Choose an option, {0}, and make it quick.", f.CharacterInfo["Name"]);
                Console.WriteLine("The Emperor arrives soon, and he wants to see blood.\n");
                Console.WriteLine("E)nter Arena");
                Console.WriteLine("C)haracter Options ***NOT IMPLEMENTED(yet)***");
                Console.WriteLine("V)iew Active Gladiator***NOT IMPLEMENTED(yet)***");
                Console.WriteLine("Q)uit");
                var input = Console.ReadKey().Key;
                try
                {//make sure user doesn't fat finger this menu, 
                 //wanted to implement String.ToLower, but can't 
                 //get it to work at this time (do more research)

                    switch (input)
                    {
                        //goes to the Arena Menu (TO-DO)
                        case ConsoleKey.E:
                            Menu.ArenaMenu(f, enemyPick);
                            break;
                        //goes to Options Menu
                        case ConsoleKey.C:
                            break;
                        //goes to Character View Page (TO-DO)
                        case ConsoleKey.V:
                            break;
                        //quits game, prompts save (TO-DO)
                        case ConsoleKey.Q:
                            //SaveGame();
                            QuitGame();
                            keepGoing = false;
                            break;
                        //starts loop over when user inputs something other than menu 
                        default:
                            throw new FormatException();

                    }//end switch

                }//end try
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid input, please try again.");
                    //MainMenu mm = new MainMenu(f, enemyPick);
                }//end catch
            }
            while (keepGoing == true);
        }

        public static void WinGame(GameCharacter f)
        {
            Console.WriteLine("You have destroyed the evil Caesar and Rome is soon overrun by Barbarians.\n  Congratulations, you just ruined civilization as we know it.");
            Console.ReadLine();
            System.Environment.Exit(1);
        }

        public static void QuitGame()
        {
            Console.WriteLine("Thank you for playing, goodbye for now. Press any key to continue.");
            Console.ReadLine();
            System.Environment.Exit(1);

        }
    }
}
