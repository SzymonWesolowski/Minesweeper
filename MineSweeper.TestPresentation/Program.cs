using System;
using MineSweeper.Application;
using StructureMap;

namespace MineSweeper.TestPresentation
{
    class Program
    {
        static void Main()
        {
            var container = new Container(c => c.AddRegistry<MineSweeperRegistry>());
            var operations = container.GetInstance<IMineSweeperOperations>();
            bool continiuePlay = true;
            do
            {
                Console.WriteLine("f - oflaguj pole");
                Console.WriteLine("d - odkop pole");
                var input = Console.ReadLine();
                if (input == "d")
                    continiuePlay = operations.DigSquare();
                if (input == "f")
                    operations.FlagSquare();
            } while (continiuePlay);
        }
    }
}