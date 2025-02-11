using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;
using System.Formats.Asn1;

class Program
{
    public static readonly string MBCEXIPricesFilePath = @"G:\Shared drives\Melanion\SourceFiles\13.BITA\IVH_MBCEXI.csv";

    // You are given a file of MBCEXI Index prices.
    // Your task is to read this file and retrieve the prices (value) field and create a line chart that represents the change in price
    // from start date to end date.

    /// Tasks:
    /// 1. Read the file using CsvHelper package.
    /// 2. Access the correct fields (date and value) and store them in a suitable data structure (List of Tuples or Dictionary).
    /// 3. Create a line chart that takes this data and adjust it for better visibility and save it .

    static void Main()
    {
        //// Step 1: Read the file using CsvHelper package
        //var records = ReadCsvFile(MBCEXIPricesFilePath);

        //// Step 2: Prepare data for charting
        //var data = ProcessCsvData(records);

        //// Step 3: Create the line chart
        //CreateLineChart(data);
    }

    
}
