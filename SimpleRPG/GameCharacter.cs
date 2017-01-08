using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    class GameCharacter
    {
        //GameCharacter class fields
        public Dictionary<string, int> CharacterStats { get; set; }
        public Dictionary<string, string> CharacterInfo { get; set; }

        //GameCharacter base constructor
        #region GameCharacter Ctor, uses a dictionary built in the Roller class to add the core stats to fields and props

        public GameCharacter()
        {

            CharacterInfo = new Dictionary<string, string>()
            {
                {"Name","Glad Jr" },
                {"Weapon", "Fists" },
                {"Armor", "Cloth" },
                {"TagLineSoft","Whatever!" },
                {"TagLineTough","I'm gonna wreck it!" },
                {"Description","I am the greatest!" },
                {"SpecialMove","You focus all of your energy into a mighty finishing blow that staggers the enemy." }
            };

            CharacterStats = new Dictionary<string, int>()
            {
                {"Strength", 0 },
                {"Agility", 0 },
                {"Intelligence", 0 },
                {"Luck", 0 },
                {"Charisma",0 },
                {"Constitution",0 },
                {"Spirit", 0 },
                {"Fury", 0 },
                {"Notoriety", 0 },
                {"Fame", 0 },
                {"Money", 0 },
                {"MoneyEarned", 0 },
                {"CurrentHitPoints", 0 },
                {"MaxHitPoints", 0 },
                {"XP", 0 },
                {"Level", 1 },
                {"Kills", 0 }
            };

        }
        #endregion

        //GameCharacter methods
        #region GameCharacter Methods
        public int AttackEnemy()
        {
            int toHit = Roller.rollXSidedDice(20, 1, 1) + (CharacterStats["Strength"] + (CharacterStats["Agility"] / 2)
                + (CharacterStats["Intelligence"] / 2) + (CharacterStats["Luck"] / 2));
            return toHit;
        }

        public int RangedAttack(int range)
        {
            int looseArrow = Roller.rollXSidedDice(8, 1, 1) + (CalculateAgilityBonus(CharacterStats["Agility"]));

            return looseArrow;
        }

        public int Avoid()
        {
            int avoid = Roller.rollXSidedDice(20, 1, 1) + (CharacterStats["Agility"] + (CharacterStats["Constitution"] / 2)
                + (CharacterStats["Intelligence"] / 2) + (CharacterStats["Luck"] / 2));
            return avoid;
        }

        public int CalculateDamage()
        {
            int inflict = (Roller.rollXSidedDice(12, 1, 1) + CalculateStrengthBonus(CharacterStats["Strength"]));
            return inflict;
        }

        public int CalculateRanged()
        {
            int thwump = ((CharacterStats["Agility"] / 4) + (CharacterStats["Intelligence"] / 4) + (Roller.rollXSidedDice(6, 1, 1)));

            return thwump;
        }

        public int ReceiveDamage(int damage)
        {
            CharacterStats["CurrentHitPoints"] -= damage;
            return damage;
        }

        public static List<int> CalculateBaseAtkBonus(int level, int attackValueModifier)
        {
            int modifier, attackBonus;
            List<int> attack = new List<int>();

            modifier = level / attackValueModifier;

            for (int i = 0; i <= modifier; i++)
            {
                if (level < attackValueModifier || i == 0)
                    attackBonus = level;
                else
                    attackBonus = (level - (i * attackValueModifier)) + 1;
                attack.Add(attackBonus);
            }

            return attack;
        }

        public static int CalculateStrengthBonus(int Strength)
        {//calculates the effect of strength on melee attack roll / damage)
            int strengthBonus = 0;
            if (Strength > 21)
                strengthBonus = 6;
            else if (Strength > 19)
                strengthBonus = 5;
            else if (Strength > 17)
                strengthBonus = 4;
            else if (Strength > 15)
                strengthBonus = 3;
            else if (Strength > 13)
                strengthBonus = 2;
            else if (Strength > 11)
                strengthBonus = 1;
            else if (Strength < 10)
                strengthBonus = -1;
            else if (Strength < 8)
                strengthBonus = -2;
            else if (Strength < 6)
                strengthBonus = -3;
            else
                strengthBonus = 0;

            return strengthBonus;
        }

        public static int CalculateAgilityBonus(int Agility)
        {//calculates the effect of agility on ranged attack roll / armor class)
            int agilityBonus = 0;
            if (Agility > 21)
                agilityBonus = 6;
            else if (Agility > 19)
                agilityBonus = 5;
            else if (Agility > 17)
                agilityBonus = 4;
            else if (Agility > 15)
                agilityBonus = 3;
            else if (Agility > 13)
                agilityBonus = 2;
            else if (Agility > 11)
                agilityBonus = 1;
            else if (Agility < 10)
                agilityBonus = -1;
            else if (Agility < 8)
                agilityBonus = -2;
            else if (Agility < 6)
                agilityBonus = -3;
            else
                agilityBonus = 0;

            return agilityBonus;
        }

        public static GameCharacter CharCreator(int xCoord, int yCoord, GameCharacter Character)
        {
            //creates new fighter and invokes roll character stats method as a parameter.  
            Dictionary<string, int> characterStats = Character.CharacterStats;
            Dictionary<string, string> characterInfo = Character.CharacterInfo;
            int originalYCoord = 7;

            //gets character name and assigns to Name prop
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("Tell me your name, prisoner. ");
            Character.CharacterInfo["Name"] = Console.ReadLine();
            RollCharStats(ref characterStats, xCoord, originalYCoord);
            Character.CharacterStats = characterStats;
            //int enemyPick = 1;
            //creates new MainMenu and passes fighter as a parameter to the method (same instance throughout program is the goal)
            //Menu.MainMenu(fighter, enemyPick);
            return Character;
        }

        public static void RollCharStats(ref Dictionary<string, int> characterStats, int xCoord, int yCoord)
        {
            
            // just keeps the while loop going
            bool rolling = true;
            int originalYCoord = yCoord;

            while (rolling)
            {
                //roll stats for GameCharacter
                #region actual rolls for character core stats
                characterStats["Strength"] = Roller.rollXSidedDice(6, 2, 3);
                characterStats["Agility"] = Roller.rollXSidedDice(6, 2, 3);
                characterStats["Intelligence"] = Roller.rollXSidedDice(6, 2, 3);
                characterStats["Luck"] = Roller.rollXSidedDice(6, 2, 3);
                characterStats["Charisma"] = Roller.rollXSidedDice(6, 2, 3);
                characterStats["Constitution"] = Roller.rollXSidedDice(6, 2, 3);
                characterStats["MaxHitPoints"] = (characterStats["Constitution"] * 4);
                characterStats["CurrentHitPoints"] = characterStats["MaxHitPoints"];
                #endregion

                CharacterInfoBlock.ClearInfoBlock();

                #region displaying stats to the user and prompting to continue or roll again
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Your strength is:   \t\t {0}", characterStats["Strength"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Your agility is:\t\t  {0}", characterStats["Agility"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Your intelligence is:\t\t  {0}", characterStats["Intelligence"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Your luck is:\t\t\t  {0}", characterStats["Luck"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Your charisma is:\t\t  {0}", characterStats["Charisma"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Your constitution is:\t\t  {0}", characterStats["Constitution"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Your max hit points are:\t  {0}", characterStats["MaxHitPoints"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Are you satisfied with your stats and ready to proceed? (Y/N)");
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                #endregion


                // if statement that checks if the user wishes to continue or re-roll
                // and adds stats rolled in last region to the Dictionary returned in
                // this method
                #region if statement
                var input = Console.ReadKey().Key;
                switch (input)
                {
                    //goes to the Arena Menu (TO-DO)
                    case ConsoleKey.Y:
                    // adding rolled attributes to dictionary 
                        characterStats["Spirit"] = 0;
                        characterStats["Fury"] = 0;
                        characterStats["Notoriety"] = 0;
                        characterStats["Fame"] = 0;
                        characterStats["Money"] = 0;
                        characterStats["MoneyEarned"] = 0;
                        characterStats["Level"] = 1;
                        characterStats["Kills"] = 0;
                        rolling = false;
                        break;
                    case ConsoleKey.N:
                        // continue loop
                        rolling = true;
                        yCoord = originalYCoord;
                        break;
                    default:
                        // try again if fat-finger
                        yCoord++;
                        Console.SetCursorPosition(xCoord, yCoord);
                        Console.Write("Please enter a valid input");
                        yCoord = originalYCoord;
                        break;
                    #endregion
                }// end if

            }// end while

            CharacterInfoBlock.ClearInfoBlock();

        }//end RollCharStats method 

        public void LevelUp()
        {
            int choice = 2, xCoord = 1, yCoord = 7, originalYCoord = yCoord;

            do
            {
                CharacterInfoBlock.ClearInfoBlock();
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("*You feel empowered from all of your recent combat experience and training*");
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Congratulations on your advancement, please choose {0} ability scores to improve:", choice);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("1) Strength - current value {0}", CharacterStats["Strength"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("2) Agility - current value {0}", CharacterStats["Agility"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("3) Intelligence - current value {0}", CharacterStats["Intelligence"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("4) Charisma - current value {0}", CharacterStats["Charisma"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("5) Luck - current value {0}", CharacterStats["Luck"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("6) Constitution - current value {0}", CharacterStats["Constitution"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("You have {0} hit points. (You get an additional 10 for every (Con) pt. and for every level.", CharacterStats["MaxHitPoints"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Please enter the number of the stat to increase.  You have {0} choices remaining: ", choice);
                var input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        CharacterStats["Strength"]++;
                        choice--;
                        break;
                    case ConsoleKey.D2:
                        CharacterStats["Agility"]++;
                        choice--;
                        break;
                    case ConsoleKey.D3:
                        CharacterStats["Intelligence"]++;
                        choice--;
                        break;
                    case ConsoleKey.D4:
                        CharacterStats["Charisma"]++;
                        choice--;
                        break;
                    case ConsoleKey.D5:
                        CharacterStats["Luck"]++;
                        choice--;
                        break;
                    case ConsoleKey.D6:
                        CharacterStats["Constitution"]++;
                        CharacterStats["MaxHitPoints"] += 10;
                        CharacterStats["CurrentHitPoints"] += 10;
                        choice--;
                        break;
                    default:
                        yCoord++;
                        Console.SetCursorPosition(xCoord, yCoord);
                        Console.Write("Invalid Selection.  Press any key to try again.");
                        var errorKeystroke = Console.ReadKey().Key;
                        yCoord = originalYCoord;
                        break;

                }//end switch

                yCoord = originalYCoord;

            } while (choice > 0);

            CharacterInfoBlock.ClearInfoBlock();
            CharacterStats["MaxHitPoints"] += 5;
            CharacterStats["CurrentHitPoints"] += 5;

        }//end LevelUp()

        public void PlayerCharacterDie(GameCharacter fighter, ref int[,] roomCoordinates)
        {
            int xCoord = 1, yCoord = 7, originalYCoord = yCoord;
            bool correctSelection = true;

            do
            {
                CharacterInfoBlock.ClearInfoBlock();
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("{0} has died and has gone to Valhalla with the others who \n have died a glorious death in the arena.", fighter.CharacterInfo["Name"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("Do you wish to start a new game?");
                var input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.Y:
                        //enter game stats here
                        int enemyPick = 1;
                        CharacterRoom.EraseAndResetRoom(ref roomCoordinates);
                        Menu.MainMenu(GameCharacter.CharCreator(xCoord, originalYCoord, fighter), enemyPick, ref roomCoordinates);
                        break;
                    case ConsoleKey.N:
                        //enter stats here (kills, money, fame, etc.)
                        yCoord++;
                        Console.SetCursorPosition(xCoord, yCoord);
                        Console.WriteLine("Come back to the arena soon");
                        Menu.QuitGame();
                        break;
                    default:
                        yCoord++;
                        Console.SetCursorPosition(xCoord, yCoord);
                        Console.WriteLine("Invalid selection.  Press any key to try again.");
                        var errorKeystroke = Console.ReadKey().Key;
                        correctSelection = false;
                        yCoord = originalYCoord;
                        break;

                }
            }
            while (!correctSelection);

        }

        public void NPCDie(GameCharacter fighter, GameCharacter enemy, int enemyPick, ref int[,] roomCoordinates)
        {
            int xCoord = 1, yCoord = 7;

            CharacterInfoBlock.ClearInfoBlock();
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("You have felled the notorious gladiator, {0}", enemy.CharacterInfo["Name"]);
            yCoord++;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("You collect your reward and hear the crowd cheer as you exit the arena");            
            fighter.CharacterStats["Fame"] += (enemy.CharacterStats["Notoriety"] * 2 + fighter.CharacterStats["Notoriety"]);
            var charismaMod = (fighter.CharacterStats["Charisma"] / 2);
            charismaMod += fighter.CharacterStats["Fame"];
            fighter.CharacterStats["Money"] += (enemy.CharacterStats["Notoriety"] * 500);
            yCoord++;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("You earned {0} Caesars for winning in the arena!", fighter.CharacterStats["Money"]);
            fighter.CharacterStats["MoneyEarned"] += fighter.CharacterStats["Money"];
            yCoord++;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("You have earned {0} Caesars in your career to date.", fighter.CharacterStats["MoneyEarned"]);
            fighter.CharacterStats["Fury"] = 0;
            fighter.CharacterStats["Spirit"] = 0;
            fighter.CharacterStats["Notoriety"]++;
            fighter.CharacterStats["Kills"]++;
            fighter.CharacterStats["Level"]++;
            yCoord++;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("You have offed {0} enemy gladiators.", fighter.CharacterStats["Kills"]);
            fighter.CharacterStats["CurrentHitPoints"] = fighter.CharacterStats["MaxHitPoints"];
            enemyPick++;
            if (enemyPick > 6)
                Menu.WinGame();
            yCoord++;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("You head back to the Gladiator quarters for some much-needed rest");
            yCoord++;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("Press any key to continue");
            var input = Console.ReadKey().Key;
            fighter.LevelUp();
            CharacterRoom.EraseAndResetRoom(ref roomCoordinates);
            Menu.MainMenu(fighter, enemyPick,ref roomCoordinates);

        }//end enemyDie



        #endregion

    }//end GameCharacter Class
}
