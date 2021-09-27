namespace BigFileSorter
  {
  using System;
  using System.Diagnostics;
  using System.IO;
  using System.Text;
  using System.Threading;
  using System.Threading.Tasks;

  class Program
    {
    static async Task Main(string[] args)
      {
      Console.OutputEncoding = Encoding.UTF8;
      Console.InputEncoding = Encoding.UTF8;

      try
        {
        var unsortedFilePath = DisplayMenu();
        var unsortedFileName = Path.GetFileNameWithoutExtension(unsortedFilePath);
        var sortedFilePath = Path.Combine(
          AppDomain.CurrentDomain.BaseDirectory,
          $"{unsortedFileName}-sorted.txt");

        var cancellationTokenSource = new CancellationTokenSource();

        var unsortedFile = File.OpenRead(unsortedFilePath);
        var targetFile = File.OpenWrite(sortedFilePath);
        var options = new ExternalMergeSorterOptions
          {
          FileLocation = AppDomain.CurrentDomain.BaseDirectory,
          Sort = new ExternalMergeSortSortOptions
            {
            Comparer = new CustomRowComparer()
            },
          Split = new ExternalMergeSortSplitOptions
            {
            FileSize = 128 * 1024 * 1024
            }
          };
        var sorter = new ExternalMergeSorter(options);

      
                
        var watch = Stopwatch.StartNew();
        await sorter.Sort(unsortedFile, targetFile, cancellationTokenSource.Token);
        watch.Stop();
        Console.WriteLine($"Файл {unsortedFilePath} отсортирован за {watch.ElapsedMilliseconds/1000} cекунд");

        Console.WriteLine($"Файл доступен по пути: {Environment.NewLine}{sortedFilePath}{Environment.NewLine}");
        }
      catch (Exception e)
        {
        Console.WriteLine(e.Message);
        }

      Console.WriteLine("Нажмите любую клавишу для завершения работы программы");
      Console.ReadKey();
      }

    /// <summary>
    /// Вывод меню
    /// </summary>
    /// <returns> Путь к файлу для сортировки </returns>
    private static string DisplayMenu()
      {
      Console.WriteLine("Сортировщик содержимого больших файлов");
      Console.WriteLine();
      Console.WriteLine("Введите путь к файлу: ");
      var result = Console.ReadLine();
      return Convert.ToString(result);
      }
    }
  }