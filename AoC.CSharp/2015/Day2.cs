using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AoC.CSharp._2015
{
    public class Day2 : IChallenge
    {
        private IEnumerable<List<int>> ParseInput(string input)
            => input
                .TrimEnd('\n')
                .Split("\n")
                .Select(s => s.Split("x"))
                .Select(s => s.Select(int.Parse)
                    .ToList());
        
        // Calculating wrapping paper where the total wrapping paper per present is calculated as
        // smallest side + total area of present
        // e.g 2x3x6 | smallest side = 6 (2x3) | total area = 52 ( 2*(2*3) + 2*(3*4) + 2*(2*4) )
        public string SolvePart1(string input)
            => ParseInput(input) 
                .Select(Sides)
                .Sum(sides => sides.Min() + sides.Sum(side => side * 2))
                .ToString();
        
        private const int Length = 0;
        private const int Width = 1;
        private const int Height = 2;

        private static List<int> Sides(List<int> dimensions) => new()
        {
            dimensions[Length] * dimensions[Width],
            dimensions[Width] * dimensions[Height],
            dimensions[Height] * dimensions[Length]
        };

        // Ribbon to wrap the present
        //
        // Ribbon calculated as: shortest distance around the sides
        //  2x3x4 = 2+2+3+3 = 10
        //
        // Bow calculated as: volume of present
        //  2x3x4 = 2*3*4 = 24
        // 
        // total ribbon required = 10 + 24 = 34
        public string SolvePart2(string input)
            => ParseInput(input)
                .Sum(dimenions => CalculateRibbon(dimenions) + CalculateBow(dimenions))
                .ToString();

        private static int CalculateRibbon(List<int> dimensions)
            => dimensions
                .OrderBy(i => i)
                .Take(2)
                .Sum(side => side * 2);
        
        private static int CalculateBow(List<int> dimensions)
            => dimensions.Aggregate(1, (acc, side) => acc * side);
    }
}