using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AoC.CSharp
{
    public class AoCWebClient
    {
        private readonly Uri _baseAddress;
        private readonly string _sessionCookie;
        
        public AoCWebClient(string sessionCookie)
        {
            _baseAddress = new Uri("https://adventofcode.com");
            _sessionCookie = sessionCookie;
        }

        public async Task<string> GetInput(int year, int day)
        {
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            {
                using (var client = new HttpClient(handler) { BaseAddress = _baseAddress})
                {
                    cookieContainer.Add(_baseAddress, new Cookie("session", _sessionCookie));
                    
                    var request = new HttpRequestMessage(HttpMethod.Get, $"https://adventofcode.com/{year}/day/{day}/input");
                    var response = await client.SendAsync(request);

                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}