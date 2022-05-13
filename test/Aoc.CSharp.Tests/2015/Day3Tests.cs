using AoC.CSharp._2015;
using Xunit;

namespace Aoc.CSharp.Tests._2015
{
    public class Day3Tests
    {
        [Theory]
        [InlineData(">", "2")]
        [InlineData("^>v<", "4")]
        [InlineData("^v^v^v^v^v", "2")]
        public void Part1(string input, string expected)
            => Assert.Equal(expected, new Day3().SolvePart1(input));
        
        [Theory]
        [InlineData("^v", "3")]
        [InlineData("^>v<", "3")]
        [InlineData("^v^v^v^v^v", "11")]
        public void Part2(string input, string expected)
            => Assert.Equal(expected, new Day3().SolvePart2(input));
    }
}