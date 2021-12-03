using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.CSharp._2020
{
    public class Day3 : IChallenge
    {
        public string SolvePart1(string input)
            => CalculateTrees(
                    Helper.FilterEmptyOrNull(Helper.SplitByNewLine(input)).ToList(),
                    new List<Tuple<int, int>> { new(3, 1) })
                .First()
                .ToString();

        public string SolvePart2(string input) =>
            CalculateTrees(
                    Helper.FilterEmptyOrNull(Helper.SplitByNewLine(input)).ToList(),
                    new List<Tuple<int, int>>
                    {
                        new(1, 1),
                        new(3, 1),
                        new(5, 1),
                        new(7, 1),
                        new(1, 2)
                    })
                .Aggregate(1l, (x, y) => x * y)
                .ToString();

        private List<long> CalculateTrees(List<string> input, List<Tuple<int, int>> movements)
        {
            var results = new List<long>();
            foreach (var check in movements)
            {
                int offset = 0;
                int trees = 0;
                for(int i = 0; i < input.Count; i += check.Item2)
                {
                    var str = input[i];
                    
                    if (str[offset] == '#')
                        trees++;
                    
                    if (offset + check.Item1 >= str.Length)
                        offset = (check.Item1 - 1) - ((str.Length - 1) - offset);
                    else
                        offset += check.Item1;
                }

                results.Add(trees);
            }

            return results;
        }
        
        
        
        
    }
}