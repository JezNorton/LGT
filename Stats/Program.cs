using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StatsEngine;

namespace Stats
{
    class Program
    {
        private static int FailedAttempts = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter a comma delimited list of integers");
                    var input = Console.ReadLine();
                    Console.WriteLine($"Input {input}");
                    var statsEngine = new StatsManager(input);
                    Console.WriteLine($"Max value is: {statsEngine.Max()}");
                    Console.WriteLine($"Min value is {statsEngine.Min()}");
                    Console.WriteLine($"Average is: {statsEngine.Avg()}");
                    Console.WriteLine($"Standard Deviation: {statsEngine.StandardDeviation()}");
                    Console.WriteLine("Q to quit, any key to go again");
                    var response = Console.ReadKey();
                    if (response.Key == ConsoleKey.Q) break;

                }
                catch (Exception ex)
                {
                    if (ex.Message != "Invalid input") throw;
                    FailedAttempts++;
                    if (FailedAttempts < 3)
                    {
                        Console.WriteLine("Invalid input, please try again");
                    }
                    else
                    {
                        Console.WriteLine("Three failed attempts.. press any key to exit");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }
    }
}
