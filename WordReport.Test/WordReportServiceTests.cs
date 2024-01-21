using System.IO.Abstractions.TestingHelpers;
using System.Linq;

namespace WordReport.Test;

public class WordReportServiceTest
{
    private static readonly string testPath = @"c:\testfile.txt";
    private static readonly string testMessage = "Test123!";
    private static readonly string testPath2 = @"c:\testfile.txt2";
    private static readonly string testMessage2 = "A A A BB BB CCC";

    private readonly MockFileSystem fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { testPath, new MockFileData(testMessage) },
            { testPath2, new MockFileData(testMessage2) },
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

    [Fact]
    public void GetWordLengthsByLine_ShouldReturnWordLengths_WhenExists()
    {
        // Arrange
        IWordReportService wordReportService = new WordReportService(fileSystem);
        wordReportService.ReadFile(testPath2);

        // Act
        var wordLengths = wordReportService.GetWordLengthsByLine(wordReportService.Lines.First());

        // Assert
        Assert.Equal(3, wordLengths[1]);
        Assert.Equal(2, wordLengths[2]);
        Assert.Equal(1, wordLengths[3]);
    }
}