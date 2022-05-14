using AoC.CSharp._2015;
using Xunit;

namespace Aoc.CSharp.Tests._2015
{
    public class Day5Tests
    {
        [Theory]
        [InlineData("ugknbfddgicrmopn", "1")]
        [InlineData("aaa", "1")]
        [InlineData("jchzalrnumimnmhp", "0")]
        [InlineData("haegwjzuvuyypxyu", "0")]
        [InlineData("dvszwmarrgswjxmb", "0")]
        public void SolvePart1(string input, string expected)
            => Assert.Equal(expected, new Day5().SolvePart1(input));
        
        [Theory]
        [InlineData("qjhvhtzxzqqjkmpb", "1")]
        [InlineData("xxyxx", "1")]
        [InlineData("uurcxstgmygtbstg", "0")]
        [InlineData("ieodomkazucvgmuy", "0")]
        public void SolvePart2(string input, string expected)
            => Assert.Equal(expected, new Day5().SolvePart2(input));
    }
}