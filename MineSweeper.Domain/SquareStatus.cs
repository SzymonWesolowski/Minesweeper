using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper.Domain
{
    public enum SquareStatus
    {
        Covered,
        Mine,
        Empty,
        OneAdjacentMine,
        TwoAdjacentMines,
        ThreeAdjacentMines,
        FourAdjacentMines,
        FiveAdjacentMines,
        SixAdjacentMines,
        SevenAdjacentMines,
        EightAdjacentMines,
    }
}
