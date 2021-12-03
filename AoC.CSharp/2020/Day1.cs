using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.CSharp._2020
{
    public class Day1 : IChallenge
    {
        public string SolvePart1(string input)
        {
            var ints = Helper.ParseInts(Helper.SplitByNewLine(input)).ToArray();
            foreach(var i in ints)
                foreach(var n in ints)
                    if (i + n == 2020)
                        return (i * n).ToString();

            throw new InvalidDataException();
        }

        public string SolvePart2(string input)
        {
            var ints = Helper.ParseInts(Helper.SplitByNewLine(input));
            foreach(var i in ints)
                foreach(var n in ints)
                    foreach(var x in ints)
                        if (i + n + x == 2020)
                            return (i * n * x).ToString();
            
            throw new InvalidDataException();
        }
    }
}