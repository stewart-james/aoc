using System.Collections.Generic;
using System.Linq;

namespace AoC.CSharp
{
    public static class Helper
    {
        public static List<string> SplitByNewLine(string s)
            => s.Split("\n").ToList();
        public static IEnumerable<string> FilterEmptyOrNull(IEnumerable<string> s)
            => s.Where(s => !string.IsNullOrEmpty(s));
        
        public static IEnumerable<int> ParseInts(IEnumerable<string> s)
            => FilterEmptyOrNull(s).Select(int.Parse);

    }
}