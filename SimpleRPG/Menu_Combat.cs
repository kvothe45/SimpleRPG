using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    partial class Menu
    {
        public static void CombatMenu(GameCharacter fighter, GameCharacter enemy, int enemyPick)
        {
            bool CombatActive = true;
            int range = 8;
            int salve = 0;
            int eSalve = 1;
            int turn = 0;
            int arrows = 4;
            int eArrows = 4;

            //Boolean check in while loop keeps character in combat when actively fighting 
            while (CombatActive)
            {

                int f20Roll = Roller.rollXSidedDice(20, 1, 1);
                int e20Roll = Roller.rollXSidedDice(20, 1, 1);
                //conditional that prevents getting a new magic salve every round
                if (salve == 0 && turn == 0)
                {//get magic salve for healing during combat
                    Console.WriteLine("As you walk through the narrow pathway to the arena,\n" +
                        "a fair maiden hands you a satchel.  She says, \"Good luck, warrior. Take this\n" +
                        "magic salve to heal your wounds during your fight.\"\n");
                    //adds a little bit of flavor, humor, and character development
                    Console.WriteLine("Your coach, Leonardo Turtle, tells you a little something about your opponent that you may not have known: ");
                    //TO-DO: add randomizer for different "fun facts" with the description 
                    Console.WriteLine("{0}\n", enemy.CharacterInfo["Description"]);

                    salve += 1;
                }
                else
                {//displays character status during combat

                    Console.WriteLine("{0} is {1} passus away ('passus' is Roman for paces)", enemy.CharacterInfo["Name"], range);
                    Console.WriteLine("You have {0} arrows left", arrows);
                    if (salve == 1)
                        Console.WriteLine("You have a salve handy");
                    else
                        Console.WriteLine("You are out of salve");
                    Console.WriteLine("The enemy has {0} hit points left", enemy.CharacterStats["CurrentHitPoints"]);
                    Console.WriteLine("You have {0} hit points left", fighter.CharacterStats["CurrentHitPoints"]);
                    Console.WriteLine("You have fought {0} round(s)", turn - 1);
                    Console.WriteLine();

                    //Display Menu - perform menu actions
                    Console.WriteLine("1) Melee Attack");
                    if (arrows > 0)
                    { Console.WriteLine("2) Ranged Attack"); }
                    Console.WriteLine("3) Close with Enemy");
                    Console.WriteLine("4) Use salve");
                    Console.WriteLine("5) Yield");

                    //conduct special attack if fighter's Fury or Spirit level is at 5 or greater
                    if (fighter.CharacterStats["Fury"] > 4 || fighter.CharacterStats["Spirit"] > 4)
                    { Console.WriteLine("6) Special Attack"); }
                    Console.WriteLine();

                    //alerts user as to why the special attack is available.
                    if (fighter.CharacterStats["Fury"] > 4)
                        Console.WriteLine("Your fury is past the boiling point and {0} cringes from the look on your face", enemy.CharacterInfo["Name"]);
                    else if (fighter.CharacterStats["Spirit"] > 4)
                        Console.WriteLine("You're in the zone, gladiator. The crowd marvels at your majestic skill.");

                    //takes menu input
                    int yourMove = Convert.ToInt32(Console.ReadLine());

                    //start switch statement that corresponds to menu items
                    switch (yourMove)
                    {
                        //attempt to attack enemy if close enough
                        case 1:
                            if (range < 2)
                            {

                                Console.WriteLine("You swing your sword at the enemy, thoroughly expecting to lop his ugly head off.");
                                Console.WriteLine();
                                Console.WriteLine("\nYou catch him on his heels and swing for the fences.", fighter.CharacterInfo["Name"]);
                                if (fighter.AttackEnemy() > enemy.Avoid())
                                {
                                    int damage1 = fighter.CalculateDamage();
                                    enemy.ReceiveDamage(damage1);
                                    Console.WriteLine("\nyou hit {0} for {1} damage", enemy.CharacterInfo["Name"], damage1);
                                    fighter.CharacterStats["Spirit"]++;
                                    enemy.CharacterStats["Fury"]++;

                                    if (enemy.CharacterStats["CurrentHitPoints"] <= 0)
                                    {
                                        //ends combat when enemy dies from regular attack
                                        CombatActive = false;
                                        fighter.NPCDie(fighter, enemy, enemyPick);
                                        continue;
                                    }

                                }
                                else
                                {

                                    Console.WriteLine("\nYou miss");
                                    fighter.CharacterStats["Spirit"]--;
                                }

                                #region Obsolete counter-attack code
                                /*{
                                    Console.WriteLine("\n Your attack whiffs, {0} attacks you, instead!", enemy.CharacterInfo["Name"]);
                                    if (enemy.AttackEnemy() > fighter.Avoid())
                                    {
                                        int damage2 = enemy.CalculateDamage();
                                        fighter.ReceiveDamage(damage2);
                                        Console.WriteLine("he hit you for {0} damage", damage2);
                                        fighter.CharacterStats["Fury"]++;
                                        enemy.CharacterStats["Spirit"]++;

                                        if (fighter.CharacterStats["CurrentHitPoints"] <= 0)
                                        {
                                            CombatActive = false;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("The enemy misses");
                                        enemy.CharacterStats["Spirit"]--;

                                    }



                                }//end if*/
                                #endregion

                            }//end range if 
                            else
                            {

                                Console.WriteLine("You're not close enough to perform that action.");
                            }
                            break;

                        //ranged attack if range > 1

                        case 2:
                            //if range > 1 and selected the fighter shoots an arrow at the enemy
                            if (range > 1)
                            {
                                Console.WriteLine("You loose one of your {0} arrows towards the enemy", arrows);
                                //if the fighter has an arrow, rolls and calculations are made to see if you hit 
                                //it takes a perfect roll of 20 to hit at default range unless super skilled(1 in 20 shot)

                                if (arrows > 0)
                                {
                                    if (fighter.RangedAttack(range) > range)
                                    {
                                        Console.WriteLine("Bullseye! {0} grunts, clearly pissed off, and sprints at you angrily", enemy.CharacterInfo["Name"]);
                                        range--;
                                        enemy.CharacterStats["CurrentHitPoints"] -= fighter.CalculateRanged();
                                        arrows--;
                                        if (enemy.CharacterStats["CurrentHitPoints"] <= 0)
                                        {
                                            //ends combat when enemy dies from ranged attack
                                            CombatActive = false;
                                            fighter.NPCDie(fighter, enemy, enemyPick);
                                            continue;
                                        }


                                    }
                                    else
                                    {
                                        Console.WriteLine("You miss the enemy.");
                                        arrows--;
                                    }
                                }
                                else
                                    Console.WriteLine("You have no arrows");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You are too close to hit with your bow. Duh.");
                                arrows--;
                                break;
                            }

                        //close range to enemy
                        case 3:
                            if (range > 1)
                            {

                                Console.WriteLine("You sprint towards the enemy and make the craziest, most bloodthirsty face you can muster\n");
                                range--;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You ram into the enemy by running full speed into him, say, \"mi Scusi\", and... ");
                                break;
                            }

                        //apply salve to heal
                        case 4:
                            if (salve > 0)
                            {
                                Console.WriteLine("\nYou use the magic salve on your wounds, and feel better immediately");
                                fighter.CharacterStats["CurrentHitPoints"] += (fighter.CharacterStats["MaxHitPoints"] - fighter.CharacterStats["CurrentHitPoints"]);
                                salve--;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nYou don't have any magic salve left.");
                                break;
                            }

                        //case 5: yield (exit combat without dying; will have penalties)


                        //special attack; resets Fury and Spirit levels to zero
                        case 6:
                            Console.WriteLine("You focus all of your energy into a mighty finishing blow that staggers the enemy.");
                            enemy.ReceiveDamage(Roller.rollXSidedDice(12, 5, 3) * 2);//30 - 72 hit points of damage dealt on Special Attack
                            //
                            fighter.CharacterStats["Fury"] = 0;
                            fighter.CharacterStats["Spirit"] = 0;

                            if (enemy.CharacterStats["CurrentHitPoints"] <= 0)
                            {
                                //ends fight when enemy dies from special attack
                                CombatActive = false;
                                fighter.NPCDie(fighter, enemy, enemyPick);
                                continue;
                            }
                            break;


                    }//end switch

                    //enemyTurn conditionals - logic that governs enemy behavior in combat

                    if (range > 1 && range < 8 && eArrows > 0)
                    {
                        Console.WriteLine("{0} looses an arrow in your general direction...", enemy.CharacterInfo["Name"]);
                        if (enemy.RangedAttack(range) > range)
                        {
                            Console.WriteLine("Bullseye! You grunt, pissed off, and sprint at the enemy angrily", enemy.CharacterInfo["Name"]);
                            range--;
                            fighter.CharacterStats["CurrentHitPoints"] -= enemy.CalculateRanged();
                            eArrows--;
                            if (fighter.CharacterStats["CurrentHitPoints"] <= 0)
                            {
                                //ends combat when you die from ranged attack
                                CombatActive = false;
                                fighter.PlayerCharacterDie(fighter);
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("He misses you.");
                            eArrows--;
                        }
                    }


                    //if he is furious or uber-motivated, WATCH OUT!
                    else if (range == 1 && enemy.CharacterStats["Fury"] >= 5 || enemy.CharacterStats["Spirit"] >= 5)
                    {
                        Console.WriteLine(enemy.CharacterInfo["SpecialMove"]);
                        enemy.CharacterStats["Fury"] = 0;
                        enemy.CharacterStats["Spirit"] = 0;
                        fighter.ReceiveDamage(Roller.rollXSidedDice(12, 5, 3) * 2);//30 - 72 hit points of damage dealt on Special Attack;

                        //conditional that checks if you have been killed by this special attack
                        if (fighter.CharacterStats["CurrentHitPoints"] <= 0)
                        {
                            fighter.PlayerCharacterDie(fighter);
                            CombatActive = false;
                            break;
                        }
                    }//end special attack if

                    else if (range > 1 && enemy.CharacterStats["CurrentHitPoints"] > 15)
                    {//moves to opponent to attempt an attack, if healthy.  THIS LOGIC WILL CHANGE WITH IMPLEMENTATION OF RANGED WEAPONS

                        Console.WriteLine("\n{0} moves closer to you.", enemy.CharacterInfo["Name"]);
                        Console.WriteLine("{0}", enemy.CharacterInfo["TagLineTough"]);
                        range--;
                    }
                    //if enemy is hurt, he will use his lone magic salve to heal up
                    else if (enemy.CharacterStats["CurrentHitPoints"] <= 15 && eSalve > 0)
                    {
                        Console.WriteLine("{0}", enemy.CharacterInfo["TagLineSoft"]);
                        Console.WriteLine("\n{0}, injured and wobbly, applies the magic salve", enemy.CharacterInfo["Name"]);
                        eSalve--;
                        //this magic salve works great! but it will only give you your maximum HP and no more
                        enemy.CharacterStats["CurrentHitPoints"] += (enemy.CharacterStats["MaxHitPoints"] - enemy.CharacterStats["CurrentHitPoints"]);
                    }
                    //if he's close and has no salve left, he will attempt to hack you into little pieces
                    else if (enemy.CharacterStats["CurrentHitPoints"] <= 15 && eSalve == 0)
                    {
                        Console.WriteLine("\n{0} winds up and swings his sword with all of his remaining strength.", enemy.CharacterInfo["Name"]);
                        Console.WriteLine("{0}", enemy.CharacterInfo["TagLineSoft"]);
                        //checks enemy attack roll vs. fighters avoid roll and determines a miss or hit according to formulas in Fighter class
                        if (enemy.AttackEnemy() > fighter.Avoid())
                        {
                            int damage2 = enemy.CalculateDamage();
                            fighter.ReceiveDamage(damage2);
                            Console.WriteLine("he hit you for {0} damage\n", damage2);
                            //if enemy hits successfully, fighter gets angry, enemy gets motivated
                            fighter.CharacterStats["Fury"]++;
                            enemy.CharacterStats["Spirit"]++;

                            //if fighter's hp goes below zero, it's Valhalla-time!
                            if (fighter.CharacterStats["CurrentHitPoints"] <= 0)
                            {
                                fighter.PlayerCharacterDie(fighter);
                                CombatActive = false;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThe enemy misses");
                            //when the enemy whiffs, his motivation suffers and the fighter's motivation increases
                            enemy.CharacterStats["Spirit"]--;
                            fighter.CharacterStats["Spirit"]++;
                        }
                    }
                    else
                    {//this code will run if the range is 1 and the enemy is healthy; just basic melee attack

                        Console.WriteLine("\n{0} winds up and swings his sword with all of his might!", enemy.CharacterInfo["Name"]);
                        Console.WriteLine("{0}", enemy.CharacterInfo["TagLineTough"]);
                        if (enemy.AttackEnemy() > fighter.Avoid())
                        {
                            int damage2 = enemy.CalculateDamage();
                            fighter.ReceiveDamage(damage2);
                            Console.WriteLine("he hit you for {0} damage\n", damage2);
                            fighter.CharacterStats["Fury"]++;
                            enemy.CharacterStats["Spirit"]++;

                            if (fighter.CharacterStats["CurrentHitPoints"] <= 0)
                            {
                                fighter.PlayerCharacterDie(fighter);
                                CombatActive = false;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThe enemy misses");
                            enemy.CharacterStats["Spirit"]--;
                            fighter.CharacterStats["Spirit"]++;
                        }
                    }//end enemyTurn                    

                }//end if

                //increments turn counter
                turn++;

            }//end while                           

        }//end method       
    }
}
