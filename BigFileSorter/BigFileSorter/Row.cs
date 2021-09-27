namespace BigFileSorter
  {
  /// <summary> Модель строки файла </summary>
  internal readonly struct Row
    {
    /// <summary> Строковое содержимое </summary>
    public string Value { get; init; }

    /// <summary> Индекс StreamReader </summary>
    public int StreamReader { get; init; }
    }
  }