using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Read JSON data from file
        string jsonFilePath = "test_results.json";
        string jsonData = File.ReadAllText(jsonFilePath);

        // Deserialize JSON into C# objects
        TestResultCollection testResults = JsonConvert.DeserializeObject<TestResultCollection>(jsonData);

        // Export test results to CSV
        string csvFilePath = "test_results.csv";
        ExportToCSV(testResults, csvFilePath);

        // Calculate and display metrics
        DisplayMetrics(testResults);
    }

    static void ExportToCSV(TestResultCollection testResults, string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            // Write CSV header
            sw.WriteLine("Test Case,Status,Execution Time,Timestamp");

            // Write test results to CSV
            foreach (TestResult result in testResults.Results)
            {
                sw.WriteLine($"{result.TestCase},{result.Status},{result.ExecutionTime},{result.Timestamp}");
            }
        }
    }

    static void DisplayMetrics(TestResultCollection testResults)
    {
        Console.WriteLine("Metrics:");
        Console.WriteLine($"Total number of test cases executed: {testResults.Results.Count}");
        Console.WriteLine($"Number of test cases passed: {testResults.Results.Count(r => r.Status == "pass")}");
        Console.WriteLine($"Number of test cases failed: {testResults.Results.Count(r => r.Status == "fail")}");

        if (testResults.Results.Any())
        {
            double averageExecutionTime = testResults.Results.Average(r => r.ExecutionTime);
            double minExecutionTime = testResults.Results.Min(r => r.ExecutionTime);
            double maxExecutionTime = testResults.Results.Max(r => r.ExecutionTime);

            Console.WriteLine($"Average execution time for all test cases: {averageExecutionTime} seconds");
            Console.WriteLine($"Minimum execution time among all test cases: {minExecutionTime} seconds");
            Console.WriteLine($"Maximum execution time among all test cases: {maxExecutionTime} seconds");
        }
    }
}

// Define C# classes to represent JSON structure
class TestResult
{
    public string TestCase { get; set; }
    public string Status { get; set; }
    public int ExecutionTime { get; set; }
    public DateTime Timestamp { get; set; }
}

class TestResultCollection
{
    public List<TestResult> Results { get; set; }
}
