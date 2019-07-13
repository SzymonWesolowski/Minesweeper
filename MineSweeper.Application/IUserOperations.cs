using System;
using System.Collections.Generic;
using System.Text;
using MineSweeper.Domain;
using MineSweeper.Domain.Model;

namespace MineSweeper.Application
{
    public interface IUserOperations
    {
        uint GetNumber(string message);
        void PrintGrid(SquareStatus[,] status);
    }
}
