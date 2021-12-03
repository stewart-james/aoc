using System;
using System.Collections.Generic;
using System.Linq;
using AoC.CSharp._2021;
using Xunit;

namespace Aoc.CSharp.Tests._2021
{
    public class Day3Tests
    {
        public static readonly string TestData =
            "00100\n" +
            "11110\n" +
            "10110\n" +
            "10111\n" +
            "10101\n" +
            "01111\n" +
            "00111\n" +
            "11100\n" +
            "10000\n" +
            "11001\n" +
            "00010\n" +
            "01010\n";

        [Fact]
        public void Part2()
        {
            var d = new Day3();

            Assert.Equal("230", d.SolvePart2(TestData));
        }
    }
}