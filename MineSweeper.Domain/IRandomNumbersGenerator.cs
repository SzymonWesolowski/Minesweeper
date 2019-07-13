namespace MineSweeper.Domain
{
    public interface IRandomNumbersGenerator 
    {
        int Next(int maxExclusive);
    }
}