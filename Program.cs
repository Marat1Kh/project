using System;

namespace OpenDotaConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("OpenDota Console App");

            OpenDotaApiClient openDotaApiClient = new OpenDotaApiClient();

            Console.Write("Enter a match ID: ");
            if (long.TryParse(Console.ReadLine(), out long matchId))
            {
                string matchInfo = await openDotaApiClient.GetMatchInfoAsync(matchId);

                if (!string.IsNullOrEmpty(matchInfo))
                {
                    Console.WriteLine("Match Information:");
                    Console.WriteLine(matchInfo);
                }
                else
                {
                    Console.WriteLine("Failed to retrieve match information.");
                }
            }
            else
            {
                Console.WriteLine("Invalid match ID. Please enter a valid numeric match ID.");
            }
        }
    }
}
