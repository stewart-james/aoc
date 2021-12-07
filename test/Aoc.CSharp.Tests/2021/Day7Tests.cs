using AoC.CSharp._2021;
using Xunit;

namespace Aoc.CSharp.Tests._2021
{
    public class Day7Tests
    {
        [Theory]
        [InlineData("16,1,2,0,4,2,7,1,2,14", "37")]
        public void SolvePart1(string input, string expected)
        {
            var day = new Day7();
            
            Assert.Equal(expected, day.SolvePart1(input));
        }

        [Theory]
        [InlineData("16,1,2,0,4,2,7,1,2,14", "168")]
        public void SolvePart2(string input, string expected)
        {
            var day = new Day7();
            
            Assert.Equal(expected, day.SolvePart2(input));
        }
    }
}