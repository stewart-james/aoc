using AoC.CSharp._2020;
using Xunit;

namespace Aoc.CSharp.Tests._2020
{
    public class Day6Tests
    {
        [Fact]
        public void SolvePart1()
        {
            string input = 
                "abc\n" +
                "\n" +
                
                "a\n" + 
                "b\n" + 
                "c\n" +
                "\n" +
                
                "ab\n" + 
                "ac\n" +
                "\n" +
                
                "a\n" +
                "a\n" +
                "a\n" +
                "a\n" +
                "\n" +
                
                "b\n";

            var day = new Day6();
            Assert.Equal("11", day.SolvePart1(input));
        }

        [Fact]
        public void SolvePart2()
        {
            string input = 
                "abc\n" +
                "\n" +
                
                "a\n" + 
                "b\n" + 
                "c\n" +
                "\n" +
                
                "ab\n" + 
                "ac\n" +
                "\n" +
                
                "a\n" +
                "a\n" +
                "a\n" +
                "a\n" +
                "\n" +
                
                "b\n";

            var day = new Day6();
            Assert.Equal("6", day.SolvePart2(input));
        }
    }
}