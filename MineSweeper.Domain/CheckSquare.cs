using MineSweeper.Domain.Model;

namespace MineSweeper.Domain
{
    public interface ICheckSquare
    {
        SquareStatus Check(IGrid grid, uint yAxis, uint xAxis);
    }

    public class CheckSquare : ICheckSquare
    {
        public SquareStatus Check(IGrid grid, uint yAxis, uint xAxis)
        {
            return grid.MineField[yAxis, xAxis].IsFlagged ? SquareStatus.Flagged :
                !grid.MineField[yAxis, xAxis].IsUncovered ? SquareStatus.Covered :
                grid.MineField[yAxis, xAxis].IsMine ? SquareStatus.Mine :
                grid.MineField[yAxis, xAxis].AdjacentSquaresWithMines == 0 ? SquareStatus.Empty :
                grid.MineField[yAxis, xAxis].AdjacentSquaresWithMines == 1 ? SquareStatus.OneAdjacentMine :
                grid.MineField[yAxis, xAxis].AdjacentSquaresWithMines == 2 ? SquareStatus.TwoAdjacentMines :
                grid.MineField[yAxis, xAxis].AdjacentSquaresWithMines == 3 ? SquareStatus.ThreeAdjacentMines :
                grid.MineField[yAxis, xAxis].AdjacentSquaresWithMines == 4 ? SquareStatus.FourAdjacentMines :
                grid.MineField[yAxis, xAxis].AdjacentSquaresWithMines == 5 ? SquareStatus.FiveAdjacentMines :
                grid.MineField[yAxis, xAxis].AdjacentSquaresWithMines == 6 ? SquareStatus.SixAdjacentMines :
                grid.MineField[yAxis, xAxis].AdjacentSquaresWithMines == 7 ? SquareStatus.SevenAdjacentMines :
                SquareStatus.EightAdjacentMines;
        }
    }
}