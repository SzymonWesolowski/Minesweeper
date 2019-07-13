using System;
using MineSweeper.Domain.Model;

namespace MineSweeper.Domain
{
    public interface ICreateGrid
    {
        Grid Create(uint yAxis, uint xAxis, uint mines);
    }

    public class CreateGrid : ICreateGrid
    {
        private readonly IRandomNumbersGenerator _random;

        public CreateGrid(IRandomNumbersGenerator random, IGrid grid)
        {
            _random = random;
        }


        public Grid Create(uint yAxis, uint xAxis, uint mines)
        {
            var grid = new Grid (){MineField = new Square[yAxis, xAxis]};

            if (mines > yAxis * xAxis)
            {
                throw new Exception("To many mines");
            }

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    grid.MineField[i, j] = new Square(false, false);
                }
            }

            for (int i = (int) mines; i > 0;)
            {
                var mineOnYAxis = _random.Next((int) yAxis);
                var mineOnXAxis = _random.Next((int) xAxis);
                if (!grid.MineField[mineOnYAxis, mineOnXAxis].IsMine)
                {
                    grid.MineField[mineOnYAxis, mineOnXAxis].IsMine = true;
                    i--;
                }
            }

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    if (grid.MineField[i, j].IsMine)
                        continue;
                    for (int k = i - 1; k <= i + 1; k++)
                    {
                        for (int l = j - 1; l <= j + 1; l++)
                        {
                            if (k != i || l != j)
                            {
                                try
                                {
                                    if (grid.MineField[k, l].IsMine)
                                        grid.MineField[i, j].AdjacentSquaresWithMines++;
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
            }

            return grid;
        }
    }
}