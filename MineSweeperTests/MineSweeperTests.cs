using System;
using MineSweeper.Application;
using MineSweeper.Domain;
using MineSweeper.Domain.Model;
using NSubstitute;
using StructureMap;
using Xunit;

namespace MineSweeper.Tests
{
    public class MineSweeperTests
    {
        private readonly IRandomNumbersGenerator _random = new RandomNumbersGenerator(1);
        private readonly Container _container = new Container(c => c.AddRegistry<ApplicationRegistry>());

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 3)]

        public void FillGrid_ReturnsValidGrid(uint yAxis, uint xAxis, uint mines)
        {
            var operations = _container.GetInstance<DigSquare>();
            operations.FillGrid(yAxis, xAxis, mines);
            Assert.True(operations.CheckSquare(0,0) == SquareStatus.Covered);
            Assert.Equal((uint)0, operations.MineField[0,0].AdjacentSquaresWithMines);
        }

        [Theory]
        [InlineData(2, 4, 10)]
        [InlineData(1, 1, 2)]
        public void FillGrid_ToManyMines_ThrowsException(uint yAxis, uint xAxis, uint mines)
        {
            var grid = new Grid(_random);
            Assert.Throws<Exception>(() => grid.FillGrid(yAxis, xAxis, mines ));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]

        public void Square(bool isMine)
        {
            var square = new Square(isMine, isUncovered:false);
            Assert.Equal(isMine, square.IsMine);
        }

        [Fact]
        public void CheckSquare_ReturnsValidSquareStatus()
        {

        }


    }
}