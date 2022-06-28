
namespace SebzGameOfLife
{
    public class GameCell
    {
        public int XIndex { get; }
        public int YIndex { get; }
        public bool IsAlive { get; private set; }
        public bool IsAliveNext { get; private set; }
        public IList<GameCell> Neighbours { get; set; } = new List<GameCell>();


        public GameCell(int x, int y, bool isAlive)
        {
            XIndex = x;
            YIndex = y;
            IsAlive = isAlive;
        }

        public void CalculateNextState()
        {
            var aliveNeighbours = Neighbours.Count(n => n.IsAlive);
            IsAliveNext = (!IsAlive && aliveNeighbours == 3) || (IsAlive && aliveNeighbours > 1 && aliveNeighbours < 4);
        }

        public void ApplyState()
        {
            IsAlive = IsAliveNext;
        }
    }
}