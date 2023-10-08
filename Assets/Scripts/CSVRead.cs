using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;

public class CSVRead : MonoBehaviour
{
    static void Main()
    {
        string filePath = "nasacatalog1.csv"; // Change this to your CSV file path

        try
        {
            // Read all lines from the CSV file
            string[] lines = File.ReadAllLines(filePath);

            // Assuming the first row contains column headers, split it into an array of column names
            string[] headers = lines[0].Split(',');

            // Process the data (skip the first row since it contains headers)
            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                // Access data using column index or column name
                string column1 = data[0]; // Access the first column
                string column2 = data[1]; // Access the second column

                // You can also access data using column names if you have headers
                // string column1 = data[headers.IndexOf("ColumnName1")];
                // string column2 = data[headers.IndexOf("ColumnName2")];

                // Process the data here, e.g., print it
                Console.WriteLine($"Row {i}: Column1 = {column1}, Column2 = {column2}");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file does not exist.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

