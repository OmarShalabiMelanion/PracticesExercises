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
using CsvHelper.TypeConversion;
using System.Windows.Forms;

class Program
{
    public static readonly string MBCEXIPricesFilePath = @"C:\Users\User\Downloads\IVH_MBCEXI.csv";

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



        Dictionary<DateTime, double> data = new Dictionary<DateTime, double>();

        using (var reader = new StreamReader(MBCEXIPricesFilePath)) //read
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) //parse
        {
            HasHeaderRecord = true //remove header row
        }))

        {
            csv.Read(); // Skip header row
            // csv.ReadHeader(); Optional: If you need header names

            while (csv.Read())
            {

                DateTime.TryParse(csv.GetField<string>(0), out DateTime date);
                double.TryParse(csv.GetField<string>(2), out double price);

                data[date] = price;
            }
            //Optional: try catch in case of bad/invalid data
        }

        /* print values in dictionary
        foreach (var entry in data)
        {
            Console.WriteLine($"{entry.Key:MM-dd-yyyy} -> {entry.Value}");
        }
        */


        Chart chart = new Chart();

        chart.Width = 1200;  // Set the width of the chart image
        chart.Height = 800;  // Set the height of the chart image

        Series series = new Series("MBCEXI Price"); //set of data points
        series.ChartType = SeriesChartType.Line; //line chart
        series.Color = Color.Red;

        var sortedData = data.OrderBy(kvp => kvp.Key); //Order by date

        foreach (var entry in sortedData)
        {
            series.Points.AddXY(entry.Key, entry.Value);
        }

        chart.Series.Add(series); //add series to chart
        
        chart.ChartAreas.Add(new ChartArea("MainArea")); 
        chart.ChartAreas["MainArea"].AxisX.Title = "Date";
        chart.ChartAreas["MainArea"].AxisY.Title = "Price";
        chart.ChartAreas["MainArea"].AxisX.LabelStyle.Format = "MM-dd-yyyy"; 
        chart.ChartAreas["MainArea"].AxisX.IntervalType = DateTimeIntervalType.Auto; 
        chart.ChartAreas["MainArea"].AxisX.Interval = 0; //Interval=0: to get best interval automatically calculated

        chart.ChartAreas["MainArea"].AxisX.MajorGrid.LineColor = Color.LightGray; 
        chart.ChartAreas["MainArea"].AxisX.MinorGrid.LineColor = Color.LightBlue;  
        chart.ChartAreas["MainArea"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.IncreaseFont | LabelAutoFitStyles.WordWrap;
        //chart.ChartAreas["MainArea"].AxisX.LabelStyle.Angle = 45;

        chart.Titles.Add("MBCEXI Price Chart");

        string chartFilePath = @"C:\Users\User\Downloads\MBCEXI_Chart.png"; 
        chart.SaveImage(chartFilePath, ChartImageFormat.Png);

    }

}
