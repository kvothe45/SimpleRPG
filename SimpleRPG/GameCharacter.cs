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

        public static GameCharacter CharCreator(GameCharacter Character)
        {
            //creates new fighter and invokes roll character stats method as a parameter.  
            Dictionary<string, int> characterStats = Character.CharacterStats;
            Dictionary<string, string> characterInfo = Character.CharacterInfo;

            //gets character name and assigns to Name prop
            Console.Write("Tell me your name, prisoner. ");
            Character.CharacterInfo["Name"] = Console.ReadLine();
            RollCharStats(ref characterStats);
            Character.CharacterStats = characterStats;
            //int enemyPick = 1;
            //creates new MainMenu and passes fighter as a parameter to the method (same instance throughout program is the goal)
            //Menu.MainMenu(fighter, enemyPick);
            return Character;
        }

        public static void RollCharStats(ref Dictionary<string, int> characterStats)
        {
            int strengthRaw, agilityRaw, intelligenceRaw, luckRaw, charismaRaw,
            constitutionRaw, maxHitPointsRaw, currentHitPointsRaw, maxRaw;

            // just keeps the while loop going
            bool rolling = true;

            while (rolling)
            {
                //roll stats for GameCharacter
                #region actual rolls for character core stats
                strengthRaw = Roller.rollXSidedDice(6, 2, 3);
                agilityRaw = Roller.rollXSidedDice(6, 2, 3);
                intelligenceRaw = Roller.rollXSidedDice(6, 2, 3);
                luckRaw = Roller.rollXSidedDice(6, 2, 3);
                charismaRaw = Roller.rollXSidedDice(6, 2, 3);
                constitutionRaw = Roller.rollXSidedDice(6, 2, 3);
                maxHitPointsRaw = (constitutionRaw * 4);
                maxRaw = maxHitPointsRaw;
                currentHitPointsRaw = maxRaw;
                #endregion

                #region displaying stats to the user and prompting to continue or roll again
                Console.WriteLine("Your strength is:   \t\t {0}  \n", strengthRaw);
                Console.WriteLine("Your agility is:\t\t  {0} \n", agilityRaw);
                Console.WriteLine("Your intelligence is:\t\t  {0} \n", intelligenceRaw);
                Console.WriteLine("Your luck is:\t\t\t  {0} \n", luckRaw);
                Console.WriteLine("Your charisma is:\t\t  {0} \n", charismaRaw);
                Console.WriteLine("Your constitution is:\t\t  {0} \n", constitutionRaw);
                Console.WriteLine("Your max hit points are:\t  {0} \n", maxHitPointsRaw);
                Console.WriteLine("Your current hit points are:\t  {0} \n", currentHitPointsRaw);

                Console.Write("Are you satisfied with your stats and ready to proceed? (Y/N)\n ");
                string input = Console.ReadLine();
                #endregion


                // if statement that checks if the user wishes to continue or re-roll
                // and adds stats rolled in last region to the Dictionary returned in
                // this method
                #region if statement

                if (input == "Y" || input == "y")
                {// adding rolled attributes to dictionary 
                    characterStats["Strength"] = strengthRaw;
                    characterStats["Agility"] = agilityRaw;
                    characterStats["Intelligence"] = intelligenceRaw;
                    characterStats["Luck"] = luckRaw;
                    characterStats["Charisma"] = charismaRaw;
                    characterStats["Constitution"] = constitutionRaw;
                    characterStats["MaxHitPoints"] = maxHitPointsRaw;
                    characterStats["CurrentHitPoints"] = currentHitPointsRaw;
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
                }
                else if (input == "N" || input == "n")
                {// continue loop
                    rolling = true;
                }
                else
                {// try again if fat-finger
                    Console.WriteLine("Please enter a valid input");
                    #endregion
                }// end if

            }// end while

        }//end RollCharStats method 

        public void LevelUp()
        {
            int addStats = 0;
            int pickStat = 0;
            int choice = 2;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("*You feel empowered from all of your recent combat experience and training*");
                Console.WriteLine("Congratulations on your advancement, please choose 2 ability scores to improve:");
                Console.WriteLine("1) Strength - current value {0}", CharacterStats["Strength"]);
                Console.WriteLine("2) Agility - current value {0}", CharacterStats["Agility"]);
                Console.WriteLine("3) Intelligence - current value {0}", CharacterStats["Intelligence"]);
                Console.WriteLine("4) Charisma - current value {0}", CharacterStats["Charisma"]);
                Console.WriteLine("5) Luck - current value {0}", CharacterStats["Luck"]);
                Console.WriteLine("6) Constitution - current value {0}", CharacterStats["Constitution"]);
                Console.WriteLine("You have {0} hit points. (You get an additional 10 for every (Con) pt. and for every level.", CharacterStats["MaxHitPoints"]);
                Console.Write("Please enter the number of the stat to increase.\nYou have {0} choices remaining: ", choice);
                pickStat = Convert.ToInt32(Console.ReadLine());
                switch (pickStat)
                {
                    case 1:
                        CharacterStats["Strength"]++;
                        break;
                    case 2:
                        CharacterStats["Agility"]++;
                        break;
                    case 3:
                        CharacterStats["Intelligence"]++;
                        break;
                    case 4:
                        CharacterStats["Charisma"]++;
                        break;
                    case 5:
                        CharacterStats["Luck"]++;
                        break;
                    case 6:
                        CharacterStats["Constitution"]++;
                        CharacterStats["MaxHitPoints"] += 10;
                        CharacterStats["CurrentHitPoints"] += 10;
                        break;
                }//end switch
                addStats++;
                choice--;

            } while (addStats < 2);

            CharacterStats["MaxHitPoints"] += 5;
            CharacterStats["CurrentHitPoints"] += 5;

        }//end LevelUp()

        public void PlayerCharacterDie(GameCharacter fighter)
        {
            Console.WriteLine("{0} has died and has gone to Valhalla with the others who \n have died a glorious death in the arena.", fighter.CharacterInfo["Name"]);
            Console.WriteLine("Do you wish to start a new game?");
            string yesno = Console.ReadLine();
            yesno = yesno.ToLower();
            switch (yesno)
            {
                case "y":
                    {
                        //enter game stats here
                        int enemyPick = 1;

                        Menu.MainMenu(GameCharacter.CharCreator(fighter), enemyPick);
                        break;
                    }
                case "n":
                    {
                        //enter stats here (kills, money, fame, etc.)
                        Console.WriteLine("Come back to the arena soon");
                        Menu.QuitGame();
                        break;

                    }

            }

        }

        public void NPCDie(GameCharacter fighter, GameCharacter enemy, int enemyPick)
        {
            Console.WriteLine("You have felled the notorious gladiator, {0}", enemy.CharacterInfo["Name"]);
            Console.WriteLine("You collect your reward and hear the crowd cheer as you exit the arena");
            fighter.CharacterStats["Fame"] += (enemy.CharacterStats["Notoriety"] * 2 + fighter.CharacterStats["Notoriety"]);
            var charismaMod = (fighter.CharacterStats["Charisma"] / 2);
            charismaMod += fighter.CharacterStats["Fame"];
            fighter.CharacterStats["Money"] += (enemy.CharacterStats["Notoriety"] * 500);
            Console.WriteLine("You earned {0} Caesars for winning in the arena!", fighter.CharacterStats["Money"]);
            fighter.CharacterStats["MoneyEarned"] += fighter.CharacterStats["Money"];
            Console.WriteLine("You have earned {0} Caesars in your career to date.", fighter.CharacterStats["MoneyEarned"]);
            fighter.CharacterStats["Fury"] = 0;
            fighter.CharacterStats["Spirit"] = 0;
            fighter.CharacterStats["Notoriety"]++;
            fighter.CharacterStats["Kills"]++;
            fighter.CharacterStats["Level"]++;
            Console.WriteLine("You have offed {0} enemy gladiators.", fighter.CharacterStats["Kills"]);
            fighter.CharacterStats["CurrentHitPoints"] = fighter.CharacterStats["MaxHitPoints"];
            enemyPick++;
            if (enemyPick > 6)
                Menu.WinGame(fighter);

            Console.WriteLine("You head back to the Gladiator quarters for some much-needed rest");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            fighter.LevelUp();
            Menu.MainMenu(fighter, enemyPick);

        }//end enemyDie



        #endregion

    }//end GameCharacter Class
}
