﻿using ArbitrageDB.DB;
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

                // 1
               var instrumentsWithMaturity = context.Instrument
                    .Where(i => i.Maturity != null)
                    .ToList();

                // 2
                var instrumentsSorted = context.Instrument
                    .Where(i => i.Maturity != null && i.Maturity != DateTime.MinValue)
                    .OrderBy(i => i.Maturity)
                    .ToList();

                Console.WriteLine("Maturity NOT NULL and Sorted: ");
                Console.WriteLine();
                foreach (var instrument in instrumentsSorted)
                {
                    Console.WriteLine($"Instrument ID: {instrument.Id}, Maturity: {instrument.Maturity}");
                }
                Console.WriteLine();
                Console.WriteLine();

                // 3
                DateTime PreviouWorkday = DateTime.Now.AddDays(-3).Date;

                var instrumentsYesterday = context.InstrumentField
                    .Where(i => i.recordDate == PreviouWorkday)
                    .ToList();

                Console.WriteLine("Previous Workday: ");
                Console.WriteLine();
                foreach (var field in instrumentsYesterday)
                {
                    Console.WriteLine($"InstrumentField ID: {field.instrumentId}, Record Date: {field.recordDate}");
                }
                Console.WriteLine();
                Console.WriteLine();

                // 4
                var instrumentsField1 = context.Instrument.Join(
                    context.InstrumentField,
                    I => I.Id,
                    IF => IF.instrumentId,
                    (I, IF) => new { I, IF })
                    .Where(x => x.IF.recordDate == PreviouWorkday && x.IF.fieldId == 1 && x.I.Maturity != null)
                    .ToList();

                Console.WriteLine("FieldID = 1, Maturity NOT NULL (Joined): ");
                Console.WriteLine();
                foreach (var item in instrumentsField1)
                {
                    Console.WriteLine($"Instrument ID: {item.I.Id}, Field ID: {item.IF.fieldId}, Record Date: {item.IF.recordDate}");
                }

            }
        }
    }
}
