using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.CSharp._2021
{
    public class Day4 : IChallenge
    {
        public string SolvePart1(string input)
            => CalculateScores(ParseNumbers(input), ParseBoards(input))
                .First()
                .ToString();

        public string SolvePart2(string input)
            => CalculateScores(ParseNumbers(input), ParseBoards(input))
                .Last()
                .ToString();
        
        private bool HasWon(List<int> board)
        {
            for (int r = 0; r < 5; ++r)
            {
                // if the row has won
                if (board.Skip(r* 5).Take(5).All(i => i < 0))
                    return true;
            }
            
            // if any col has won
            for (int c = 0; c < 5; c++)
            {
                bool won = true;
                for (int i = 0; i < 5; ++i)
                {
                    if (board[(i * 5) + c] > 0)
                    {
                        won = false;
                        break;
                    }
                }

                if(won)
                    return true;
            }

            return false;
        }

        private List<int> CallNumber(int n, List<int> board)
        {
            for(int i = 0; i < board.Count; ++i)
                if (board[i] == n)
                    board[i] = -Math.Abs(n);

            return board;
        }

        IEnumerable<int> CalculateScores(List<int> calledNumbers, List<List<int>> boards) =>
            calledNumbers.Select(n => boards
                    .Where(b => !HasWon(b))
                    .Select(b => CallNumber(n, b))
                    .Where(b => HasWon(b))
                    .Select(b => b.Where(cell => cell > 0).Sum() * n))
                .SelectMany(_ => _);

        
        private static List<int> ParseNumbers(string input) =>
                input.Substring(0, input.IndexOf('\n')).Split(",")
                    .Select(int.Parse)
                    .ToList();
        
        private static List<List<int>> ParseBoards(string input)
        {
            return input.Substring(input.IndexOf('\n'))
                .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s
                    .Replace("\n", " ")
                    .Replace("  ", " ")
                    .Trim()
                    .Split(" ")
                    .Select(int.Parse))
                .Select(e => e.ToList()).ToList();
        }
    }
}