using System.IO.Abstractions.TestingHelpers;
using System.Linq;

namespace WordReport.Test;

public class WordReportServiceTest
{
    private static readonly string testPath = @"c:\testfile.txt";
    private static readonly string testMessage = "Test123!";
    private readonly MockFileSystem fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { testPath, new MockFileData(testMessage) },
        });

    [Fact]
    public void ReadFile_ShouldThrowError_IfFileDoesntExist()
    {
        // Arrange
        IWordReportService wordReportService = new WordReportService(fileSystem);

        // Act
        try
        {
            wordReportService.ReadFile(@"c:\fakefile.txt");
        }
        catch (ArgumentException e)
        {
            Assert.Equal("File does not exist", e.Message);
            return;
        }

        Assert.Fail("The expected exception was not thrown");
    }

    [Fact]
    public void ReadFile_ShouldReadFileData_IfFileExists()
    {
        // Arrange
        IWordReportService wordReportService = new WordReportService(fileSystem);

        // Act
        wordReportService.ReadFile(testPath);

        // Assert
        Assert.Equal(wordReportService.Lines.First(), testMessage);
    }

    [Fact]
    public void GetCharacterCountsByLine_ShouldReturnCharacterCounts_WhenExists()
    {
        // Arrange
        IWordReportService wordReportService = new WordReportService(fileSystem);
        wordReportService.ReadFile(testPath);

        // Act
        int[] characterCounts = wordReportService.GetCharacterCountsByLine(wordReportService.Lines.First());

        // Assert
        Assert.Equal(4, characterCounts[0]);
        Assert.Equal(3, characterCounts[1]);
        Assert.Equal(1, characterCounts[2]);
    }
}