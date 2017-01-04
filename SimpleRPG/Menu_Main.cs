using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    partial class Menu
    {
        public static void introDescription(out int xCoord, out int yCoord)
        {
            xCoord = 1;
            yCoord = 7;

            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("***Welcome to the world of Gladius***");
            yCoord += 2;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("Insert beginning story here, how did character get here?  I think I want to be oppressed by the Caesar, ");
            yCoord++;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("Maybe have an intimite family relationship with him, and fight him in the end. Yes, just like the movie.");
            yCoord += 2;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.WriteLine("***Roll your character stats until satisfied, Gladiator***");
            yCoord += 2;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.WriteLine("Can you fight, or are you just another morsel for Caesar's lions?");
            yCoord++;

        }

        public static void MainMenu(GameCharacter f, int enemyPick)
        {
            bool keepGoing = true;
            int xCoord = 1, yCoord = 18, originalYCoord = yCoord;

            do
            {
                CharacterInfoBlock.ClearStatMenuBlock(xCoord);
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("***Gladius Main Menu***");
                yCoord += 2;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Choose an option, {0}, and make it quick.", f.CharacterInfo["Name"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("The Emperor arrives soon, and he wants to see blood.");
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("E)nter Arena");
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("C)haracter Options ***NOT IMPLEMENTED(yet)***");
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("V)iew Active Gladiator***NOT IMPLEMENTED(yet)***");
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Q)uit");
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
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
                    yCoord++;
                    Console.SetCursorPosition(xCoord, yCoord);
                    Console.WriteLine("Invalid input.  Press any key to try again.");
                    var errorKeystroke = Console.ReadKey().Key;
                    yCoord = originalYCoord;
                }//end catch
            }
            while (keepGoing == true);
        }

        public static void WinGame()
        {
            int xCoord = 1, yCoord = 7;

            CharacterInfoBlock.ClearInfoBlock();
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("You have destroyed the evil Caesar and Rome is soon overrun by Barbarians.  Congratulations, you just ruined civilization as we know it.");
            yCoord++;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("Press any key to exit.");
            var input = Console.ReadKey().Key;
            System.Environment.Exit(1);
        }

        public static void QuitGame()
        {
            int xCoord = 1, yCoord = 7;

            CharacterInfoBlock.ClearInfoBlock();
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("Thank you for playing, goodbye for now. Press any key to continue.");
            var input = Console.ReadKey().Key;
            System.Environment.Exit(1);

        }
    }
}
