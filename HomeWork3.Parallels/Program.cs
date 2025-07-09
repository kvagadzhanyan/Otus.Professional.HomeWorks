using System.Diagnostics;

namespace HomeWork3.Parallels
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Work1();
            Work2();
            Console.ReadKey();
        }

        static void Work1()
        {
            Console.WriteLine("Задание 1. Обработка трех файлов.");
            var stopwatch = Stopwatch.StartNew();            
            var defaultFilesDirectory = $"{Directory.GetCurrentDirectory()}\\testsDirectory";
            var result = FileHelpers.CountSimbolsInFolder(defaultFilesDirectory, ' ').Result;
            stopwatch.Stop();
            Console.WriteLine($"Результат обработки первого задания = {result}. Обработка заняла {stopwatch.ElapsedMilliseconds} мс.");
        }

        static void Work2()
        {
            Console.Write("Введите путь каталога для подсчета символов в файлах: ");
            var directory = Console.ReadLine();
            Console.Write("Введите символы для поиска: ");
            var simbols = Console.ReadLine();
            var stopwatch = Stopwatch.StartNew();
            var result = FileHelpers.CountSimbolsInFolder(directory, string.IsNullOrEmpty(simbols) ? ' ' : simbols[0]).Result;
            stopwatch.Stop();
            Console.WriteLine($"Результат обработки второго задания = {result}. Обработка заняла {stopwatch.ElapsedMilliseconds} мс.");
        }
    }
}
