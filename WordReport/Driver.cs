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
    Console.WriteLine("File Name: " + filePath);
    Console.WriteLine("Number of Lines: " + numberOfLines);
    Console.WriteLine("Number of Total Characters: " + characterCounts.Sum());
    Console.WriteLine("Number Of Letters: " + characterCounts[0]);
    Console.WriteLine("Number of Digits: " + characterCounts[1]);
    Console.WriteLine("Number of Other Characters:" + characterCounts[2]);
    foreach (var wordCount in wordCounts)
    {
      Console.WriteLine("Number of " + wordCount.Key + " letter words:" + wordCount.Value);
    }
  }
}