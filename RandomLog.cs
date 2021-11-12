using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
    class RandomLog
    {
        private Random rng;
        long randomNumberCount;

        public RandomLog()
        {
            rng = new Random();
            randomNumberCount = 0;
        }

        public RandomLog(int seed)
        {
            rng = new Random(seed);
            randomNumberCount = 0;
        }

        public int Next(int maxValue)
        {
            randomNumberCount++;
            return rng.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            randomNumberCount++;
            return rng.Next(minValue, maxValue);
        }

        public double NextDouble()
        {
            randomNumberCount++;
            return rng.NextDouble();
        }

        public long GetRandomNumberCount()
        {
            return randomNumberCount;
        }
    }
}
