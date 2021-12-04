using System;
using System.Linq;

namespace AoC.CSharp._2020
{
    public class Day6 : IChallenge
    {
        public string SolvePart1(string input) =>
            input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Replace("\n", "")).Select(l => l.ToHashSet()).Sum(h => h.Count)
                .ToString();

        public string SolvePart2(string input)
        {
            var output = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
                .Where(s => s.Length == s.Replace("\n", "").ToHashSet().Count());

            return "";
        }
    }
}