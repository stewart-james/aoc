using System;
using System.Linq;

namespace AoC.CSharp._2015
{
    public class Day1 : IChallenge
    {
        // Santa is lost on the ground floor at of a block of flats
        // starts at ground floor (floor 0)
        // ( = go up 1 floor
        // ) = go down 1 floor
        private const char Up = '(';

        // Find out which floor he ends up on, given the Up / Down instructions
        // O(N)
        public string SolvePart1(string input)
           => CalculateFloor(CountUps(input), input.Length).ToString();

        // Find the first instruction that causes him to be in the basement (idx of input)
        // O(N)
        public string SolvePart2(string input)
            => (Enumerable
                    .Range(0, input.Length)
                    .Aggregate((currentFloor: 0, idx: -1), 
                        (agg, index) => agg.currentFloor == -1 ? 
                            agg : 
                            (agg.currentFloor + (input[index] == Up ? 1 : -1), index))
                    .idx + 1)
                .ToString();

        // O(N^2)
        //public string SolvePart2(string input)
        //    => Enumerable
        //        .Range(0, input.Length)
        //        .First(index => CalculateFloor(CountUps(input.Substring(0, index)), index) == -1)
        //        .ToString();
        
        private static int CountUps(string input) => input.Count(c => c == Up);
        private static int CalculateFloor(int upCount, int len) => upCount - (len - upCount);
    }
}