using SpielGuardCore;
using System;
using System.Linq;

namespace SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // You are tasked with querying a database to retrieve and manipulate instrument and instrument field data from an SQL database.

            // Tasks:
            // 1. Retrieve all instruments from the `Instrument` table that have a non-null `Maturity` value.
            // 2. Sort these instruments by their `Maturity` field in ascending order.
            // 3. Retrieve records from the `InstrumentField` table where the `recordDate` is equal to yesterday's date.
            // 4. Retrieve instruments and their corresponding instrument fields for records where `FieldId = 1` and `recordDate = yesterday's date`.


            using (ArbitrageDataContext context = new ArbitrageDataContext())
            {
                
                
            }
        }
    }
}
