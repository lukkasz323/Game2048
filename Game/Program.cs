namespace Game
{
    class Program
    {
        enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        static void UpdateScreen(int[,] board)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  Use 'WASD' to move");
            Console.WriteLine();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"   {board[i, j]}");
                }
                Console.WriteLine("\n");
            }
        }

        static void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    break;
                case Direction.Down:
                    break;
                case Direction.Left:
                    break;
                case Direction.Right:
                    break;
            }
        }

        static void Main()
        {
            int[,] board = new int[4, 4];
            bool run = true;
            ConsoleKeyInfo key;

            Console.Title = "Game 2048";
            while (run)
            {
                UpdateScreen(board);
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        run = false;
                        break;
                    case ConsoleKey.W:
                        Move(Direction.Up);
                        break;
                    case ConsoleKey.S:
                        Move(Direction.Down);
                        break;
                    case ConsoleKey.A:
                        Move(Direction.Left);
                        break;
                    case ConsoleKey.D:
                        Move(Direction.Right);
                        break;
                }
            }
        }
    }
}