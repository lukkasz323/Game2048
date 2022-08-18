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
                    Console.Write($"   {board[i, j]}");
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

        static Input GetUserInput()
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

        static void Move(Input direction)
        {
            switch (direction)
            {
                case Input.Up:
                    break;
                case Input.Down:
                    break;
                case Input.Left:
                    break;
                case Input.Right:
                    break;
            }
        }

        static bool GameHasEnded(Input input, int[,] board)
        {
            if (input == Input.Quit)
            {
                return true;
            }

            foreach (int n in board)
            {
                if (n == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static void Main()
        {
            Input input;
            int[,] board = new int[4, 4];
            bool run = true;

            Console.Title = "Game 2048";
            SpawnNumber(board);
            while (run)
            {
                SpawnNumber(board);
                UpdateScreen(board);
                while (true)
                {
                    input = GetUserInput();
                    if (GameHasEnded(input, board))
                    {
                        run = false;
                    }
                    if (input != Input.None)
                    {
                        break;
                    }
                }
                
            }
        }
    }
}