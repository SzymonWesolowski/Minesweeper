namespace MineSweeper.Domain.Model
{
    public interface IGrid
    {
        Square[,] MineField { get; set; }
    }

    public class Grid : IGrid
    {

        public Square[,] MineField { get; set; }
    }
}