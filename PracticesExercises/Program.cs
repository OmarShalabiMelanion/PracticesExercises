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
    /// 3. Identify the stocl with the highest weekly performance.
    /// 4. Identify the most volatile stoc (highest difference between max and min price).


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



    }
}
