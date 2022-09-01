using System;

namespace Game
{
    class Program
    {
        enum Input
        {
            None,
            Quit,
            Up,
            Down,
            Left,
            Right
        }

        static void UpdateScreen(int[,] board)
        {
            Console.Clear();
            Console.WriteLine("\n  Use 'WASD' to move | 'Esc' to quit\n");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    int cell = board[i, j];
                    if (cell == 0)
                    {
                        Console.Write("   -");
                    }
                    else
                    {
                        Console.Write($"   {cell}");
                    }
                }
                Console.WriteLine("\n");
            }
        }

        static void SpawnNumber(int[,] board)
        {
            int x, y;
            bool run = false;
            Random rng = new();

            foreach (int value in board)
            {
                if (value == 0)
                {
                    run = true;
                }
            }
            while (run)
            {
                x = rng.Next(board.GetLength(1));
                y = rng.Next(board.GetLength(0));

                if (board[y, x] == 0)
                {
                    board[y, x] = 1;
                    break;
                }
            } 
        }

        static Input ReadUserInput()
        {
            ConsoleKeyInfo key;

            key = Console.ReadKey(true);
            return key.Key switch
            {
                ConsoleKey.Escape => Input.Quit,
                ConsoleKey.W => Input.Up,
                ConsoleKey.S => Input.Down,
                ConsoleKey.A => Input.Left,
                ConsoleKey.D => Input.Right,
                _ => Input.None
            };
        }

        static void Move(Input direction, int[,] board)
        {
            bool checkNeeded = true;
            int temp;
            ValueTuple<int, int> shift;

            while (checkNeeded)
            {
                checkNeeded = false;
                for (int y = 0; y < board.GetLength(0); y++)
                {
                    for (int x = 0; x < board.GetLength(1); x++)
                    {
                        try
                        {
                            shift = direction switch
                            {
                                Input.Up => (y - 1, x),
                                Input.Down => (y + 1, x),
                                Input.Left => (y, x - 1),
                                Input.Right => (y, x + 1),
                                _ => throw new InvalidOperationException(default)
                            };
                            if (board[shift.Item1, shift.Item2] == 0)
                            {
                                temp = board[y, x];
                                board[y, x] = board[shift.Item1, shift.Item2];
                                board[shift.Item1, shift.Item2] = temp;

                                //checkNeeded = true;
                            }
                        }
                        catch (IndexOutOfRangeException) { }
                    }
                }
            }  
        }

        static bool BoardIsFull(int[,] board)
        {
            foreach (int n in board)
            {
                if (n == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static void Run()
        {
            Input input;
            int[,] board = new int[4, 4];

            SpawnNumber(board);
            while (true)
            {
                SpawnNumber(board);
                UpdateScreen(board);
                while (true)
                {
                    if (BoardIsFull(board))
                    {
                        Console.WriteLine(" You've lost!");
                        return;
                    }

                    input = ReadUserInput();
                    if (input == Input.Quit)
                    {
                        Console.WriteLine(" Quit!");
                        return;
                    }
                    if (input != Input.None)
                    {
                        break;
                    }
                }
                Move(input, board);
            }
        }

        static void Main()
        {
            Console.Title = "Game 2048";
            Run();
        }
    }
}