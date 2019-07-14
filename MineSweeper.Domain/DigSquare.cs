using System;
using MineSweeper.Domain.Model;

namespace MineSweeper.Domain
{
    public interface IDigSquare
    {
        bool Dig(IGrid grid, uint yAxis, uint xAxis, bool chosed = true);
    }

    public class DigSquare : IDigSquare
    {

        public bool Dig(IGrid grid,uint yAxis, uint xAxis, bool chosed = true)
        {
            if (grid.MineField[yAxis, xAxis].IsMine && chosed)
                return false;
            if (grid.MineField[yAxis, xAxis].IsFlagged && chosed)
                return true;
            if (!grid.MineField[yAxis, xAxis].IsMine)
            {
                grid.MineField[yAxis, xAxis].IsUncovered = true;
                for (var k = (int) yAxis - 1; k <= yAxis + 1; k++)
                {
                    for (var l = (int) xAxis - 1; l <= xAxis + 1; l++)
                    {
                        if (k == yAxis && l == xAxis)
                            continue;
                        try
                        {
                            if (!grid.MineField[k, l].IsMine && !grid.MineField[k, l].IsUncovered &&
                                !grid.MineField[k, l].IsFlagged &&
                                (grid.MineField[yAxis, xAxis].AdjacentSquaresWithMines == 0 ||
                                 grid.MineField[k, l].AdjacentSquaresWithMines == 0))
                            {
                                grid.MineField[k, l].IsUncovered = true;
                                if (grid.MineField[k, l].AdjacentSquaresWithMines == 0)
                                    Dig(grid, (uint)k, (uint) l, false);
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            continue;
                        }
                    }
                }
            }

            return true;
        }
    }
}