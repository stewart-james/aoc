using System;
using System.Linq;

namespace AoC.CSharp
{
    public class ChallengeFactory
    {
        public IChallenge MakeChallenge(int year, int day)
        {
            var ns = $"_{year}";
            var cl = $"Day{day}";

            var type = typeof(ChallengeFactory)
                .Assembly
                .GetTypes()
                .FirstOrDefault(type => 
                    typeof(IChallenge).IsAssignableFrom(type) && 
                    type.Namespace != null && type.Namespace.Contains(ns) 
                    && type.Name == cl);

            if (type is null)
                throw new NotSupportedException($"Could not find type for challenge {year}/{day}");

            return (IChallenge)Activator.CreateInstance(type);
        }
    }
}