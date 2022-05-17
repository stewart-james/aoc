using System;
using System.Linq;

namespace AoC.CSharp._2015
{
    public class Day8 : IChallenge
    {
        private static bool Match(ReadOnlySpan<char> span, char leader, params char[] pattern)
        {
            if (span.Length <= 1)
                return false;

            if (span[0] != leader)
                return false;

            return pattern.Contains(span[1]);
        }

        private static int Calculate(string s)
        {
            int len = -2; // automatically skip the quotes

            var span = s.AsSpan();
            while (span.Length > 0)
            {
                if (Match(span, '\\', '\\', '\"'))
                    span = span[2..];
                else if (Match(span, '\\', 'x'))
                    span = span[4..];
                else
                    span = span[1..];

                len += 1;
            }

            return s.Length - len;
        }

        private static int CalculateReverse(string s)
            => s.Sum(ch => ch is '\"' or '\\' ? 2 : 1) + 2 - s.Length;

        public string SolvePart1(string input)
            => input.Split('\n')
                .Select(Calculate)//s => s.Length - Calculate(s))
                .Sum()
                .ToString();

        public string SolvePart2(string input)
            => input.Split('\n')
                .Select(CalculateReverse)
                .Sum()
                .ToString();
    }
}