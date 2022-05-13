using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AoC.CSharp._2015
{
    public class Day3 : IChallenge
    {
        public string SolvePart1(string input) 
            => PlotMoves(input.TrimEnd('\n'))
                .GroupBy(c => c)
                .Count()
                .ToString();

        public string SolvePart2(string input) => 
            PlotMoves(ExtractPath(input.TrimEnd('\n'), false))
                .Concat(PlotMoves(ExtractPath(input.TrimEnd('\n'), true)))
                .Distinct()
                .Count() 
                .ToString();

        private IEnumerable<(int, int)> PlotMoves(IEnumerable<char> input) =>
            input
                .Aggregate(new List<(int, int)> { (0, 0) }, (acc, move) =>
                    acc.Append(MakeMove(acc.Last(), move)).ToList());
        
        private IEnumerable<char> ExtractPath(string input, bool evilSanta)
            => Enumerable.Range(0, input.Length)
                .Where(idx => evilSanta ? (idx + 1) % 2 == 0 : (idx + 1) % 2 != 0) 
                .Select(idx => input[idx]);

        private (int, int) MakeMove((int, int) current, char direction)
            => (current.Item1 + MoveX(direction), current.Item2 + MoveY(direction));
        
        private int MoveX(char direction) =>
            direction switch
            {
                '>' => 1,
                '<' => -1,
                _ => 0
            };

        private int MoveY(char direction) =>
            direction switch {
                '^' => 1,
                'v' => -1,
                _ => 0
            };
    }
}