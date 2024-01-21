using System.IO.Abstractions;

namespace WordReport;

public class WordReportService(IFileSystem fileSystem) : IWordReportService
{
  public string[] Lines { get; set; } = [];

  private readonly IFileSystem fileSystem = fileSystem;

  public WordReportService() : this(
    fileSystem: new FileSystem()
  )
  {
  }

  public void ReadFile(string filePath) {
    if (!fileSystem.File.Exists(filePath))
      throw new ArgumentException("File does not exist");

    Lines = fileSystem.File.ReadAllLines(filePath);
  }

  public int[] GetCharacterCountsByLine(string line)
  {
    char[] splitLine = line.ToCharArray();
    int letters = 0;
    int numbers = 0;
    int others = 0;

    foreach (char c in splitLine)
      if (Char.IsLetter(c))
        letters++;
      else if (Char.IsDigit(c))
        numbers++;
      else
        others++;

    return [letters, numbers, others];
  }
}
