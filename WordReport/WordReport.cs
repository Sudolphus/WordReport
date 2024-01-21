using System.IO.Abstractions;

namespace WordReport;

public class WordReport
{
  private readonly IFileSystem fileSystem;

  public WordReport(IFileSystem fileSystem)
  {
    this.fileSystem = fileSystem;
  }
}
