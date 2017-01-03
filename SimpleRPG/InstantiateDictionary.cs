using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    class InstantiateDictionary
    {
        public static void instatiateDictionary(ref Dictionary<string, string> fighterStats)
        {
            fighterStats.Add("Name", "Barry");
            fighterStats.Add("HPCurrent", "20");
            fighterStats.Add("HPMax", "100");
            fighterStats.Add("XPCurrent", "10");
            fighterStats.Add("XPMax", "100");
            fighterStats.Add("Level", "1");
            fighterStats.Add("Strength", "18");
            fighterStats.Add("Agility", "18");
            fighterStats.Add("Intelligence", "18");
            fighterStats.Add("Luck", "18");
            fighterStats.Add("Charisma", "18");
            fighterStats.Add("Constitution", "18");
            fighterStats.Add("Spirit", "18");
            fighterStats.Add("Fury", "18");
            fighterStats.Add("Noteriety", "18");
            fighterStats.Add("Fame", "18");
            fighterStats.Add("Money", "100");
        }

        public static void instantiateCoordinates(ref Dictionary<string, CoordPoint> roomCoordinates)
        {
            CoordPoint upperLeftCoord = new CoordPoint();
            upperLeftCoord.X = 1;
            upperLeftCoord.Y = 1;

            roomCoordinates.Add("upperLeft", upperLeftCoord);

            Console.WriteLine(roomCoordinates["upperLeft"].X);
        }
    }
}
