using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    partial class Menu
    {

        public static void CombatMenu(GameCharacter fighter, GameCharacter enemy, int enemyPick, ref int[,] roomCoordinates)
        {
            bool CombatActive = true;
            int range = 9, salve = 0, eSalve = 1, turn = 0, arrows = 4, eArrows = 4;
            int xCoord = 1, yCoord = 18, originalYCoord = yCoord, fighterStatXCoord = 53, enemyStatXCoord = 105, specialAttackYCoord = 10;

            CharacterRoom.DrawRoom(ref roomCoordinates);
            CharacterRoom.SetCharacters(roomCoordinates);
            //Boolean check in while loop keeps character in combat when actively fighting 
            while (CombatActive)
            {

                int f20Roll = Roller.rollXSidedDice(20, 1, 1);
                int e20Roll = Roller.rollXSidedDice(20, 1, 1);

                //conditional that prevents getting a new magic salve every round
                if (salve == 0 && turn == 0)
                {
                    CombatIntro(enemy, ref salve);
                    CharacterInfoBlock.StatBlockDisplay(fighterStatXCoord, fighter);
                    CharacterInfoBlock.StatBlockDisplay(enemyStatXCoord, enemy);
                }
                else
                {//displays character status during combat

                    BasicCombatInfo(fighter, enemy, range, arrows, salve, turn);

                    //Display Menu - perform menu actions
                    CharacterInfoBlock.ClearStatMenuBlock(xCoord);
                    Console.SetCursorPosition(xCoord, yCoord);
                    Console.Write("1) Melee Attack");
                    yCoord++;
                    Console.SetCursorPosition(xCoord, yCoord);
                    if (arrows > 0)
                    {
                        Console.Write("2) Ranged Attack");
                    }
                    else
                    {
                        Console.Write("!) You're out of arrows!  Use another attack.");
                    }
                    yCoord++;
                    Console.SetCursorPosition(xCoord, yCoord);
                    Console.Write("3) Close with Enemy");
                    yCoord++;
                    Console.SetCursorPosition(xCoord, yCoord);
                    Console.Write("4) Use salve");
                    yCoord++;
                    Console.SetCursorPosition(xCoord, yCoord);
                    Console.Write("5) Yield");

                    //conduct special attack if fighter's Fury or Spirit level is at 5 or greater
                    if (fighter.CharacterStats["Fury"] > 4 || fighter.CharacterStats["Spirit"] > 4)
                    {
                        yCoord++;
                        Console.SetCursorPosition(xCoord, yCoord);
                        Console.Write("6) Special Attack");
                        //alerts user as to why the special attack is available.
                        Console.SetCursorPosition(xCoord, specialAttackYCoord);
                        if (fighter.CharacterStats["Fury"] > 4)
                            Console.Write("Your fury is past the boiling point and {0} cringes from the look on your face", enemy.CharacterInfo["Name"]);
                        else if (fighter.CharacterStats["Spirit"] > 4)
                            Console.Write("You're in the zone, gladiator. The crowd marvels at your majestic skill.");
                    }
                    yCoord++;
                    Console.SetCursorPosition(xCoord, yCoord);
                    var input = Console.ReadKey().Key;
                    switch (input)
                    {
                        case ConsoleKey.D1:
                            CombatMelee(ref fighter, ref enemy, range, enemyPick, ref roomCoordinates);
                            turn++;
                            break;
                        case ConsoleKey.D2:
                            CombatRanged(ref fighter, ref enemy, ref range, ref arrows, enemyPick, ref roomCoordinates);
                            turn++;
                            break;
                        case ConsoleKey.D3:
                            CombatCloseDistance(ref range, ref roomCoordinates);
                            turn++;
                            break;
                        case ConsoleKey.D4:
                            CombatUseSalve(ref fighter, ref salve);
                            turn++;
                            break;
                        case ConsoleKey.D5:
                            break;
                        case ConsoleKey.D6:
                            CombatSpecialAttack(ref fighter, ref enemy, ref turn, yCoord, enemyPick, ref roomCoordinates);
                            break;
                        default:
                            yCoord++;
                            Console.SetCursorPosition(xCoord, yCoord);
                            Console.Write("That isn't a valid selection.  Press any key to try again.");
                            var errorKeystroke = Console.ReadKey().Key;
                            break;
                    }//end switch

                    CharacterInfoBlock.StatBlockDisplay(fighterStatXCoord, fighter);
                    CharacterInfoBlock.StatBlockDisplay(enemyStatXCoord, enemy);

                    CombatEnemyTurn(ref fighter, ref enemy, ref range, ref eSalve, ref eArrows, ref roomCoordinates);

                    CharacterInfoBlock.StatBlockDisplay(fighterStatXCoord, fighter);
                    CharacterInfoBlock.StatBlockDisplay(enemyStatXCoord, enemy);

                    yCoord = originalYCoord;

                }//end if

            }//end while                           

        }//end method       


        public static void CombatIntro(GameCharacter enemy, ref int salve)
        {
            int xCoord = 1, yCoord = 7;

            CharacterInfoBlock.ClearInfoBlock();
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("As you walk through the narrow pathway to the arena, a fair maiden hands you a satchel.  She says, \"Good luck, warrior. Take this");
            yCoord++;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("magic salve to heal your wounds during your fight.\"");

            salve += 1;

            yCoord++;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("Your coach, Leonardo Turtle, tells you a little something about your opponent that you may not have known: ");

            //TO-DO: add randomizer for different "fun facts" with the description 

            yCoord++;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("{0} ", enemy.CharacterInfo["Description"]);
            yCoord++;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("Press any key when your ready to start the fight.");
            var input = Console.ReadKey().Key;
        }

        //this takes up 3 lines of the 10
        public static void BasicCombatInfo(GameCharacter fighter, GameCharacter enemy, int range, int arrows, int salve, int turn)
        {
            int xCoord = 1, yCoord = 7, originalYCoord = yCoord, infoBlockDepth = 3;

            CharacterInfoBlock.ClearInfoBlock(yCoord, infoBlockDepth);
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("{0} is {1} passus away ('passus' is Roman for paces)", enemy.CharacterInfo["Name"], range);

            yCoord++;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("You have {0} arrows left\t\t", arrows);
            xCoord = 53;
            Console.SetCursorPosition(xCoord, yCoord);
            if (salve == 1)
                Console.Write("You have a salve handy");
            else
                Console.Write("You are out of salve");

            yCoord++;
            xCoord = 1;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("You have {0} hit points left\t\t", fighter.CharacterStats["CurrentHitPoints"]);
            xCoord = 53;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("The enemy has {0} hit points left\t\t", enemy.CharacterStats["CurrentHitPoints"]);
            xCoord = 105;
            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("You have fought {0} round(s)", turn);

        }

        public static void CombatMelee(ref GameCharacter fighter, ref GameCharacter enemy, int range, int enemyPick,
            ref int[,] roomCoordinates)
        {

            int xCoord = 1, yCoord = 11, originalYCoord = yCoord, infoBlockDepth = 6;

            CharacterInfoBlock.ClearInfoBlock(yCoord, infoBlockDepth);
            Console.SetCursorPosition(xCoord, yCoord);
            if (range < 2)
            {
                Console.Write("You swing your sword at the enemy, thoroughly expecting to lop his ugly head off.  You catch him on his heels and swing for the fences.");
                if (fighter.AttackEnemy() > enemy.Avoid())
                {
                    int damage1 = fighter.CalculateDamage();
                    enemy.ReceiveDamage(damage1);
                    yCoord++;
                    Console.SetCursorPosition(xCoord, yCoord);
                    Console.Write("You hit {0} for {1} damage", enemy.CharacterInfo["Name"], damage1);
                    fighter.CharacterStats["Spirit"]++;
                    enemy.CharacterStats["Fury"]++;
                    if (enemy.CharacterStats["CurrentHitPoints"] <= 0)
                    {
                        //ends combat when enemy dies from regular attack
                        //CombatActive = false;
                        fighter.NPCDie(fighter, enemy, enemyPick, ref roomCoordinates);
                    }
                }
                else
                {
                    Console.WriteLine("You miss");
                    fighter.CharacterStats["Spirit"]--;
                }
            }
            else
            {
                Console.Write("You're not close enough to perform that action.");
            }
        }

        public static void CombatRanged(ref GameCharacter fighter, ref GameCharacter enemy, ref int range, ref int arrows, int enemyPick,
            ref int[,] roomCoordinates)
        {

            int xCoord = 1, yCoord = 11, originalYCoord = yCoord, infoBlockDepth = 6;
            bool isPlayer;

            CharacterInfoBlock.ClearInfoBlock(yCoord, infoBlockDepth);
            Console.SetCursorPosition(xCoord, yCoord);
            if (range > 1)
            {
                Console.Write("You loose one of your {0} arrows towards the enemy", arrows);
                //if the fighter has an arrow, rolls and calculations are made to see if you hit 
                //it takes a perfect roll of 20 to hit at default range unless super skilled(1 in 20 shot)

                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                if (arrows > 0)
                {
                    if (fighter.RangedAttack(range) > range)
                    {
                        Console.Write("Bullseye! {0} grunts, clearly pissed off, and sprints at you angrily", enemy.CharacterInfo["Name"]);
                        isPlayer = false;
                        CharacterRoom.MoveCharacter(isPlayer, ref roomCoordinates, range);
                        range--;
                        enemy.CharacterStats["CurrentHitPoints"] -= fighter.CalculateRanged();
                        arrows--;
                        if (enemy.CharacterStats["CurrentHitPoints"] <= 0)
                        {
                            //ends combat when enemy dies from ranged attack
                            //CombatActive = false;
                            fighter.NPCDie(fighter, enemy, enemyPick, ref roomCoordinates);
                        }
                    }
                    else
                    {
                        Console.Write("You miss the enemy.");
                        arrows--;
                    }
                }
                else
                    Console.Write("You have no arrows");
            }
            else
            {
                Console.Write("You are too close to hit with your bow. Duh.");
                arrows--;
            }
        }

        public static void CombatCloseDistance(ref int range, ref int[,] roomCoordinates)
        {
            int xCoord = 1, yCoord = 11, originalYCoord = yCoord, infoBlockDepth = 6;
            bool isPlayer = true;

            CharacterInfoBlock.ClearInfoBlock(yCoord, infoBlockDepth);
            Console.SetCursorPosition(xCoord, yCoord);
            if (range > 1)
            {
                Console.Write("You sprint towards the enemy and make the craziest, most bloodthirsty face you can muster");
                CharacterRoom.MoveCharacter(isPlayer, ref roomCoordinates, range);
                range--;
            }
            else
            {
                Console.Write("You ram into the enemy by running full speed into him, say, \"mi Scusi\", and... ");
            }
        }

        public static void CombatUseSalve(ref GameCharacter fighter, ref int salve)
        {
            int xCoord = 1, yCoord = 11, originalYCoord = yCoord, infoBlockDepth = 6;

            CharacterInfoBlock.ClearInfoBlock(yCoord, infoBlockDepth);
            Console.SetCursorPosition(xCoord, yCoord);
            if (salve > 0)
            {
                Console.Write("You use the magic salve on your wounds, and feel better immediately");
                fighter.CharacterStats["CurrentHitPoints"] += (fighter.CharacterStats["MaxHitPoints"] - fighter.CharacterStats["CurrentHitPoints"]);
                salve--;
            }
            else
            {
                Console.Write("You don't have any magic salve left.");
            }
        }

        public static void CombatSpecialAttack(ref GameCharacter fighter, ref GameCharacter enemy, ref int turn, int statYCoord,
            int enemyPick, ref int[,] roomCoordinates)
        {
            int xCoord = 1, yCoord = 11, originalYCoord = yCoord, infoBlockDepth = 6, specialAttackYCoord = 10;

            CharacterInfoBlock.ClearInfoBlock(yCoord, infoBlockDepth);
            Console.SetCursorPosition(xCoord, yCoord);
            if (fighter.CharacterStats["Fury"] > 4 || fighter.CharacterStats["Spirit"] > 4)
            {
                Console.Write("You focus all of your energy into a mighty finishing blow that staggers the enemy.");
                infoBlockDepth = 1;
                CharacterInfoBlock.ClearInfoBlock(specialAttackYCoord, infoBlockDepth);
                enemy.ReceiveDamage(Roller.rollXSidedDice(12, 5, 3) * 2);//30 - 72 hit points of damage dealt on Special Attack
                fighter.CharacterStats["Fury"] = 0;
                fighter.CharacterStats["Spirit"] = 0;
                if (enemy.CharacterStats["CurrentHitPoints"] <= 0)
                {
                    //ends fight when enemy dies from special attack
                    fighter.NPCDie(fighter, enemy, enemyPick, ref roomCoordinates);
                }
                turn++;
            }
            else
            {
                Console.Write("That isn't a valid selection.  Press any key to try again.");
                var errorKeystroke = Console.ReadKey().Key;
            }
        }

        public static void CombatEnemyTurn(ref GameCharacter fighter, ref GameCharacter enemy, ref int range, ref int eSalve, 
            ref int eArrows, ref int[,] roomCoordinates)
        {
            int xCoord = 1, yCoord = 14, originalYCoord = yCoord, infoBlockDepth = 3;
            bool isPlayer;

            CharacterInfoBlock.ClearInfoBlock(yCoord, infoBlockDepth);
            Console.SetCursorPosition(xCoord, yCoord);
            //enemyTurn conditionals - logic that governs enemy behavior in combat
            if (range > 1 && range < 8 && eArrows > 0)
            {
                Console.Write("{0} looses an arrow in your general direction...", enemy.CharacterInfo["Name"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                if (enemy.RangedAttack(range) > range)
                {
                    Console.Write("Bullseye! You grunt, pissed off, and sprint at the enemy angrily", enemy.CharacterInfo["Name"]);
                    isPlayer = true;
                    CharacterRoom.MoveCharacter(isPlayer, ref roomCoordinates, range);
                    range--;
                    fighter.CharacterStats["CurrentHitPoints"] -= enemy.CalculateRanged();
                    eArrows--;
                    if (fighter.CharacterStats["CurrentHitPoints"] <= 0)
                    {
                        //ends combat when you die from ranged attack
                        fighter.PlayerCharacterDie(fighter, ref roomCoordinates);
                    }
                }
                else
                {
                    Console.Write("He misses you.");
                    eArrows--;
                }
            }
            //if he is furious or uber-motivated, WATCH OUT!
            else if (range == 1 && enemy.CharacterStats["Fury"] >= 5 || enemy.CharacterStats["Spirit"] >= 5)
            {
                Console.Write(enemy.CharacterInfo["SpecialMove"]);
                enemy.CharacterStats["Fury"] = 0;
                enemy.CharacterStats["Spirit"] = 0;
                fighter.ReceiveDamage(Roller.rollXSidedDice(12, 5, 3) * 2);//30 - 72 hit points of damage dealt on Special Attack;
                                                                           //conditional that checks if you have been killed by this special attack
                if (fighter.CharacterStats["CurrentHitPoints"] <= 0)
                {
                    fighter.PlayerCharacterDie(fighter, ref roomCoordinates);
                }
            }//end special attack if
            else if (range > 1 && enemy.CharacterStats["CurrentHitPoints"] > 15)
            {//moves to opponent to attempt an attack, if healthy.  THIS LOGIC WILL CHANGE WITH IMPLEMENTATION OF RANGED WEAPONS
                Console.Write("{0} moves closer to you.", enemy.CharacterInfo["Name"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("{0}", enemy.CharacterInfo["TagLineTough"]);
                isPlayer = false;
                CharacterRoom.MoveCharacter(isPlayer, ref roomCoordinates, range);
                range--;
            }
            //if enemy is hurt, he will use his lone magic salve to heal up
            else if (enemy.CharacterStats["CurrentHitPoints"] <= 15 && eSalve > 0)
            {
                Console.Write("{0}", enemy.CharacterInfo["TagLineSoft"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("{0}, injured and wobbly, applies the magic salve", enemy.CharacterInfo["Name"]);
                eSalve--;
                //this magic salve works great! but it will only give you your maximum HP and no more
                enemy.CharacterStats["CurrentHitPoints"] += (enemy.CharacterStats["MaxHitPoints"] - enemy.CharacterStats["CurrentHitPoints"]);
            }
            //if he's close and has no salve left, he will attempt to hack you into little pieces
            else if (enemy.CharacterStats["CurrentHitPoints"] <= 15 && eSalve == 0)
            {
                Console.Write("{0} winds up and swings his sword with all of his remaining strength.", enemy.CharacterInfo["Name"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("{0}", enemy.CharacterInfo["TagLineSoft"]);
                //checks enemy attack roll vs. fighters avoid roll and determines a miss or hit according to formulas in Fighter class
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                if (enemy.AttackEnemy() > fighter.Avoid())
                {
                    int damage2 = enemy.CalculateDamage();
                    fighter.ReceiveDamage(damage2);
                    Console.Write("he hit you for {0} damage", damage2);
                    //if enemy hits successfully, fighter gets angry, enemy gets motivated
                    fighter.CharacterStats["Fury"]++;
                    enemy.CharacterStats["Spirit"]++;
                    //if fighter's hp goes below zero, it's Valhalla-time!
                    if (fighter.CharacterStats["CurrentHitPoints"] <= 0)
                    {
                        fighter.PlayerCharacterDie(fighter, ref roomCoordinates);
                    }
                }
                else
                {
                    Console.Write("The enemy misses");
                    //when the enemy whiffs, his motivation suffers and the fighter's motivation increases
                    enemy.CharacterStats["Spirit"]--;
                    fighter.CharacterStats["Spirit"]++;
                }
            }
            else
            {//this code will run if the range is 1 and the enemy is healthy; just basic melee attack
                Console.Write("{0} winds up and swings his sword with all of his might!", enemy.CharacterInfo["Name"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("{0}", enemy.CharacterInfo["TagLineTough"]);
                yCoord++;
                Console.SetCursorPosition(xCoord, yCoord);
                if (enemy.AttackEnemy() > fighter.Avoid())
                {
                    int damage2 = enemy.CalculateDamage();
                    fighter.ReceiveDamage(damage2);
                    Console.Write("he hit you for {0} damage", damage2);
                    fighter.CharacterStats["Fury"]++;
                    enemy.CharacterStats["Spirit"]++;
                    if (fighter.CharacterStats["CurrentHitPoints"] <= 0)
                    {
                        fighter.PlayerCharacterDie(fighter, ref roomCoordinates);
                    }
                }
                else
                {
                    Console.Write("The enemy misses");
                    enemy.CharacterStats["Spirit"]--;
                    fighter.CharacterStats["Spirit"]++;
                }
            }//end enemyTurn
        }

    }
}
