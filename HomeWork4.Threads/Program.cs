using System.Diagnostics;
using System.Reflection.Emit;

namespace HomeWork4.Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerInfo.PrintSystemInfo();

            var array1 = GenerateRandomIntArray(100000);
            var array2 = GenerateRandomIntArray(1000000);
            var array3 = GenerateRandomIntArray(10000000);

            PrintSum("100 тысяч", array1);
            PrintSum("1 миллион", array2);
            PrintSum("10 миллионов", array3);

            Console.ReadKey();
        }

        private static void PrintSum(string description, int[] intArray)
        {
            Console.WriteLine($"Колличество элементов массива: {description}.");

            Stopwatch sw = Stopwatch.StartNew();
            var result = MathHelper.SumArrayByCicle(intArray);
            sw.Stop();
            Console.WriteLine($"Последовательное вычисление: результат = {result}, время выполнения: {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            result = MathHelper.SumArrayByThreads(intArray);
            sw.Stop();
            Console.WriteLine($"Параллельное вычисление с Thread: результат = {result}, время выполнения: {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            result = MathHelper.SumArrayByLinq(intArray);
            sw.Stop();
            Console.WriteLine($"Параллельное вычисление с LINQ: результат = {result}, время выполнения: {sw.ElapsedMilliseconds} мс");
        }

        private static int[] GenerateRandomIntArray(int countElement)
        {
            var intArray = new int[countElement];
            for (int i = 0; i < countElement; i++)
            {
                var rand = new Random();
                intArray[i] = rand.Next();
            }

            return intArray;
        }
    }
}
