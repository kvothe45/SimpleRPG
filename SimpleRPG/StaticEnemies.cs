using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    class StaticEnemies
    {

        public static GameCharacter PreMadeEnemies(GameCharacter enemy, GameCharacter fighter, int enemySelect)
        {

            switch (enemySelect)
            {
                case 1:
                    enemy.CharacterInfo["Name"] = "Glass Jody";
                    enemy.CharacterStats["Strength"] = 12;
                    enemy.CharacterStats["Agility"] = 12;
                    enemy.CharacterStats["Intelligence"] = 12;
                    enemy.CharacterStats["Luck"] = 12;
                    enemy.CharacterStats["Constitution"] = 12;
                    enemy.CharacterStats["MaxHitPoints"] = 35;
                    enemy.CharacterStats["CurrentHitPoints"] = 35;
                    enemy.CharacterStats["Notoriety"] = 1;
                    enemy.CharacterInfo["TagLineSoft"] = "Please don't hurt me, sir.";
                    enemy.CharacterInfo["TagLineTough"] = "Put em up, Put em up!";
                    enemy.CharacterInfo["Description"] = "Cousin of boxer \"Glass\" Joe, Jody fights similarly.  Horribly bad.";
                    enemy.CharacterInfo["SpecialMove"] = "Jody throws a tantrum and slaps you with all of his might.  Yes, this IS Jody's 'special' attack!";
                    break;
                case 2:
                    enemy.CharacterInfo["Name"] = "Macho Dan";
                    enemy.CharacterStats["Strength"] = 15;
                    enemy.CharacterStats["Agility"] = 15;
                    enemy.CharacterStats["Intelligence"] = 6;
                    enemy.CharacterStats["Luck"] = 10;
                    enemy.CharacterStats["Constitution"] = 14;
                    enemy.CharacterStats["MaxHitPoints"] = 75;
                    enemy.CharacterStats["CurrentHitPoints"] = 75;
                    enemy.CharacterStats["Notoriety"] = 2;
                    enemy.CharacterInfo["TagLineSoft"] = "Snap into it?";
                    enemy.CharacterInfo["TagLineTough"] = "Ooooh Yeeeah!";
                    enemy.CharacterInfo["Description"] = "Macho Dan watched a lot of wrestling in the 80's apparantly.  He wears a bandana and shades with his cuirass.";
                    enemy.CharacterInfo["SpecialMove"] = "Macho Dan finds a turnbuckle in the arena and jumps off of it, performing a crushing elbow drop that would have made Randy Savage proud.";
                    break;
                case 3:
                    enemy.CharacterInfo["Name"] = "Rafaela Fuego";
                    enemy.CharacterStats["Strength"] = 6;
                    enemy.CharacterStats["Agility"] = 20;
                    enemy.CharacterStats["Intelligence"] = 20;
                    enemy.CharacterStats["Luck"] = 20;
                    enemy.CharacterStats["Constitution"] = 12;
                    enemy.CharacterStats["MaxHitPoints"] = 48;
                    enemy.CharacterStats["CurrentHitPoints"] = 48;
                    enemy.CharacterStats["Notoriety"] = 3;
                    enemy.CharacterInfo["TagLineTough"] = "Que te rompo!  subtitle: I must break you!";
                    enemy.CharacterInfo["TagLineSoft"] = "Se me rompe.  subtitle: You must break me";
                    enemy.CharacterInfo["Description"] = "Andrés no se siente bien. Estuvo en una fiesta anoche y llegó a casa a las 3 am.  Tiene dolor de cabeza y siente náusea. Bebió mucho y comió demasiados camarones. ";
                    enemy.CharacterInfo["SpecialMove"] = "Fuego unleashes a blindingly fast flurry of stabs and jabs, that turns your torso into swiss cheese";
                    break;
                case 4:
                    enemy.CharacterInfo["Name"] = "Mr. Biscuits";
                    enemy.CharacterStats["Strength"] = 20;
                    enemy.CharacterStats["Agility"] = 2;
                    enemy.CharacterStats["Intelligence"] = 8;
                    enemy.CharacterStats["Luck"] = 8;
                    enemy.CharacterStats["Constitution"] = 24;
                    enemy.CharacterStats["MaxHitPoints"] = 150;
                    enemy.CharacterStats["CurrentHitPoints"] = 150;
                    enemy.CharacterStats["Notoriety"] = 4;
                    enemy.CharacterInfo["TagLineTough"] = "Get in mah belly!";
                    enemy.CharacterInfo["TagLineSoft"] = "Get in mah belly ? ";
                    enemy.CharacterInfo["Description"] = "Fat and Happy, Mr. Biscuits eats EVERYTHING he can get his stubby fingers on.  He stands 6'8\" and weighs 650 lbs. He wears a striped tent as a tunic in the arena for his matches.";
                    enemy.CharacterInfo["SpecialMove"] = "Mr.Biscuits throws you down and sits on you, crushing the life out of you slowly, but surely.  The faint smell of twinkie, bacon and ass permeate your senses as you start to fade away.";
                    break;
                case 5:
                    enemy.CharacterInfo["Name"] = "Rich Ro$$";
                    enemy.CharacterStats["Strength"] = 18;
                    enemy.CharacterStats["Agility"] = 13;
                    enemy.CharacterStats["Intelligence"] = 12;
                    enemy.CharacterStats["Luck"] = 12;
                    enemy.CharacterStats["Constitution"] = 18;
                    enemy.CharacterStats["MaxHitPoints"] = 100;
                    enemy.CharacterStats["CurrentHitPoints"] = 100;
                    enemy.CharacterStats["Notoriety"] = 5;
                    enemy.CharacterInfo["TagLineTough"] = "Everyday I'm hustlin'";
                    enemy.CharacterInfo["TagLineSoft"] = "Push it to the limit.";
                    enemy.CharacterInfo["Description"] = "Put molly all in her champagne, She ain't even know it, I took her home and I enjoyed that, She ain't even know it.";
                    enemy.CharacterInfo["SpecialMove"] = "Rich Ro$$ pulls out a Glock 9mm and pops a cap in your ass.  You wonder how the hell he got that thing in a freaking time period before Jesus was born.";
                    break;
                case 6:
                    enemy.CharacterInfo["Name"] = "Caesar the Conqueror";
                    enemy.CharacterStats["Strength"] = 24;
                    enemy.CharacterStats["Agility"] = 18;
                    enemy.CharacterStats["Intelligence"] = 18;
                    enemy.CharacterStats["Luck"] = 18;
                    enemy.CharacterStats["Constitution"] = 18;
                    enemy.CharacterStats["MaxHitPoints"] = 120;
                    enemy.CharacterStats["CurrentHitPoints"] = 120;
                    enemy.CharacterStats["Notoriety"] = 10;
                    enemy.CharacterInfo["TagLineTough"] = "I will crush you, you...you swine";
                    enemy.CharacterInfo["TagLineSoft"] = "Guards!!!Seize him!Guards ??? ";
                    enemy.CharacterInfo["Description"] = "He's the boss.  Think Commodus in 'Gladiator', not that this game parallels that movie (at all).";
                    enemy.CharacterInfo["SpecialMove"] = "Caesar swings for your neck like he wants to put it on a pike for the entire month of Augustus.You feel honored.";
                    break;

                default:
                    Menu.WinGame();
                    break;
            }//end switch

            return enemy;
        }


    }
}
