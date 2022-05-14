using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC.CSharp._2015
{
    public class Day5 : IChallenge
    {
        private readonly Func<string, bool> _mustNotContain = s => !Regex.IsMatch(s, "(ab|cd|pq|xy)");
        private readonly Func<string, bool> _mustContain3Vowels = s => s.Count("aeiou".Contains) >= 3;
        private readonly Func<string, bool> _mustContainPairOfIdenticalLetters = s => Regex.IsMatch(s, @"([a-z])\1");
        
        public string SolvePart1(string input) =>
            input
                .TrimEnd('\n')
                .Split('\n')
                .Count(s => _mustNotContain(s) && _mustContain3Vowels(s) && _mustContainPairOfIdenticalLetters(s))
                .ToString();

        private readonly Func<string, bool> _containsPairThatAppearsTwiceWithoutOverlapping = s => Regex.IsMatch(s, @"([a-z][a-z]).*\1");
        private readonly Func<string, bool> _containsRepeatWithOneCharBetween = s => Regex.IsMatch(s, @"([a-z])[a-z]\1");

        public string SolvePart2(string input)
            => input
                .TrimEnd('\n')
                .Split('\n')
                .Count(s => _containsRepeatWithOneCharBetween(s) && 
                            _containsPairThatAppearsTwiceWithoutOverlapping(s))
                .ToString();
    }
}