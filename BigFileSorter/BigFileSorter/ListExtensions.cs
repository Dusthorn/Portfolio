namespace BigFileSorter
  {
  using System.Collections.Generic;
  using System.Linq;

  /// <summary>
  /// Вспомогательные методы для IReadOnlyList
  /// </summary>
  public static class ListExtensions
    {
    public static IReadOnlyList<List<T>> ChunkBy<T>(this IReadOnlyList<T> source, int chunkSize)
      {
      return source
        .Select((x, i) => new { Index = i, Value = x })
        .GroupBy(x => x.Index / chunkSize)
        .Select(x => x.Select(v => v.Value).ToList())
        .ToList();
      }
    }
  }