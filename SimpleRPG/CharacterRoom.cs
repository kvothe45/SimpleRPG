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

            drawWall(ref roomCoordinates);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Write(character); // Write the character on the default location (1,1).

            while (true)
            {
                int originalX = x;
                int originalY = y;

                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            if (y >= roomCoordinates[0, 1] + 1 && y <= roomCoordinates[1, 1] - 2)
                            {
                                y++;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (y >= roomCoordinates[0, 1] + 2 && y <= roomCoordinates[1, 1] - 1)
                            {
                                y--;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (x >= roomCoordinates[0, 0] + 3 && x <= roomCoordinates[1, 0] - 1)
                            {
                                x -= 2;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (x >= roomCoordinates[0, 0] + 1 && x <= roomCoordinates[1, 0] - 3)
                            {
                                x += 2;
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
                        Write(character, x, y);

                        //erase where the character was
                        Console.ResetColor();
                        Write(' ', originalX, originalY);
                    }
                    drawWall(ref roomCoordinates);
                    //there is a random blue block that appears at coordinates (3,2).  this just 
                    //ensures i can get rid of it until i figure out the root cause
                    Console.ResetColor();
                    Write(' ', 3, 2);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        //since the x and y have initial values in the declaration here, you can call this method
        //by just passing toWrite and wall
        public static void Write(char toWrite, int x = 2, int y = 2)
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



        public static void drawWall(ref int[,] roomCoordinates)
        {
            int x, y = roomCoordinates[0, 1];
            int shiftY = roomCoordinates[1, 1] - roomCoordinates[0, 1];
            int shiftX = roomCoordinates[1, 0] - roomCoordinates[0, 0];
            char wall = '#'; //Character used to draw the wall of the dungeon room


            for (x = roomCoordinates[0, 0]; x <= roomCoordinates[1, 0]; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(wall);
                Console.SetCursorPosition(x, y + shiftY);
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

        }

        public static void createRoom(ref int[,] roomCoordinates)
        {
            Random rnd = new Random();

            roomCoordinates[0, 0] = 1;
            roomCoordinates[0, 1] = 1;
            roomCoordinates[1, 0] = 32;
            roomCoordinates[1, 1] = 5;
            //roomCoordinates[1, 0] = rnd.Next(20, 41);
            //if (roomCoordinates[1, 0] % 2 == 0)
            //    roomCoordinates[1, 0] += 1;
            //roomCoordinates[1, 1] = rnd.Next(10, 21);

        }
    }
}
