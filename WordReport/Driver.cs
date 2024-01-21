namespace WordReport;

public class Driver()
{
  public string filePath = "";
  public int numberOfLines = 0;
  public int[] characterCounts = [];
  public int wordCount = 0;
  public Dictionary<int, int> wordCounts = [];

  private readonly IWordReportService wordReportService = new WordReportService();

  public void GetData()
  {
    Console.WriteLine("Enter file:");
    filePath = @"" + Console.ReadLine();
    
    wordReportService.ReadFile(filePath);

    numberOfLines = wordReportService.Lines.Length;
    characterCounts = CollectionHelper.Merge(wordReportService.Lines.Select(line => wordReportService.GetCharacterCountsByLine(line)));
    wordCounts = CollectionHelper.Merge(wordReportService.Lines.Select(line => wordReportService.GetWordLengthsByLine(line)));
    wordCount = wordCounts.Values.Sum();
  }

  public void PrintData()
  {
    string directory = Path.GetDirectoryName(filePath) ?? @"c:\";
    List<string> linesToPrint = [];
    linesToPrint.Add("File Name: " + filePath);
    linesToPrint.Add("Number of Lines: " + numberOfLines);
    linesToPrint.Add("Number of Total Characters: " + characterCounts.Sum());
    linesToPrint.Add("Number Of Letters: " + characterCounts[0]);
    linesToPrint.Add("Number of Digits: " + characterCounts[1]);
    linesToPrint.Add("Number of Other Characters:" + characterCounts[2]);
    for (int i = 1; i <= wordCounts.Keys.Max(); i++)
      if (wordCounts.TryGetValue(i, out int value))
        linesToPrint.Add("Number of " + i + " letter words: " + value);

    using (StreamWriter outputFile = new(Path.Combine(directory, "output.txt")))
    {
      foreach (string line in linesToPrint)
        outputFile.WriteLine(line);
    };
  }
}