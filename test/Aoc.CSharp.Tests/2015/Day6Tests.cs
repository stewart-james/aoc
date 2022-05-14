using System.Reflection;
using AoC.CSharp._2015;
using Xunit;

namespace Aoc.CSharp.Tests._2015
{
    public class Day6Tests
    {
        [Theory]
        [InlineData("turn on 0,0 through 999,999", Day6.Action.TurnOn, 0,0, 999,999)]
        public void Parse(string s, Day6.Action action, int startX, int startY, int endX, int endY)
            => Assert.Equal((action, (startX, startY), (endX, endY)), Day6.Parse(s));

        [Theory]
        [InlineData("turn on 0,0 through 999,999", 1000 * 1000)]
        public void SolveDay1(string s, int expected)
            => Assert.Equal(expected.ToString(), new Day6().SolvePart1(s));
    }
}