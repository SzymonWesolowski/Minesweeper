using System;
using MineSweeper.Domain;

namespace MineSweeper.Application
{
    public class RandomNumbersGenerator : IRandomNumbersGenerator
    {
        private Random _random;

        public RandomNumbersGenerator()
        {
            _random = new Random();
        }

        public RandomNumbersGenerator(int seed)
        {
            _random = new Random(seed);
        }

        public int Next(int maxExclusive)
        {
            return _random.Next(maxExclusive);
        }
    }
}
