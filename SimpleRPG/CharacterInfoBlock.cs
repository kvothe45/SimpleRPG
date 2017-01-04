using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    class CharacterInfoBlock
    {
        public static void InfoBlockDisplay(int startXCoord, int startYCoord, GameCharacter character)
        {
            int count = 1;

            Console.SetCursorPosition(startXCoord, startYCoord);
            Console.Write("Name:  {0}", character.CharacterInfo["Name"]);
            foreach (KeyValuePair<string, int> element in character.CharacterStats)
            {
                Console.SetCursorPosition(startXCoord, startYCoord + count);
                Console.Write("{0}:  {1}", element.Key, element.Value);
                count++;
            }


        }

        public static void ClearInfoBlock(int startXCoord, int startYCoord)
        {
            int infoBlockLength = 52, infoBlockDepth = 23;
            string infoBlockEraseString = "";

            for (int i = 0; i <= infoBlockLength; i++)
                infoBlockEraseString += " ";

            for (int i = 0; i <= infoBlockDepth; i++)
            {
                Console.SetCursorPosition(startXCoord, startYCoord + i);
                Console.Write(infoBlockEraseString);
            }
                           
        }
    }
}
