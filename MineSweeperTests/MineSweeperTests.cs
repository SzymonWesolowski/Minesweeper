using System;
using MineSweeper.Application;
using MineSweeper.Domain;
using MineSweeper.Domain.Model;
using NSubstitute;
using Xunit;

namespace MineSweeper.Tests
{
    public class MineSweeperTests
    {
        private readonly IRandomNumbersGenerator _random = new RandomNumbersGenerator(1);

        [Fact]
        public void CreateGrid_CreateValidGrid()
        {
            var createGrid = new CreateGrid(_random);

            var grid = createGrid.Create(2, 2, 2);

            Assert.True(grid.MineField[0, 0].IsMine);
            Assert.True(grid.MineField[0, 1].IsMine);
            Assert.False(grid.MineField[1, 0].IsMine);
            Assert.False(grid.MineField[1, 1].IsMine);
            Assert.Equal((uint) 0, grid.MineField[0, 0].AdjacentSquaresWithMines);
            Assert.Equal((uint) 0, grid.MineField[0, 1].AdjacentSquaresWithMines);
            Assert.Equal((uint) 2, grid.MineField[1, 0].AdjacentSquaresWithMines);
            Assert.Equal((uint) 2, grid.MineField[1, 1].AdjacentSquaresWithMines);
        }

        [Theory]
        [InlineData(2, 2, 5)]
        [InlineData(10, 5, 55)]
        [InlineData(1, 1, 2)]
        public void CreateGrid_ToManyMines_ThrowsException(uint yAxis, uint xAxis, uint mines)
        {
            var createGrid = new CreateGrid(_random);

            Assert.Throws<Exception>(() => createGrid.Create(yAxis, xAxis, mines));
        }

        [Theory]
        [InlineData(true, true, false, 0, SquareStatus.Mine)]
        [InlineData(false, false, false, 3, SquareStatus.Covered)]
        [InlineData(false, true, false, 2, SquareStatus.TwoAdjacentMines)]
        public void CheckSquare_ReturnsValidSquareStatus(bool isMine, bool isUncovered, bool isFlagged,  uint adjacentSquaresMines,
            SquareStatus squareStatus)
        {
            var grid = new Grid {MineField = new Square[1, 1]};
            var square = new Square(isMine, isUncovered, isFlagged) {AdjacentSquaresWithMines = adjacentSquaresMines};
            grid.MineField[0, 0] = square;
            var check = new CheckSquare();

            var status = check.Check(grid, 0, 0);

            Assert.Equal(squareStatus, status);
        }

        [Fact]
        public void DigSquare_DigSquareWhithoutMine()
        {
            var createGrid = new CreateGrid(_random);
            var grid = createGrid.Create(2, 2, 2);
            var digSquare = new DigSquare();

            Assert.True(digSquare.Dig(grid, 1, 1));
            Assert.False(grid.MineField[0,0].IsUncovered);
            Assert.False(grid.MineField[0,1].IsUncovered);
            Assert.False(grid.MineField[1,0].IsUncovered);
            Assert.True(grid.MineField[1,1].IsUncovered);

        }

        [Fact]
        public void DigSquare_DigSquareWithMine()
        {
            var createGrid = new CreateGrid(_random);
            var grid = createGrid.Create(2, 2, 2);
            var digSquare = new DigSquare();

            Assert.False(digSquare.Dig(grid, 0, 0));
        }

        [Fact]
        public void FlagSquare_SquareIsFlagged()
        {
            var createGrid = new CreateGrid(_random);
            var grid = createGrid.Create(2, 2, 2);
            var flag = new FlagSquare();
            flag.Flag(grid, 0, 0);
            Assert.True(grid.MineField[0,0].IsFlagged);
        }

        [Fact]
        public void FlagSquare_FlagUncoveredSquare_SquareIsNotFlagged()
        {
            var createGrid = new CreateGrid(_random);
            var grid = createGrid.Create(2, 2, 2);
            grid.MineField[1, 1].IsUncovered = true;
            var flag = new FlagSquare();
            flag.Flag(grid, 1, 1);
            Assert.False((grid.MineField[1,1].IsFlagged));
        }

        [Fact]
        public void IntegrationTest()
        {
            var createGrid = new CreateGrid(_random);
            var checkSquare = Substitute.For<ICheckSquare>();
            var digSquare = new DigSquare();
            var flagSquare = Substitute.For<IFlagSquare>();
            var userOperations = Substitute.For<IUserOperations>();

            userOperations.GetNumber("").ReturnsForAnyArgs((uint)2);
            var operations = new MineSweeperOperations(createGrid, checkSquare, digSquare, flagSquare, userOperations);
            userOperations.GetNumber("").ReturnsForAnyArgs((uint)1);
            Assert.True( operations.DigSquare());

        }
    }
}