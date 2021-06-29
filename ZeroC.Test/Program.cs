using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ZeroC.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var c = new ZeroChanClient();
            var t = await c.GetSuggestionResultsAsync("Hatsune");
            var tp = await c.GetTagPageAsync("Hatsune Miku");
        }
    }
}
