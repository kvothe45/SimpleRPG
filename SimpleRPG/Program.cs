using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    class Program
    {
        static void Main(string[] args)
        {

            int y = Console.LargestWindowHeight;
            int x = Console.LargestWindowWidth;
            int enemyPick = 1, xCoord, yCoord;
            //all the coordinates that pertain to the room
            //[0,0] upper left x coordinate for room [0,1] upper left y coordinate for room
            //[1,0] lower right x coordinate for room [1,1] lower right y coordinate for room
            //[2,0] player x coordinate [2,1] player y coordinate
            //[3,0] enemy x coordinate [3,1] enemy y coordinate
            //[4,0] treasure x coordinate [4,1] treasure y coordinate
            // menu X Coordinate Starts at 1,  player Stats X Coordinate Starts at 53, enemy Stat X Coordinate Starts at 105,
            int[,] roomCoordinates = new int[5, 2];
            GameCharacter fighter = new GameCharacter();

            bool Game_Over = false;

            Console.SetWindowSize(160, 43);
            do
            {
                // Draw GUI;
                // Draw Stats;
                GameScreen.drawScreen();
                CharacterRoom.CreateRoom(ref roomCoordinates); //randomly create the size of the room at least 10 x 10
                Menu.introDescription(out xCoord, out yCoord);
                Menu.MainMenu(GameCharacter.CharCreator(xCoord, yCoord, fighter), enemyPick, ref roomCoordinates);
                
                //CharacterRoom.characterMovement(ref roomCoordinates);
                

            } while (Game_Over == false);


            Console.ReadLine();
        }
    }
}
