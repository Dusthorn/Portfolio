namespace BigFileSorter
  {
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// Опции работы
  /// </summary>
  public class ExternalMergeSorterOptions
    {
    public ExternalMergeSorterOptions()
      {
      Split = new ExternalMergeSortSplitOptions();
      Sort = new ExternalMergeSortSortOptions();
      Merge = new ExternalMergeSortMergeOptions();
      }

    public string FileLocation { get; init; } = "c:\\temp\\files";

    public ExternalMergeSortSplitOptions Split { get; init; }

    public ExternalMergeSortSortOptions Sort { get; init; }

    public ExternalMergeSortMergeOptions Merge { get; init; }
    }

  public class ExternalMergeSortSplitOptions
    {
    /// <summary>
    /// Объем несортированного кусочка файла (байт)
    /// </summary>
    public int FileSize { get; init; } = 2 * 1024 * 1024;

    public char NewLineSeparator { get; init; } = '\n';

    public IProgress<double> ProgressHandler { get; init; } = null!;
    }

  public class ExternalMergeSortSortOptions
    {
    public IComparer<string> Comparer { get; init; } = Comparer<string>.Default;

    public int InputBufferSize { get; init; } = 65536;

    public int OutputBufferSize { get; init; } = 65536;

    public IProgress<double> ProgressHandler { get; init; } = null!;
    }

  public class ExternalMergeSortMergeOptions
    {
    /// <summary>
    /// Количество файлов для обработки за раз
    /// </summary>
    public int FilesPerRun { get; init; } = 10;

    /// <summary>
    /// Объем буфера для входящего потока (байт)
    /// </summary>
    public int InputBufferSize { get; init; } = 65536;

    /// <summary>
    /// Объем буфера для выходящего потока (байт)
    /// </summary>
    public int OutputBufferSize { get; init; } = 65536;

    public IProgress<double> ProgressHandler { get; init; } = null!;
    }
  }