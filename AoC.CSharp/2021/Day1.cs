using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.CSharp._2021
{
    public class Day1 : IChallenge
    {
        public string SolvePart1(string input)
        {
            var ints = Helper.FilterEmptyOrNull(Helper.SplitByNewLine(input)).Select(int.Parse).ToList();
            
            return ints.SkipLast(1).Count(i => i > ints.Last()).ToString();
        }

        public string SolvePart2(string input)
        {
            var ints = Helper.FilterEmptyOrNull(Helper.SplitByNewLine(input)).Select(s => int.Parse(s)).ToArray();
            
            int increases = 0;
            for (int i = 0; i < ints.Length; ++i)
            {
                int total = ints.Skip(i).Take(Math.Min(3, ints.Length - i)).Sum();
                int nextTotal = ints.Skip(i + 1).Take(Math.Min(3, ints.Length - i - 1)).Sum();
                
                increases += nextTotal > total ? 1 : 0;
            }

            return increases.ToString();
        }
    }
}