using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.CSharp._2020
{
    public class Day5 : IChallenge
    {
        public readonly struct Range
        {
            public int From { get; }
            public int To { get; }

            public Range(int from, int to)
            {
                From = from;
                To = to;
            }

            public Range TakeLowerHalf()
            {
                return new Range(From, From + (To - From) / 2);
            }

            public Range TakeUpperHalf()
            {
                return new Range(From + (To+1 - From) / 2 , To);
            }
        }

        public string SolvePart1(string input)
            => Helper.FilterEmptyOrNull(Helper.SplitByNewLine(input))
                .Select(s => CalculateSeatId(s))
                .Max().ToString();

        public int CalculateSeatId(string input)
        {
            var range = new Range(0, 127);
            int i = 0;
            while (range.From != range.To)
            {
                switch (input[i++])
                {
                    case 'F':
                        range = range.TakeLowerHalf();
                        break;
                    case 'B':
                        range = range.TakeUpperHalf();
                        break;
                }
            }

            int row = range.From;

            range = new Range(0, 7);
            while (range.From != range.To)
            {
                switch (input[i++])
                {
                    case 'R':
                        range = range.TakeUpperHalf();
                        break;
                    case 'L':
                        range = range.TakeLowerHalf();
                        break;
                }
            }

            int col = range.From;

            return row * 8 + col;
        }

        public string SolvePart2(string input)
        {
            var seats = Helper.FilterEmptyOrNull(Helper.SplitByNewLine(input)).Select(s => CalculateSeatId(s))
                .ToHashSet();
            
            var ints = 
                seats
                .Skip(1)
                .SkipLast(1)
                .ToList();

            return Part2Algo(ints).First(i => !seats.Contains(i)).ToString();
        }
        
        private List<int> Part2Algo(List<int> ints)
        {
            var rslt = new List<int>();
            foreach (int i in ints)
            {
                foreach (int b in ints)
                {
                    if (Math.Abs(i - b) == 2)
                    {
                        if (i > b)
                            rslt.Add(b + 1);
                        else
                            rslt.Add(i + 1);
                    }
                }
            }

            return rslt;
        }

    }
}