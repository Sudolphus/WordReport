namespace WordReport;

public interface IWordReportService
{
  public string[] Lines { get; set; }

  public void ReadFile(string filePath);

  public int[] GetCharacterCountsByLine(string line);
}
