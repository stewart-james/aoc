using AoC.CSharp._2015;
using Xunit;

namespace Aoc.CSharp.Tests._2015
{
    public class Day4Tests
    {
        [Theory]
        [InlineData("abcdef", "609043")]
        [InlineData("pqrstuv", "1048970")]
        public void Part1(string input, string expected) =>
            Assert.Equal(expected, new Day4().SolvePart1(input));
    }
}