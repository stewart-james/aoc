using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace AoC.CSharp._2020
{
    public class Day2 : IChallenge
    {
        private readonly struct Data
        {
            public int Minimum { get; }
            public int Maximum { get; }
            public char Character { get; }
            public string Password { get; }

            public Data(int min, int max, char ch, string pw)
            {
                Minimum = min;
                Maximum = max;
                Character = ch;
                Password = pw;
            }

            public bool IsValidPassword()
            {
                var ch = Character;
                var count = Password.Count(c => c == ch);

                return count >= Minimum && count <= Maximum;
            }

            public bool IsValidPassword2()
            {
                var ch = Character;
                if (Password.Length <= Minimum - 1)
                    return false;

                int count = 0;
                if (Password[Minimum - 1] == ch)
                    count++;

                if (Password.Length <= Maximum - 1)
                    return count == 1;
                
                if (Password[Maximum - 1] == ch)
                    count++;

                return count == 1;
            }

            public static Data Parse(string s)
            {
                try
                {
                    int min = int.Parse(s.Substring(0, s.IndexOf('-')));

                    int max = int.Parse(s.Substring(s.IndexOf('-') + 1, s.IndexOf(' ') - (s.IndexOf('-') + 1)));
                    char ch = char.Parse(s.Substring(s.IndexOf(' ') + 1, 1));
                    string pass = s.Substring(s.LastIndexOf(' ') + 1);

                    return new Data(min, max, ch, pass);

                }
                catch (Exception e)
                {
                    Console.WriteLine(s);
                    Console.WriteLine(s.Substring(0, s.IndexOf('-')));
                    Console.WriteLine(s.Substring(s.IndexOf('-') + 1, s.Length - s.IndexOf(' ')));
                    Console.WriteLine(s.Substring(s.IndexOf(' '), 1));
                    Console.WriteLine(s.Substring(s.LastIndexOf(' ') + 1));
                    throw;
                }
            }
        }


        public string SolvePart1(string input)
            => Helper.FilterEmptyOrNull(Helper.SplitByNewLine(input))
                .Select(Data.Parse)
                .Count(d => d.IsValidPassword())
                .ToString();
        
        public string SolvePart2(string input) 
            => Helper.FilterEmptyOrNull(Helper.SplitByNewLine(input))
                .Select(Data.Parse)
                .Count(d => d.IsValidPassword2())
                .ToString();
    }
}