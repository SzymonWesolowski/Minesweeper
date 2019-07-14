using MineSweeper.Domain;

namespace MineSweeper.Application
{
    public interface IUserOperations
    {
        uint GetNumber(string message);
        void PrintGrid(SquareStatus[,] status);
    }
}
