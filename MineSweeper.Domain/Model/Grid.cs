using System;
using System.Linq.Expressions;
using System.Reflection;

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