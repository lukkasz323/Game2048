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
                    Console.Write($" {board[i, j]}");
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            int[,] board = new int[4, 4];

            Console.Title = "Game 2048";
            while (true)
            {
                UpdateScreen(board);
                Console.ReadKey();
            }
        }
    }
}