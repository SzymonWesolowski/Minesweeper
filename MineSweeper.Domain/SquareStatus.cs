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
        Flagged
    }
}
