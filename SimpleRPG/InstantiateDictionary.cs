using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    class InstantiateDictionary
    {
        public static void instatiateDictionary(ref Dictionary<string, int> fighterStats, ref Dictionary<string, string> fighterInfo)
        {
            fighterStats["Strength"] = 18;
            fighterStats["Agility"] = 18;
            fighterStats["Intelligence"] = 18;
            fighterStats["Luck"] = 18;
            fighterStats["Charisma"] = 18;
            fighterStats["Constitution"] = 18;
            fighterStats["HPCurrent"] = 20;
            fighterStats["HPMax"] = 100;
            fighterStats["XPCurrent"] = 10;
            fighterStats["XPMax"] = 100;
            fighterStats["Level"] = 1;
            fighterStats["Spirit"] = 0;
            fighterStats["Fury"] = 0;
            fighterStats["Noteriety"] = 0;
            fighterStats["Fame"] = 0;
            fighterStats["Money"] = 100;
            fighterStats["Kills"] = 0;

            fighterInfo["Name"] = "Barry";
            fighterInfo["Weapon"] = "fists";
            fighterInfo["Armor"] = "skin";
            fighterInfo["Description"] = "Big, ugly, and tough.  He eats rust and pisses nails";
            fighterInfo["TagLineTough"] = "Float like a butterfly, sting like a bee!  I am the Greatest!";
            fighterInfo["TagLineSoft"] = "Oooo, you're going to get it now!";
        }

        public static void instantiateCoordinates(ref Dictionary<string, CoordPoint> roomCoordinates)
        {
            CoordPoint upperLeftCoord = new CoordPoint();
            upperLeftCoord.X = 1;
            upperLeftCoord.Y = 1;

            roomCoordinates.Add("upperLeft", upperLeftCoord);

            //Console.WriteLine(roomCoordinates["upperLeft"].X);
        }
    }
}
