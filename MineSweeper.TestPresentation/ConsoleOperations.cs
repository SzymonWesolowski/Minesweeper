using System;
using System.Collections.Generic;
using MineSweeper.Application;
using MineSweeper.Domain;

namespace MineSweeper.TestPresentation
{
    public class ConsoleOperations : IUserOperations
    {
        public uint GetNumber(string message)
        {
            Console.WriteLine(message);
            return Convert.ToUInt32(Console.ReadLine());
        }

        public void PrintGrid(SquareStatus[,] status)
        {
            for (int i = 0; i < status.GetLength(0)*2+1; i++)
            {
                Console.Write("_");
            }

            Console.Write("\n");
            for (int i = 0; i < status.GetLength(0); i++)
            {
                for (int j = 0; j < status.GetLength(1); j++)
                {
                    Console.Write($"|{_dictionary[status[i, j]]}");
                }

                Console.Write("|\n");
                for (int j = 0; j < status.GetLength(0)*2+1; j++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < status.GetLength(0)*2; i++)
            {
                Console.Write("-");
            }            for (int i = 0; i < status.GetLength(0)*2; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }



        private readonly Dictionary<SquareStatus, char> _dictionary = new Dictionary<SquareStatus, char>
        {
            {SquareStatus.Covered, ' '}, {SquareStatus.Mine, 'x'}, {SquareStatus.Empty, 'E'},
            {SquareStatus.Flagged, 'T'},
            {SquareStatus.OneAdjacentMine, '1'}, {SquareStatus.TwoAdjacentMines, '2'},
            {SquareStatus.ThreeAdjacentMines, '3'}, {SquareStatus.FourAdjacentMines, '4'},
            {SquareStatus.FiveAdjacentMines, '5'},
            {SquareStatus.SixAdjacentMines, '6'}, {SquareStatus.SevenAdjacentMines, '7'},
            {SquareStatus.EightAdjacentMines, '8'}
        };
    }
}