using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace AoC.CSharp
{
    public class ChallengeFactory
    {
        public IChallenge MakeChallenge(int year, int day)
            => (year, day) switch
            {
                // 2020
                (2020, 01) => new _2020.Day1(),
                (2020, 02) => new _2020.Day2(),
                (2020, 03) => new _2020.Day3(),
                (2020, 04) => new _2020.Day4(),
                (2020, 05) => new _2020.Day5(),
                
                // 2021
                (2021, 01) => new _2021.Day1(),
                (2021, 02) => new _2021.Day2(),
                (2021, 03) => new _2021.Day3(),
                
                _ => throw new ArgumentOutOfRangeException()
            };

    }
}