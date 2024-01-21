# Word Report Generator

This is a console app for .NET which while generate statistics for a given text file; it is written for .NET version 8.0.

## How To Use
1. Open a terminal to the solution folder (WordReport/WordReport)
2. Build the project
```
dotnet build
```
3. Run the project
```
dotnet bin/Debug/net8.0/WordReport.dll
```
4. The app should start in the console, and ask for a file. Enter the absolute path of the file you want to use.
5. The app will create an **output.txt** in the same directory as the input file.

Examples of sample text input and output files are included in the main directory.

## How To Test

Unit tests using XUnit are included. To run them:
1. Open a terminal to the test folder (WordReport/WordReport.Test)
2. Use the test command:
```
dotnet test
```
