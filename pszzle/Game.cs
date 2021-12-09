using System;

namespace pszzle
{
    enum Dir
    {
        STOP,
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    class Game
    {
        static bool gameOver = false;

        static Field field = new Field();
        static Character character = new Character(0, 0);
        static Barrel barrel = new Barrel(0, 0);
        static Exit exit = new Exit(0, 0);

        static void Main()
        {
            field.lvlNum = 0;
            Console.CursorVisible = false;
            Init();

            while(!gameOver)
            {
                Input();
                Logic();
                DrawField();
                if(checkGameOver(barrel.X, barrel.Y))
                {
                    Init();
                    DrawGameOver();
                }    
            }
            Console.Clear();
            Console.WriteLine("Good game player :)");
            Console.ReadKey(true);
        }
        static void Init()
        {
            character = new Character(field);
            barrel = new Barrel(field);
            exit = new Exit(field);
        }
        static void DrawField()
        {
            Console.SetCursorPosition(0, 0);
            for(int x = 0; x < field.Width; x++)
            {
                Console.Write("#");
            }
            Console.Write("\n");

            for (int y = 1; y < field.Height - 1; y++)
            {
                Console.Write("#");
                for (int x = 1; x < field.Width - 1; x++)
                {
                    bool cellIsEmpty = true;
                    if (character.X == x && character.Y == y)
                    {
                        Console.Write("O");
                        continue;
                    }

                    if(barrel.X == x && barrel.Y == y)
                    {
                        Console.Write("B");
                        continue;
                    }

                    if (exit.X == x && exit.Y == y)
                    {
                        Console.Write("X");
                        continue;
                    }

                    int lvlNum = field.lvlNum;
                    for (int i = 0; i < field.WallsX[lvlNum].Length; i++)
                    {
                        if(x == field.WallsX[lvlNum][i] && y == field.WallsY[lvlNum][i])
                        {
                            cellIsEmpty = false;
                            Console.Write("#");
                            break;
                        }
                    }

                    if(cellIsEmpty)
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("#\n");
            }

            for (int x = 0; x < field.Width; x++)
            {
                Console.Write("#");
            }
            Console.Write("\n");
        }
        static void DrawGameOver()
        {
            Console.Clear();
            Console.Write("Try Again\nPress Any Key To Continue ...");
            Console.ReadKey(true);
        }
        static void Input()
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
                keyInfo = Console.ReadKey(true);
                switch(keyInfo.Key)
                {
                    case (ConsoleKey.W):
                        character.dir = Dir.UP;
                        break;
                    case (ConsoleKey.S):
                        character.dir = Dir.DOWN;
                        break;
                    case (ConsoleKey.A):
                        character.dir = Dir.LEFT;
                        break;
                    case (ConsoleKey.D):
                        character.dir = Dir.RIGHT;
                        break;
                    case (ConsoleKey.R):
                        Init();
                        break;
                }
            }
        }
        static void Logic()
        {
            if (barrel.X == exit.X && barrel.Y == exit.Y)
            {
                if(field.lvlNum != field.lvlParams.Count - 1)
                {
                    field.Nextlvl();
                    Init();
                }
                else
                {
                    gameOver = true;
                }
            }

            switch (character.dir)
            {
                case Dir.UP:
                    character.moveUp(field, barrel);
                    break;
                case Dir.DOWN:
                    character.moveDown(field, barrel);
                    break;
                case Dir.LEFT:
                    character.moveLeft(field, barrel);
                    break;
                case Dir.RIGHT:
                    character.moveRigth(field, barrel);
                    break;
            }
        }
        static bool checkGameOver(int x, int y)
        {
            if(x == 1 && y == 1 ||
                x == field.Width - 2 && y == 1 ||
                x == 1 && y == field.Height - 2 ||
                x == field.Width - 2 && y == field.Height - 2)
            {
                return true;
            }

            int lvlNum = field.lvlNum;
            bool topClosed = false;
            bool rightClosed = false;
            bool bottomClosed = false;
            bool leftClosed = false;

            for (int i = 0; i < field.WallsX[lvlNum].Length; i++)
            {
                if (field.WallsX[lvlNum][i] == x && field.WallsY[lvlNum][i] == y - 1 ||
                    1 == y)
                {
                    topClosed = true;
                }

                if(field.WallsX[lvlNum][i] == x + 1 && field.WallsY[lvlNum][i] == y ||
                     field.Width - 2 == x)
                {
                    rightClosed = true;
                }

                if(field.WallsX[lvlNum][i] == x && field.WallsY[lvlNum][i] == y + 1 ||
                    field.Height - 2 == y)
                {
                    bottomClosed = true;
                }

                if(field.WallsX[lvlNum][i] == x - 1 && field.WallsY[lvlNum][i] == y ||
                    1 == x)
                {
                    leftClosed = true;
                }
            }

            if (topClosed && rightClosed ||
                rightClosed && bottomClosed ||
                bottomClosed && leftClosed ||
                leftClosed && topClosed)
            {
                return true;
            }

            return false;
        }
    }
}