using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    class CharacterInfoBlock
    {
        public static void StatMenuBlockDisplay(int xCoord, GameCharacter character)
        {
            int count = 1, yCoord = 18;

            Console.SetCursorPosition(xCoord, yCoord);
            Console.Write("Name:  {0}", character.CharacterInfo["Name"]);
            foreach (KeyValuePair<string, int> element in character.CharacterStats)
            {
                Console.SetCursorPosition(xCoord, yCoord + count);
                Console.Write("{0}:  {1}", element.Key, element.Value);
                count++;
            }


        }

        public static void ClearInfoBlock()
        {
            int infoBlockLength = 158, infoBlockDepth = 10, xCoord = 1, yCoord = 7;

            ClearBlock(xCoord, yCoord, infoBlockLength, infoBlockDepth);
        }

        public static void ClearStatMenuBlock(int xCoord)
        {
            int statBlockLength = 52, statBlockDepth = 23, yCoord = 18;

            ClearBlock(xCoord, yCoord, statBlockLength, statBlockDepth);
        }

        public static void ClearBlock(int xCoord, int yCoord, int blockLength, int blockDepth)
        {
            string eraseString = "";

            for (int i = 0; i <= blockLength; i++)
                eraseString += " ";

            for (int i = 0; i <= blockDepth; i++)
            {
                Console.SetCursorPosition(xCoord, yCoord + i);
                Console.Write(eraseString);
            }
        }
    }
}
