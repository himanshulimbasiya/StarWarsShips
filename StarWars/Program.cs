using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace StarWars
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static  void Main(string[] args)
        {
            Console.WriteLine("Enter distance in mega lights: ");
            int userInput = Convert.ToInt32(Console.ReadLine());
            ApiCall(userInput).Wait();
            Console.ReadLine();
        }
        static private async Task ApiCall(int userInput)
        {
            var apiResult = await ApiProcessor.ApiCall();
            ResupplyCalculator resupplyCalculator = new ResupplyCalculator();
            var starShips = resupplyCalculator.Calculate(apiResult, userInput);
            Output(starShips);
        }

        static private void Output(IList<Starships> starShips)
        {
            Console.WriteLine();
            Console.WriteLine("Output: ");
            foreach (var ship in starShips)
            {
                Console.WriteLine(ship.name + ": " + ship.resupply);
                Console.WriteLine();
            }
        }
    }
}
