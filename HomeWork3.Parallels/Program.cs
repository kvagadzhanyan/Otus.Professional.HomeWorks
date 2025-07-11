using System.Diagnostics;

namespace HomeWork3.Parallels
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Work();
            Work(false);
            Console.ReadKey();
        }

        static void Work(bool isDefaultFolder = true)
        {
            var directory = $"{Directory.GetCurrentDirectory()}\\testsDirectory";
            var simbols = " ";
            if (isDefaultFolder)
            {
                Console.WriteLine("Задание 1. Обработка трех файлов.");
            }
            else
            {
                Console.Write("Введите путь каталога для подсчета символов в файлах: ");
                directory = Console.ReadLine();
                Console.Write("Введите символ для поиска: ");
                simbols = Console.ReadLine();
            }
            
            var stopwatch = Stopwatch.StartNew();
            var result = FileHelpers.CountSimbolsInFolder(directory, string.IsNullOrEmpty(simbols) ? ' ' : simbols[0]).Result;
            stopwatch.Stop();

            Console.WriteLine($"Результат обработки всех файлов = {result}. Обработка заняла {stopwatch.ElapsedMilliseconds} мс.");
        }
    }
}
