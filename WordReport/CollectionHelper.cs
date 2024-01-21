namespace WordReport;

public static class CollectionHelper
{
  public static int[] Merge(IEnumerable<int[]> tuples)
  {
    int[] combinedTuple = [0, 0, 0];

    foreach (var tuple in tuples)
    {
      combinedTuple[0] += tuple[0];
      combinedTuple[1] += tuple[1];
      combinedTuple[2] += tuple[2];
    }

    return combinedTuple;
  }

  public static Dictionary<int, int> Merge(IEnumerable<Dictionary<int, int>> dictionaries)
  {
    Dictionary<int, int> combinedDictionary = [];
    
    foreach (var dictionary in dictionaries)
      foreach (int key in dictionary.Keys)
        if (combinedDictionary.ContainsKey(key))
          combinedDictionary[key] += dictionary[key];
        else
          combinedDictionary[key] = dictionary[key];

    return combinedDictionary;
  }
}