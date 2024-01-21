namespace WordReport.Test;

public class CollectionHelperHelperTests
{
  [Fact]
  public void Merge_ShouldCombineTuples()
  {
    // Arrange
    int[] tuple1 = [1, 2, 3];
    int[] tuple2 = [2, 3, 4];
    List<int[]> tuples = [ tuple1, tuple2 ];

    // Act
    int[] combinedTuple = CollectionHelper.Merge(tuples);

    // Assert
    Assert.Equal(3, combinedTuple[0]);
    Assert.Equal(5, combinedTuple[1]);
    Assert.Equal(7, combinedTuple[2]);
  }

  [Fact]
  public void Merge_ShouldCombinedDictionaries()
  {
    // Arrange
    Dictionary<int, int> dictionary1 = new()
    {
      { 1, 1 },
      { 2, 2 },
      { 3, 3 },
    };
    Dictionary<int, int> dictionary2 = new()
    {
      { 1, 4 },
      { 2, 3 },
      { 4, 7 },
    };
    var dictionaries = new List<Dictionary<int, int>>() {
      dictionary1,
      dictionary2,
    };

    // Act
    Dictionary<int, int> combinedDictionary = CollectionHelper.Merge(dictionaries);

    // Assert
    Assert.Equal(5, combinedDictionary[1]);
    Assert.Equal(5, combinedDictionary[2]);
    Assert.Equal(3, combinedDictionary[3]);
    Assert.Equal(7, combinedDictionary[4]);
  }
}