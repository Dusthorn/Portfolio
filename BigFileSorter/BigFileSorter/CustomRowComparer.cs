namespace BigFileSorter
  {
  using System;
  using System.Collections.Generic;

  /// <summary> Сравниватель строк вида (int. string) </summary>
  public class CustomRowComparer : IComparer<string>
    {
    #region Implementation of IComparer<in string>

    /// <inheritdoc />
    public int Compare(string x, string y)
      {
      try
        {
        if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y))
          {
          return string.Compare(x, y, StringComparison.Ordinal);
          }

        var xSplit = x.Split(". ");
        var ySplit = y.Split(". ");
        var xString = xSplit[1];
        var yString = ySplit[1];
        if (xString.Equals(yString, StringComparison.OrdinalIgnoreCase))
          {
          var xNumber = int.Parse(xSplit[0]);
          var yNumber = int.Parse(ySplit[0]);
          return xNumber.CompareTo(yNumber);
          }
        return string.Compare(xString, yString, StringComparison.Ordinal);
        }
      catch (Exception e)
        {
        Console.WriteLine(e.Message);
        }

      return -1;
      }

    #endregion
    }
  }