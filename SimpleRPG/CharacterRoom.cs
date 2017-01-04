using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleRPG
{
    class CharacterRoom
    {

        public static void characterMovement(ref int[,] roomCoordinates)
        {
            const char character = '*'; // Character to write on-screen.
            //defining the start coordinate for the character
            roomCoordinates[2, 0] = 2;
            roomCoordinates[2, 1] = 2;
            int x = roomCoordinates[2, 0], y = roomCoordinates[2, 1]; // Contains current cursor position.

            Console.CursorVisible = false;

            DrawRoom(ref roomCoordinates);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            DrawCharacter(character); // Write the character on the default location (1,1).

            while (true)
            {
                int originalX = x;
                int originalY = y;

                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;

                    switch (command)
                    {
                        case ConsoleKey.LeftArrow:
                            if (x >= roomCoordinates[0, 0] + 13 && x <= roomCoordinates[1, 0] - 12)
                            {
                                x -= 12;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (x >= roomCoordinates[0, 0] + 1 && x <= roomCoordinates[1, 0] - 24)
                            {
                                x += 12;
                            }
                            break;
                    }


                    if (originalX != x || originalY != y)
                    {
                        //set the passable coordinates to the current movement for outside use
                        roomCoordinates[2, 0] = x;
                        roomCoordinates[2, 1] = y;
                        //move the character
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        DrawCharacter(character, x);

                        //erase where the character was
                        Console.ResetColor();
                        DrawCharacter(' ', originalX);
                    }
                    DrawRoom(ref roomCoordinates);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }


        public static void MoveCharacter(bool isPlayer, ref int[,] roomCoordinates, int range)
        {
            char toWrite = ' ';

            Console.ResetColor();
            if (range > 1 && isPlayer)
            {
                DrawCharacter(toWrite, roomCoordinates[2, 0]);
                roomCoordinates[2, 0] += 12;
                toWrite = '*';
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Blue;
                DrawCharacter(toWrite, roomCoordinates[2, 0]);
            }
            else if (range > 1 && !isPlayer)
            {
                DrawCharacter(toWrite, roomCoordinates[3, 0]);
                roomCoordinates[3, 0] -= 12;
                toWrite = '*';
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Red;
                DrawCharacter(toWrite, roomCoordinates[3, 0]);
            }
            Console.ResetColor();
        }

        public static void SetCharacters(int[,] roomCoordinates)
        {
            char toWrite = '*';
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            DrawCharacter(toWrite, roomCoordinates[2, 0]);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            DrawCharacter(toWrite, roomCoordinates[3, 0]);
            Console.ResetColor();

        }

        public static void WriteSingleChar(char toWrite, int x, int y)
        {
            try
            {
                if (x >= 2 && y >= 2) // start position
                {

                    Console.SetCursorPosition(x, y);
                    Console.Write(toWrite);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void DrawCharacter(char toWrite, int x = 2)
        {
            int y;

            for (int i = 0; i < 4; i++)
            {
                y = 2;
                WriteSingleChar(toWrite, x + i, y);
                WriteSingleChar(toWrite, x + i + 8, y);
                y = 3;
                WriteSingleChar(toWrite, x + i + 4, y);
                y = 4;
                WriteSingleChar(toWrite, x + i, y);
                WriteSingleChar(toWrite, x + i + 8, y);
            }

        }



        public static void DrawRoom(ref int[,] roomCoordinates)
        {
            int x, y = roomCoordinates[0, 1];
            int shiftY = roomCoordinates[1, 1] - roomCoordinates[0, 1];
            int shiftX = roomCoordinates[1, 0] - roomCoordinates[0, 0];
            char wall = '#'; //Character used to draw the wall of the dungeon room
            char floor = '%';


            for (x = roomCoordinates[0, 0]; x <= roomCoordinates[1, 0]; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(wall);
            }
            x--;

            for (y = roomCoordinates[0, 1]; y <= roomCoordinates[1, 1]; y++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(wall);
                Console.SetCursorPosition(x - shiftX, y);
                Console.Write(wall);
            }

            y = roomCoordinates[0, 1];
            for (x = roomCoordinates[0, 0]; x <= roomCoordinates[1, 0]; x++)
            {
                Console.SetCursorPosition(x, y + shiftY);
                Console.Write(floor);
            }

        }

        public static void EraseAndResetRoom(ref int[,] roomCoordinates)
        {

            string eraseString = "";

            for (int i = 0; i < roomCoordinates[1, 0]; i++)
                eraseString += " ";

            for (int i = 0; i < roomCoordinates[1,1]; i++)
            {
                Console.SetCursorPosition(roomCoordinates[0,0], i + 1);
                Console.Write(eraseString);
            }

            CreateRoom(ref roomCoordinates);
        }

        public static void CreateRoom(ref int[,] roomCoordinates)
        {
            // set room coordinates
            roomCoordinates[0, 0] = 1;
            roomCoordinates[0, 1] = 1;
            roomCoordinates[1, 0] = 122;
            roomCoordinates[1, 1] = 5;

            // set initial character coordinates
            roomCoordinates[2, 0] = 2;
            roomCoordinates[2, 1] = 2;

            // set initial enemy coordinates
            roomCoordinates[3, 0] = 110;
            roomCoordinates[3, 1] = 2;
        }
    }
}
