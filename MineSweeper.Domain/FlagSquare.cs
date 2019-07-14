using MineSweeper.Domain.Model;

namespace MineSweeper.Domain
{
    public interface IFlagSquare
    {
        void Flag(IGrid grid, uint yAxis, uint xAxis);
    }

    public class FlagSquare : IFlagSquare
    {
        public void Flag(IGrid grid, uint yAxis, uint xAxis)
        {
            if (!grid.MineField[yAxis, xAxis].IsUncovered)
                grid.MineField[yAxis, xAxis].IsFlagged = true;
        }
    }
}