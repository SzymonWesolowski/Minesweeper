using MineSweeper.Domain;
using MineSweeper.Domain.Model;

namespace MineSweeper.Application
{
    public interface IMineSweeperOperations
    {
        bool DigSquare();
        bool FlagSquare();
    }

    public class MineSweeperOperations : IMineSweeperOperations
    {
        private readonly IGrid _grid;
        private readonly ICreateGrid _createGrid;
        private readonly ICheckSquare _checkSquare;
        private readonly IDigSquare _digSquare;
        private readonly IFlagSquare _flagSquare;
        private readonly IUserOperations _userOperations;
        private uint _yAxis;
        private uint _xAxis;

        public MineSweeperOperations(ICreateGrid createGrid, ICheckSquare checkSquare, IDigSquare digSquare, IFlagSquare flagSquare,
            IUserOperations userOperations)
        {
            _createGrid = createGrid;
            _checkSquare = checkSquare;
            _digSquare = digSquare;
            _flagSquare = flagSquare;
            _userOperations = userOperations;
            _grid = FillGrid();
        }


        public bool DigSquare()
        {
            var yAxisLocation = _userOperations.GetNumber("podaj y");
            var xAxisLocation = _userOperations.GetNumber("podaj x");
             bool continiuePlay = _digSquare.Dig(_grid, yAxisLocation, xAxisLocation);
            ShowGrid(_grid);
            return continiuePlay;
        }

        public bool FlagSquare()
        {
            var yAxisLocation = _userOperations.GetNumber("podaj y");
            var xAxisLocation = _userOperations.GetNumber("podaj x");
            _flagSquare.Flag(_grid, yAxisLocation, xAxisLocation);
            ShowGrid(_grid);
            return true;
        }

        private IGrid FillGrid()
        {
            _yAxis = _userOperations.GetNumber("Podaj wymiar y");
            _xAxis = _userOperations.GetNumber("Podaj wymiar x");
            var mines = _userOperations.GetNumber("Podaj liczbę bomb");
            var grid = _createGrid.Create(_yAxis, _xAxis, mines);
            ShowGrid(grid);
            return grid;
        }

        private void ShowGrid(IGrid grid)
        {
            SquareStatus[,] statusGrid = new SquareStatus[_yAxis, _xAxis];
            for (int i = 0; i < _yAxis; i++)
            {
                for (int j = 0; j < _xAxis; j++)
                {
                    statusGrid[i, j] = _checkSquare.Check(grid, (uint) i, (uint) j);
                }
            }

            _userOperations.PrintGrid(statusGrid);
        }

    }
}