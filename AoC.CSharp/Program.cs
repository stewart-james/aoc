using System;
using System.Linq;
using System.Threading.Tasks;

namespace AoC.CSharp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            int year = 2021;
            int day;

            do
            {
                Console.WriteLine("Enter year:");
            } while (!int.TryParse(Console.ReadLine(), out year));

            do
            {
                Console.WriteLine("Enter day:");
            } while (!int.TryParse(Console.ReadLine(), out day));
            
            var webClient = new AoCWebClient(args[0]);
            var content = await webClient.GetInput(year, day);

            var challenge = new ChallengeFactory().MakeChallenge(year, day);

            try
            {
                Console.WriteLine($"Part 1 Solution {challenge.SolvePart1(content)}");
                Console.WriteLine($"Part 2 Solution {challenge.SolvePart2(content)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}