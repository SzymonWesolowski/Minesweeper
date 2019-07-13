namespace MineSweeper.Domain
{
    public partial class MinefieldOperations
    {
        private readonly IRandomNumbersGenerator _random;

        public void FillGrid(uint yAxis, uint xAxis, uint mines)
        {
            _grid.MineField = new Square[yAxis, xAxis];

            if (mines > yAxis * xAxis)
            {
                throw new Exception("To many mines");
            }

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    _grid.MineField[i, j] = new Square(false, false);
                }
            }

            for (int i = (int) mines; i > 0;)
            {
                var mineOnYAxis = _random.Next((int) yAxis);
                var mineOnXAxis = _random.Next((int) xAxis);
                if (!_grid.MineField[mineOnYAxis, mineOnXAxis].IsMine)
                {
                    _grid.MineField[mineOnYAxis, mineOnXAxis].IsMine = true;
                    i--;
                }
            }

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    if (_grid.MineField[i, j].IsMine)
                        continue;
                    for (int k = i - 1; k <= i + 1; k++)
                    {
                        for (int l = j - 1; l <= j + 1; l++)
                        {
                            if (k != i || l != j)
                            {
                                try
                                {
                                    if (_grid.MineField[k, l].IsMine)
                                        _grid.MineField[i, j].AdjacentSquaresWithMines++;
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
        }
    }
}