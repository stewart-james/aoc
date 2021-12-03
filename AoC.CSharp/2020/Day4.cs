using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AoC.CSharp._2020
{
    public class Day4 : IChallenge
    {
        private interface IValidatePassportStrategy
        {
            public bool IsValid(Passport p);
        }

        class ValidatePassportStrategyPart1 : IValidatePassportStrategy
        {
            public bool IsValid(Passport p)
            {
                if (p.BirthYear is null || p.IssueYear is null || p.ExpirationYear is null || p.Height is null ||
                    p.HairColor is null || p.EyeColor is null || p.PassportId is null)
                    return false;

                return true;
            }
        }

        class ValidatePassportStrategyPart2 : IValidatePassportStrategy
        {
            public bool IsValid(Passport p)
            {
                if (!int.TryParse(p.BirthYear, out var birthYear) || birthYear < 1920 || birthYear > 2002)
                    return false;
                
                if (!int.TryParse(p.IssueYear, out var issueYear) || issueYear < 2010 || issueYear > 2020)
                    return false;
                
                if (!int.TryParse(p.ExpirationYear, out var expirationYear) || expirationYear < 2020 || expirationYear > 2030)
                    return false;

                if (p.Height is null)
                    return false;

                if (!int.TryParse(p.Height.TakeWhile(char.IsDigit).ToArray(), out int height))
                    return false;

                string heightUnit = new string(p.Height.Where(char.IsLetter).ToArray());

                switch (heightUnit)
                {
                    case "cm":
                        if (height < 150 || height > 193)
                            return false;
                        break;
                    case "in":
                        if (height < 59 || height > 76)
                            return false;
                        break;
                    default:
                        return false;
                }

                if (p.HairColor is null || 
                    p.HairColor.Length != 7 || 
                    p.HairColor[0] != '#' ||
                    p.HairColor.Skip(1).TakeWhile(c => c is >= '0' and <= '9' or >= 'a' and <= 'f').Count() != 6)
                    return false;

                var validEyeColors = new HashSet<string>
                {
                    "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
                };

                if (!validEyeColors.Contains(p.EyeColor))
                    return false;

                if (p.PassportId is null || p.PassportId.TakeWhile(char.IsDigit).Count() != 9)
                    return false;

                return true;
            }
        }
        
        private readonly struct Passport
        {
            public string BirthYear { get; }
            public string IssueYear { get; }
            public string ExpirationYear { get; }
            public string Height { get; }
            public string HairColor { get; }
            public string EyeColor { get; }
            public string PassportId { get; }
            public string CountryId { get; }

            public Passport(
                string birth, string issue, 
                string expiration, string height, 
                string hair, string eyes,
                string id, string countryId)
            {
                BirthYear = birth;
                IssueYear = issue;
                ExpirationYear = expiration;
                Height = height;
                HairColor = hair;
                EyeColor = eyes;
                PassportId = id;
                CountryId = countryId;
            }

            public bool IsValid(IValidatePassportStrategy strategy)
                => strategy.IsValid(this);

            public static Passport Parse(string s)
            {
                var dict = new Dictionary<string, string>();
                
                foreach (var d in s.Split(" ").Where(a => !string.IsNullOrWhiteSpace(a)))
                {
                    var idx = d.IndexOf(':');
                    if (idx == -1)
                        continue;
                    
                    var key = d.Substring(0, idx);
                    var val = d.Substring(idx + 1);

                    dict[key] = val;
                }

                return new Passport(
                    dict.GetValueOrDefault("byr"),
                    dict.GetValueOrDefault("iyr"),
                    dict.GetValueOrDefault("eyr"),
                    dict.GetValueOrDefault("hgt"),
                    dict.GetValueOrDefault("hcl"),
                    dict.GetValueOrDefault("ecl"),
                    dict.GetValueOrDefault("pid"),
                    dict.GetValueOrDefault("cid"));
            }
        }

        public string SolvePart1(string input)
            => ParsePassports(input).Count(p => p.IsValid(new ValidatePassportStrategyPart1())).ToString();

        public string SolvePart2(string input)
            => ParsePassports(input).Count(p => p.IsValid(new ValidatePassportStrategyPart2())).ToString();
        
        private IEnumerable<Passport> ParsePassports(string input) =>
            input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Replace("\n", " ")).Select(Passport.Parse).ToList();
    }
}