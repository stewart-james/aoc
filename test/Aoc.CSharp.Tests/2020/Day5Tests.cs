using System;
using AoC.CSharp._2020;
using Xunit;

namespace Aoc.CSharp.Tests._2020
{
    public class Day5Tests
    {
        [Theory]
        [InlineData(0, 127, 0, 63)]
        [InlineData(32, 63, 32, 47)]
        public void RangeTakeLowerHalf(int beginFrom, int beginTo, int expectFrom, int expectTo)
        {
            var range = new Day5.Range(beginFrom, beginTo);

            var halvedRange = range.TakeLowerHalf();
            
            Assert.Equal(expectFrom, halvedRange.From);
            Assert.Equal(expectTo, halvedRange.To);
        }

        [Theory]
        [InlineData(0, 127, 64, 127)]
        [InlineData(0, 63, 32, 63)]
        [InlineData(32, 47, 40, 47)]
        public void RangeTakeUpperHalf(int beginFrom, int beginTo, int expectFrom, int expectTo)
        {
            var range = new Day5.Range(beginFrom, beginTo);

            var halvedRange = range.TakeUpperHalf();

            Assert.Equal(expectFrom, halvedRange.From);
            Assert.Equal(expectTo, halvedRange.To);
        }
        
        [Theory]
        [InlineData("FBFBBFFRLR", 357)]
        [InlineData("BFFFBBFRRR", 567)]
        [InlineData("FFFBBBFRRR", 119)]
        [InlineData("BBFFBBFRLL", 820)]
        public void CalculateSeatId(string input, int expected)
        {
            var day4 = new Day5();

            Assert.Equal(expected, day4.CalculateSeatId(input));
        }

        [Fact]
        public void SolveDay1()
        {
            var input = "FBFBBFFRLR\nBFFFBBFRRR\nFFFBBBFRRR\nBBFFBBFRLL";
            var day = new Day5();

            Assert.Equal("820", day.SolvePart1(input));
        }
        
    }
}