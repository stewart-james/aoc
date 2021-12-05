using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC.CSharp._2021
{
    public class Day5 : IChallenge
    {
        private int x1(string[] a) => int.Parse(a[0].Split(",")[0]);
        private int y1(string[] a) => int.Parse(a[0].Split(",")[1]);
        private int x2(string[] a) => int.Parse(a[1].Split(",")[0]);
        private int y2(string[] a) => int.Parse(a[1].Split(",")[1]);
        
        public string SolvePart1(string input) => Solve(input, false);

        public string SolvePart2(string input) => Solve(input, true);

        string Solve(string input, bool includeDiagonals) =>
            input
            .Split("\n")
            .Where(s => !string.IsNullOrEmpty(s))
            .Select(s =>
                s.Split(" -> "))
            .Select(a =>
                (x1(a), y1(a), x2(a), y2(a)))
            .Where(t => includeDiagonals || t.Item1 == t.Item3 || t.Item2 == t.Item4) // exclude diagonals for p1
            .SelectMany(t => Enumerable
                .Range(0, Math.Max(Math.Abs((int)(t.Item1 - t.Item3)), Math.Abs((int)(t.Item2 - t.Item4))) + 1)
                .Select(i => (
                    t.Item1 > t.Item3 ? t.Item3 + i : t.Item1 < t.Item3 ? t.Item3 - i : t.Item3,
                    t.Item2 > t.Item4 ? t.Item4 + i :
                    t.Item2 < t.Item4 ? t.Item4 - i :
                    t.Item4)))
            .GroupBy(k => k)
            .Count(k => Enumerable.Count(k) >= 2)
            .ToString();
    }
}