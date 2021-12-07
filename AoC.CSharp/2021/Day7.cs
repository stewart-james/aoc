using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AoC.CSharp._2021
{
    public class Day7 : IChallenge
    {
        public string SolvePart1(string input)
        {
            var ints = Helper.ParseInts(input.Split(",")).ToList();

            var horizontalPositionByFuelRequired = new Dictionary<int, int>();
            for (int i = 0; i < ints.Max(); ++i)
                horizontalPositionByFuelRequired[i] = ints.Sum(n => Math.Abs(i - n));

            var bestPosition = horizontalPositionByFuelRequired.Min(k => k.Value);

            return bestPosition.ToString();
        }

        public string SolvePart2(string input)
        {
            var ints = Helper.ParseInts(input.Split(",")).ToList();

            var horizontalPositionByFuelRequired = new Dictionary<int, int>();
            for (int i = 1; i < ints.Max(); ++i)
                horizontalPositionByFuelRequired[i] = ints.Sum(n => Math.Abs(i - n) * (Math.Abs(i - n)+1) / 2);

            var bestPosition = horizontalPositionByFuelRequired.Min(k => k.Value);

            return bestPosition.ToString();
        }
    }
}