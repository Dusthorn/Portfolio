namespace RandomFileGenerator
  {
  using System;
  using System.IO;
  using System.Text;

  class Program
    {
    private static readonly Random _random = new();

    /// <summary> Массив согласных </summary>
    private static readonly string[] _consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };

    /// <summary> Массив гласных </summary>
    private static readonly string[] _vowels = { "a", "e", "i", "o", "u" };

    static void Main(string[] args)
      {
      Console.OutputEncoding = Encoding.UTF8;
      Console.InputEncoding = Encoding.UTF8;

      try
        {
        var requestedFileVolume = DisplayMenu() * Math.Pow(2, 30);
        var path = Path.Combine(
          AppDomain.CurrentDomain.BaseDirectory,
          $"{DateTimeOffset.Now:yyyy-MM-dd--HH-mm-ss}.txt");
        double previousProgress = 0;
        using var sw = new StreamWriter(path);
        while (sw.BaseStream.Position < requestedFileVolume)
          {
          var wordsCountInLine = _random.Next(1, 4);
          var sb = new StringBuilder();
          sb.Append($"{_random.Next(1, int.MaxValue)}. ");
          for (var i = 0; i < wordsCountInLine; i++)
            {
            sb.Append($"{BuildWord(i == 0, _random.Next(2, 15))} ");
            }

          sw.WriteLine(sb.ToString());
                    
          previousProgress = ShowProgressIfNeed(previousProgress, sw.BaseStream.Position / requestedFileVolume);
          }

        Console.WriteLine($"Файл доступен по пути: {Environment.NewLine}{path}{Environment.NewLine}");
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
    /// <returns> Объём генерируемого файла в ГБ </returns>
    private static int DisplayMenu()
      {
      Console.WriteLine("Генератор файла заданного размера");
      Console.WriteLine();
      Console.WriteLine("Введите требуемый объём файла в ГБ: ");
      var result = Console.ReadLine();
      return Convert.ToInt32(result);
      }

    /// <summary>
    /// Создание "слова"
    /// </summary>
    /// <param name="isCapitalLetter"> Слово начинается с заглавной буквы </param>
    /// <param name="requestedLength"> Требуемая длина слова </param>
    /// <returns> Слово </returns>
    private static string BuildWord(bool isCapitalLetter, int requestedLength)
      {
      if (requestedLength < 2)
        {
        throw new ArgumentException($"{nameof(requestedLength)} can not be less than 2!");
        }

      var wordBuilder = new StringBuilder();

      for (var i = 0; i < requestedLength; i ++)
        {
        if(i % 2 == 0)
          {
          var consonant = _consonants[_random.Next(0, _consonants.Length - 1)];
          if (isCapitalLetter)
            {
            consonant = consonant.ToUpper();
            isCapitalLetter = false;
            }

          wordBuilder.Append(consonant);
          }
        else
          {
          var vowel = _vowels[_random.Next(0, _vowels.Length - 1)];

          wordBuilder.Append(vowel);
          }
        }

      return wordBuilder.ToString();
      }

    /// <summary>
    /// Отображение прогресса создания файла
    /// </summary>
    /// <param name="previousProgress"> Предыдущий прогресс </param>
    /// <param name="progress"> Текущий прогресс </param>
    /// <returns> Последнее значение отображенного прогресса </returns>
    private static double ShowProgressIfNeed(double previousProgress, double progress)
      {
      var roundProgress = Math.Round(progress, 2);
      if (roundProgress - previousProgress >= 0.01)
        {
        Console.Clear();
        Console.WriteLine($"\bПрогресс создания файла {Math.Round(roundProgress * 100):G}%");
        previousProgress = roundProgress;
        }
      return previousProgress;
      }
    }
  }