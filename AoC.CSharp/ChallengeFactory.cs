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
                // 2015
                (2015, 01) => new _2015.Day1(),
                (2015, 02) => new _2015.Day2(),
                (2015, 03) => new _2015.Day3(),
                (2015, 04) => new _2015.Day4(),
                (2015, 05) => new _2015.Day5(),
                
                // 2020
                (2020, 01) => new _2020.Day1(),
                (2020, 02) => new _2020.Day2(),
                (2020, 03) => new _2020.Day3(),
                (2020, 04) => new _2020.Day4(),
                (2020, 05) => new _2020.Day5(),
                (2020, 06) => new _2020.Day6(),
                
                // 2021
                (2021, 01) => new _2021.Day1(),
                (2021, 02) => new _2021.Day2(),
                (2021, 03) => new _2021.Day3(),
                (2021, 04) => new _2021.Day4(),
                (2021, 05) => new _2021.Day5(),
                (2021, 06) => new _2021.Day6(),
                (2021, 07) => new _2021.Day7(),
                
                _ => throw new ArgumentOutOfRangeException()
            };

    }
}