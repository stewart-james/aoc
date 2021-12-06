using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.CSharp._2021
{
    public class Day6 : IChallenge
    {
        public string SolvePart1(string input) => Solve(input, 80).ToString();

        public string SolvePart2(string input) => Solve(input, 256).ToString();

        long Solve(string input, int days)
        { 
            var fish = new long[9];

            foreach (var i in Helper.ParseInts(input.Split(",")))
                fish[i + 1]++;

            for (int i = 0; i <= days; i++)
                fish[(i + 7) % 9] += fish[i % 9];

            return fish.Sum();
        }
    }
}