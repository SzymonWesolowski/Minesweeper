using System;
using MineSweeper.Application;
using MineSweeper.Domain.Model;
using StructureMap;

namespace MineSweeper.TestPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(c => c.AddRegistry<MineSweeperRegistry>());
            var operations = container.GetInstance<IMineSweeperOperations>();
            do
            {
                operations.DigSquare();
            } while (true);
        }
    }
}
