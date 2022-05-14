using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace AoC.CSharp._2015
{
    public class Day6 : IChallenge
    {
        public enum Action
        {
            TurnOn,
            TurnOff,
            Toggle
        }

        private static Action ParseAction(string s) =>
            s switch
            {
                "on" => Action.TurnOn,
                "off" => Action.TurnOff,
                "toggle" => Action.Toggle,
                _ => throw new InvalidDataException($"Unsupported action {s}")
            };
        private static (int, int) ParseCoordinate(string s) => ParseCoordinates(s.Split(','));
        private static (int, int) ParseCoordinates(string[] s) => (int.Parse(s[0]), int.Parse(s[1]));

        private static (Action, (int, int), (int, int)) Parse(string[] segments)
            => Parse(segments, segments.Length == 5 ? 1 : 0);
        private static (Action, (int,int), (int,int)) Parse(string[] segments, int offset)
                => (
                        ParseAction(segments[0 + offset]), 
                        ParseCoordinate(segments[1 + offset]), 
                        ParseCoordinate(segments[3 + offset])
                    );
        public static (Action, (int, int), (int, int)) Parse(string s)
            => Parse(s.Split(' '));

        private static Dictionary<(int, int), bool> MakePart1Seed()
            => Enumerable.Range(0, 1000)
                .SelectMany(x => 
                    Enumerable.Range(0, 1000)
                        .Select(y => new { key = (x,y), value = false}))
                .ToDictionary(x => x.key, x => x.value);

        public string SolvePart1(string input)
            => input.Split('\n')
                .Aggregate(MakePart1Seed(), (acc, s) =>
                {
                    var act = Parse(s);

                    for (int x = act.Item2.Item1; x <= act.Item3.Item1; ++x)
                    {
                        for (int y = act.Item2.Item2; y <= act.Item3.Item2; ++y)
                        {
                            switch (act.Item1)
                            {
                                case Action.TurnOn:
                                    acc[(x, y)] = true;
                                    break;
                                case Action.TurnOff:
                                    acc[(x, y)] = false;
                                    break;
                                case Action.Toggle:
                                    acc[(x, y)] = !acc[(x,y)];
                                    break;
                            }
                        }
                    }
                    
                    return acc;
                })
                .Count(k => k.Value)
                .ToString();

        private static Dictionary<(int, int), int> MakePart2Seed()
            => Enumerable.Range(0, 1000)
                .SelectMany(x => 
                    Enumerable.Range(0, 1000)
                        .Select(y => new { key = (x,y), value = 0}))
                .ToDictionary(x => x.key, x => x.value);
        
        public string SolvePart2(string input)
            => input.Split('\n')
            .Aggregate(MakePart2Seed(), (acc, s) =>
            {
                var act = Parse(s);

                for (int x = act.Item2.Item1; x <= act.Item3.Item1; ++x)
                {
                    for (int y = act.Item2.Item2; y <= act.Item3.Item2; ++y)
                    {
                        switch (act.Item1)
                        {
                            case Action.TurnOn:
                                acc[(x, y)] += 1;
                                break;
                            case Action.TurnOff:
                                acc[(x, y)] = Math.Max(acc[(x, y)] - 1, 0);
                                break;
                            case Action.Toggle:
                                acc[(x, y)] += 2;
                                break;
                        }
                    }
                }
                        
                return acc;
            })
            .Sum(k => k.Value)
            .ToString();
    }
}