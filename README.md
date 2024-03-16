# TechChallenge

# Test Results Analysis in C#

This repository contains a C# solution for analyzing test results stored in a JSON file, generating metrics based on the results, and exporting them to a CSV file.

## Instructions

To test the provided C# script, follow these steps:

1. **Clone the Repository**: Clone this repository to your local machine using Git.

    ```bash
    git clone https://github.com/your-username/test-results-analysis.git
    ```

2. **Navigate to the Directory**: Move into the directory containing the cloned repository.

    ```bash
    cd test-results-analysis
    ```

3. **Prepare JSON Data**: Create a JSON file named `test_results.json` with test results data. You can use the provided example or create your own.

    Example JSON file content:

    ```json
    {
      "Results": [
        {
          "TestCase": "Test 1",
          "Status": "pass",
          "ExecutionTime": 10,
          "Timestamp": "2024-03-13T12:00:00Z"
        },
        {
          "TestCase": "Test 2",
          "Status": "fail",
          "ExecutionTime": 15,
          "Timestamp": "2024-03-13T12:05:00Z"
        },
        {
          "TestCase": "Test 3",
          "Status": "pass",
          "ExecutionTime": 8,
          "Timestamp": "2024-03-13T12:10:00Z"
        }
      ]
    }
    ```

4. **Compile the C# Script**: Use the C# compiler (csc) to compile the script into an executable.

    ```bash
    csc /out:TestResultsAnalyzer.exe TestResultsAnalyzer.cs /r:Newtonsoft.Json.dll
    ```

    Make sure you have the C# compiler installed and the Newtonsoft.Json.dll assembly present in the same directory or adjust the path in the command accordingly.

5. **Run the Program**: Execute the compiled program.

    ```bash
    TestResultsAnalyzer.exe
    ```

6. **View Output**: Check the console output for the generated metrics.

    Example output:

    ```
    Metrics:
    Total number of test cases executed: 3
    Number of test cases passed: 2
    Number of test cases failed: 1
    Average execution time for all test cases: 11 seconds
    Minimum execution time among all test cases: 8 seconds
    Maximum execution time among all test cases: 15 seconds
    ```

7. **Verify CSV File**: Check the generated CSV file (`test_results.csv`) for the detailed test results.

## Notes

- Ensure that the provided JSON file contains valid test results data in the specified format.
- Make sure to have the required dependencies installed and available for compilation and execution.
- Feel free to modify the provided script or JSON data for testing different scenarios.
