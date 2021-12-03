using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC.CSharp._2021
{
    public class Day3 : IChallenge
    {
        public string SolvePart1(string input)
        {
            var strs = Helper.SplitByNewLine(input);

            int totalBitsPerColumn = strs.Count;
            var setBits = new int[strs.First().Length];

            foreach (var str in strs)
            {
                for (int i = 0; i < str.Length; ++i)
                {
                    if (str[i] == '1')
                        setBits[i] += 1;
                }
            }

            string gammaStr = "";
            string epsilonStr = "";
            for (int i = 0; i < setBits.Length; ++i)
            {
                gammaStr += (setBits[i] >= (totalBitsPerColumn - setBits[i])) ? '1' : '0';
                epsilonStr += (setBits[i] < (totalBitsPerColumn - setBits[i])) ? '1' : '0';
            }

            int epsilon = Convert.ToInt32(epsilonStr, 2);
            int gamma = Convert.ToInt32(gammaStr, 2);

            return (epsilon * gamma).ToString();
        }

        public string SolvePart2(string input)
        {
            List<string> strs = Helper.FilterEmptyOrNull(Helper.SplitByNewLine(input)).ToList();

            return (
                Find(strs.ToList(), b => b ? '1' : '0') * 
                Find(strs.ToList(), b => b ? '0' : '1')).ToString();
        }

        private int Find(List<string> lines, Func<bool,char> func)
        {
            for (int i = 0; i < lines.First().Length; ++i)
            {
                lines = lines
                    .Where(l => lines.Count == 1 ||
                                l[i] == func(lines.Count(s => s[i] == '1') * 2 >= lines.Count))
                    .ToList();
            }

            return Convert.ToInt32(lines[0], 2);
        }
    }
}