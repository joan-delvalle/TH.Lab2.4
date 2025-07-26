using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Lab2._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
         List<decimal> prices = new List<decimal>();

                Console.WriteLine("=== Stock Price Tracker ===");
                Console.WriteLine("Enter stock prices for 7 consecutive days:");

                for (int i = 0; i < 7; i++)
                {
                    Console.Write($"Day {i + 1} price: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal price) && price > 0)
                    {
                        prices.Add(price);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number.");
                        i--; 
                    }
                }

                decimal highestGain = 0;
                int highestGainDay = 0; 
                List<decimal> percentGains = new List<decimal>();

                percentGains.Add(0); 

                for (int i = 1; i < prices.Count; i++)
                {
                    decimal previous = prices[i - 1];
                    decimal current = prices[i];
                    decimal gain = ((current - previous) / previous) * 100;
                    percentGains.Add(gain);

                    if (gain > highestGain)
                    {
                        highestGain = gain;
                        highestGainDay = i; 
                    }
                }

                Console.WriteLine("\n=== Percentage Gains ===");
                Console.WriteLine("+--------+----------------+");
                Console.WriteLine("|  Day   | % Gain vs Prev |");
                Console.WriteLine("+--------+----------------+");

                for (int i = 0; i < 7; i++)
                {
                    Console.WriteLine($"| Day {i + 1,-3} | {percentGains[i],13:F2}% |");
                }

                Console.WriteLine("+--------+----------------+");
                Console.WriteLine($"\nDay with highest gain: Day {highestGainDay + 1}");
                Console.WriteLine($"Highest gain: {highestGain:F2}%");
            
        }
    }

}

