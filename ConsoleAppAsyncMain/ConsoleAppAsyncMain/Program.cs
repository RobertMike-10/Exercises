using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleAppAsyncMain
{
    internal class Program
    {
        private static string url = "http://google.com/robots.txt";

        static async Task Main(string[] args)
        {
            Console.WriteLine(await new HttpClient().GetStringAsync(url));
        }
    }
}
