using System;
using System.Collections.Generic;
using System.Linq;

class Stock
{
    public string Symbol { get; set; }
    public DateTime Date { get; set; }
    public double ClosePrice { get; set; }
}

class Program
{
    // You are given a list of futures contracts with their daily closing prices over a week.
    // Your task is to analyze this data using LINQ to extract key insights.

    /// Tasks:
    /// 1. Find the minimum, maximum, and average closing price for each stock over the week.
    /// 2. Calculate the overall weekly performance (%) for each contract using the formula:
    ///    Performance (%) = ((Last Closing Price - First Closing Price) / First Closing Price) * 100
    /// 3. Identify the stock with the highest weekly performance.
    /// 4. Identify the most volatile stock (highest difference between max and min price).


    static void Main()
    {
        List<Stock> stocks = new List<Stock>
        {
            // ES Futures (S&P 500)
            new Stock { Symbol = "ES", Date = new DateTime(2024, 2, 1), ClosePrice = 4500 },
            new Stock { Symbol = "ES", Date = new DateTime(2024, 2, 2), ClosePrice = 4520 },
            new Stock { Symbol = "ES", Date = new DateTime(2024, 2, 3), ClosePrice = 4480 },
            new Stock { Symbol = "ES", Date = new DateTime(2024, 2, 4), ClosePrice = 4550 },
            new Stock { Symbol = "ES", Date = new DateTime(2024, 2, 5), ClosePrice = 4575 },

            // NQ Futures (Nasdaq-100)
            new Stock { Symbol = "NQ", Date = new DateTime(2024, 2, 1), ClosePrice = 15500 },
            new Stock { Symbol = "NQ", Date = new DateTime(2024, 2, 2), ClosePrice = 15620 },
            new Stock { Symbol = "NQ", Date = new DateTime(2024, 2, 3), ClosePrice = 15480 },
            new Stock { Symbol = "NQ", Date = new DateTime(2024, 2, 4), ClosePrice = 15700 },
            new Stock { Symbol = "NQ", Date = new DateTime(2024, 2, 5), ClosePrice = 15850 },

            // YM Futures (Dow Jones)
            new Stock { Symbol = "YM", Date = new DateTime(2024, 2, 1), ClosePrice = 35000 },
            new Stock { Symbol = "YM", Date = new DateTime(2024, 2, 2), ClosePrice = 35150 },
            new Stock { Symbol = "YM", Date = new DateTime(2024, 2, 3), ClosePrice = 34800 },
            new Stock { Symbol = "YM", Date = new DateTime(2024, 2, 4), ClosePrice = 35200 },
            new Stock { Symbol = "YM", Date = new DateTime(2024, 2, 5), ClosePrice = 35350 },

            // RTY Futures (Russell 2000)
            new Stock { Symbol = "RTY", Date = new DateTime(2024, 2, 1), ClosePrice = 2000 },
            new Stock { Symbol = "RTY", Date = new DateTime(2024, 2, 2), ClosePrice = 2025 },
            new Stock { Symbol = "RTY", Date = new DateTime(2024, 2, 3), ClosePrice = 1990 },
            new Stock { Symbol = "RTY", Date = new DateTime(2024, 2, 4), ClosePrice = 2030 },
            new Stock { Symbol = "RTY", Date = new DateTime(2024, 2, 5), ClosePrice = 2045 },

            // CL Futures (Crude Oil)
            new Stock { Symbol = "CL", Date = new DateTime(2024, 2, 1), ClosePrice = 75.00 },
            new Stock { Symbol = "CL", Date = new DateTime(2024, 2, 2), ClosePrice = 76.20 },
            new Stock { Symbol = "CL", Date = new DateTime(2024, 2, 3), ClosePrice = 74.80 },
            new Stock { Symbol = "CL", Date = new DateTime(2024, 2, 4), ClosePrice = 77.00 },
            new Stock { Symbol = "CL", Date = new DateTime(2024, 2, 5), ClosePrice = 78.50 }
        };

        /// 1. Find the minimum, maximum, and average closing price for each stock over the week.
        /// 2. Calculate the overall weekly performance (%) for each contract using the formula:
        ///    Performance (%) = ((Last Closing Price - First Closing Price) / First Closing Price) * 100


        //using LINQ
        var stockStats = stocks
            .GroupBy(i => i.Symbol)
            .Select(g => new
            {
                Symbol = g.Key,
                Min = g.Min(s => s.ClosePrice),
                Max = g.Max(s => s.ClosePrice),
                Avg = g.Average(s => s.ClosePrice),
                Performance = ((g.OrderBy(s => s.Date).Last().ClosePrice - g.OrderBy(s => s.Date).First().ClosePrice)
                        / g.OrderBy(s => s.Date).First().ClosePrice) * 100
                Volatility = g.Max(s => s.ClosePrice) - g.Min(s => s.ClosePrice)
            }); //objects for each group



        foreach (var stat in stockStats)
        {
            Console.WriteLine($"Symbol: {stat.Symbol}, Min: {stat.Min}, Max: {stat.Max}, Avg: {stat.Avg}, Performance: {stat.Performance}");
        }

        /// 3. Identify the stock with the highest weekly performance.
        /// 4. Identify the most volatile stock (highest difference between max and min price).
        






        Console.WriteLine("Using Dictionaries: ");


        //using Dictionaries (1+2)
        Dictionary<string, List<Stock>> stockGroups = new Dictionary<string, List<Stock>>();

        foreach (var stock in stocks)
        {
            if (!stockGroups.ContainsKey(stock.Symbol))
            {
                stockGroups[stock.Symbol] = new List<Stock>();
            }
            stockGroups[stock.Symbol].Add(stock);
        }

        foreach (var entry in stockGroups)
        {
            string symbol = entry.Key;
            List<Stock> stockList = entry.Value;

            double minPrice = double.MaxValue;
            double maxPrice = double.MinValue;
            double sum = 0;
            int count = 0;

            double lastCP = 0;
            double firstCP = 0;

            foreach (var stock in stockList)
            {
                if (stock.ClosePrice < minPrice) minPrice = stock.ClosePrice;
                if (stock.ClosePrice > maxPrice) maxPrice = stock.ClosePrice;

                if (firstCP == 0)
                {
                    firstCP = stock.ClosePrice;
                }
                lastCP = stock.ClosePrice;

                sum += stock.ClosePrice;
                count++;
            }
            double avgPrice = sum / count;
            double performance = ((lastCP - firstCP) / firstCP) * 100;

            Console.WriteLine($"Symbol: {symbol}, Min: {minPrice}, Max: {maxPrice}, Avg: {avgPrice}, Performance: {performance}");
        }
    }
}
