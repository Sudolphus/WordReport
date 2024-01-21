namespace WordReport;

public static class DictionaryHelper
{
  public static Dictionary<int, int> Merge(List<Dictionary<int, int>> dictionaries)
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