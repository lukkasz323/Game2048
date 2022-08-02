namespace Game
{
    class Program
    {
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

        static void Main()
        {
            int[,] board = new int[4, 4];
            bool run = true;

            Console.Title = "Game 2048";
            while (run)
            {
                UpdateScreen(board);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        run = false;
                        break;
                    case ConsoleKey.W:
                        break;
                    case ConsoleKey.S:
                        break;
                    case ConsoleKey.A:
                        break;
                    case ConsoleKey.D:
                        break;
                }
            }
        }
    }
}