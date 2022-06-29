
namespace SebzGameOfLife
{
    public class Board
    {
        private GameCell[,] _cells;
        private const float CHANCES_BEING_ALIVE = .5f;
        public List<GameCell> Cells => _cells.Cast<GameCell>().ToList();

        public void SetNeighbours(GameCell cell)
        {
            cell.Neighbours = Cells
                .Where(c => c != cell && Math.Abs(cell.XIndex - c.XIndex) < 2 && Math.Abs(cell.YIndex - c.YIndex) < 2).ToList();
        }


        public GameCell? GetCell(int x, int y)
        {
            return _cells[x, y];
        }

        public Board(int width, int height)
        {
            _cells = new GameCell[width, height];

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    var isAlive = new Random().NextDouble() < CHANCES_BEING_ALIVE;
                    _cells[i, j] = new GameCell(i, j, isAlive);
                }
            }

            foreach (var cell in _cells)
            {
                SetNeighbours(cell);
            }
        }
    }
}