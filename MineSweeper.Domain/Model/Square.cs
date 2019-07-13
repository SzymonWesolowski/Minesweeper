namespace MineSweeper.Domain.Model
{
    public interface ISquare
    {
        bool IsUncovered { get; set; }
        bool IsMine { get; set; }
        uint AdjacentSquaresWithMines { get; set; }

    }

    public class Square : ISquare
    {

        public Square(bool isMine, bool isUncovered)
        {
            IsMine = isMine;
            IsUncovered = isUncovered;
        }

        public bool IsUncovered { get; set; }
        public bool IsMine { get; set; }
        public uint AdjacentSquaresWithMines { get; set; }

    }
}
