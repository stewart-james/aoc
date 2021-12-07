using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AoC.CSharp._2021
{
    public class Day7 : IChallenge
    {
        public string SolvePart1(string input)
            => Solve(Helper.ParseInts(input.Split(",")).ToList(), true);

        public string SolvePart2(string input)
            => Solve(Helper.ParseInts(input.Split(",")).ToList(), false);

        private string Solve(List<int> input, bool constantFuel)
            => Enumerable.Range(1, input.Max())
                .Select(i =>
                    (i, input.Sum(n => constantFuel ? Math.Abs(i - n) : Math.Abs(i - n) * (Math.Abs(i - n) + 1) / 2)))
                .ToDictionary(i => i.Item1)
                .Min(k => k.Value.Item2)
                .ToString();
    }
}