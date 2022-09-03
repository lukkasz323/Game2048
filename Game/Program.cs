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

        static Input ReadUserInput()
        {
            return Console.ReadKey(true).Key switch
            {
                ConsoleKey.Escape => Input.Quit,
                ConsoleKey.W => Input.Up,
                ConsoleKey.S => Input.Down,
                ConsoleKey.A => Input.Left,
                ConsoleKey.D => Input.Right,
                _ => Input.None
            };
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

        static bool PlayerHasWon(int[,] board)
        {
            foreach (int n in board)
            {
                if (n >= 2048)
                {
                    return true;
                }
            }

            return false;
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
            Random rng = new();
            bool run = false;

            foreach (int value in board)
            {
                if (value == 0)
                {
                    run = true;
                }
            }
            while (run)
            {
                int x = rng.Next(board.GetLength(1));
                int y = rng.Next(board.GetLength(0));

                if (board[y, x] == 0)
                {
                    board[y, x] = 1;
                    break;
                }
            }
        }

        static void Move(Input direction, int[,] board)
        {
            bool checkNeeded = true;
            while (checkNeeded)
            {
                checkNeeded = false;
                for (int y = 0; y < board.GetLength(0); y++)
                {
                    for (int x = 0; x < board.GetLength(1); x++)
                    {
                        try
                        {
                            ValueTuple<int, int> shift = direction switch
                            {
                                Input.Up => (y - 1, x),
                                Input.Down => (y + 1, x),
                                Input.Left => (y, x - 1),
                                Input.Right => (y, x + 1),
                                _ => throw new InvalidOperationException(default)
                            };

                            ref int cell = ref board[y, x];
                            ref int next_cell = ref board[shift.Item1, shift.Item2];

                            if (cell > 0 && next_cell == 0)
                            {
                                (cell, next_cell) = (next_cell, cell);

                                checkNeeded = true;
                            }
                            else if ((cell != 0) && (cell == next_cell))
                            {
                                next_cell *= 2;
                                cell = 0;

                                checkNeeded = true;
                            }
                        }
                        catch (IndexOutOfRangeException) { }
                    }
                }
            }
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
                if (BoardIsFull(board))
                {
                    Console.WriteLine(" You've lost!");
                    return;
                }
                while (true)
                {
                    input = ReadUserInput();
                    if (input == Input.Quit)
                    {
                        Console.WriteLine(" Quit!");
                        break;
                    }
                    if (input != Input.None)
                    {
                        break;
                    }
                }
                Move(input, board);
                if (PlayerHasWon(board))
                {
                    UpdateScreen(board);
                    Console.WriteLine(" You've won!");
                    return;
                }
            }
        }

        static void Main()
        {
            Console.Title = "Game 2048";
            Run();
        }
    }
}