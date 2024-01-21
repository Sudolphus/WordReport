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
}
