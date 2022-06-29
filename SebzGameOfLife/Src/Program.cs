using System.Text;

namespace SebzGameOfLife
{
    static class Program
    {
        const int ROW_AMOUNT = 50;
        const int COLUMN_AMOUNT = 100;

        public static void Main()
        {
            var grid = new Board(ROW_AMOUNT, COLUMN_AMOUNT);

            Console.Clear();

            while (true)
            {
                Display(grid);
                CalculateNext(grid);
            }
        }

        private static void CalculateNext(Board currentBoard)
        {
            currentBoard.Cells.ForEach(c => c.CalculateNextState());
            currentBoard.Cells.ForEach(c => c.ApplyState());
        }

        private static void Display(Board board, int timeout = 500)
        {
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < ROW_AMOUNT; i++)
            {
                for (var j = 0; j < COLUMN_AMOUNT; j++)
                {
                    var cell = board.GetCell(i, j);

                    if (cell == null)
                        throw new Exception("Cell does not exist");

                    stringBuilder.Append(cell.IsAlive ? "O" : ".");
                }

                stringBuilder.Append("\n");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write(stringBuilder.ToString());
            Thread.Sleep(timeout);
        }
    }
}