using System;
using System.Linq;
using System.Security.Cryptography;

namespace AoC.CSharp._2015
{
    public class Day4 : IChallenge
    {
        public string SolvePart1(string input)
            => FindMatch(input.TrimEnd('\n'), 5);

        public string SolvePart2(string input)
            => FindMatch(input.TrimEnd('\n'), 6);
        
        private string FindMatch(string input, int count) =>
            Enumerable.Range(0, Int32.MaxValue)
                .First(i => IsMatch(Hash(input + i), count))
                .ToString();

        private bool IsMatch(string result, int count)
            => result.Take(count).All(c => c == '0');
        private static string Hash(string content)
        {
            // Use input string to calculate MD5 hash
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(content);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +
            }
        }
    }
}