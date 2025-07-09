using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomeWork4.Threads
{
    /// <summary>
    /// Класс математических действий.
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// Считает сумму элементов целочисленного массива перебором.
        /// </summary>
        /// <param name="intArray">Массив целочисленных данных.</param>
        /// <returns>Сумма элементов массива.</returns>
        public static long SumArrayByCicle(int[] intArray)
        {
            long sum = 0;

            foreach (var item in intArray)
            {
                sum += item;
            }
            
            return sum;
        }

        /// <summary>
        /// Считает сумму элементов целочисленного массива в многопоточном режиме.
        /// </summary>
        /// <param name="intArray">Массив целочисленных данных.</param>
        /// <returns>Сумма элементов массива.</returns>
        public static long SumArrayByThreads(int[] intArray)
        {
            var processorCount = Environment.ProcessorCount;
            var threads = new Thread[processorCount];
            var size = intArray.Length;
            var segmentSize = size / processorCount;

            var lockObj = new object();
            long sum = 0;

            for (int i = 0; i < processorCount; i++)
            {
                var start = i * segmentSize;
                var end = (i == processorCount - 1) ? size : start + segmentSize;

                threads[i] = new Thread(() =>
                {
                    long localSum = 0;
                    for (int j = start; j < end; j++)
                    {
                        localSum += intArray[j];
                    }
                    lock (lockObj)
                    {
                        sum += localSum;
                    }
                });
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            return sum;
        }

        /// <summary>
        /// Считает сумму элементов целочисленного массива с помощью LINQ.
        /// </summary>
        /// <param name="intArray">Массив целочисленных данных.</param>
        /// <returns>Сумма элементов массива.</returns>
        public static long SumArrayByLinq(int[] intArray)
        {
            return intArray.AsParallel().Sum(e => (long)e);
        }

        private static void SumCurrentThread(int[] array, int start, int end, long[] partialSums, int index)
        {
            long sum = 0;
            for (int i = start; i < end; i++)
            {
                sum += array[i];
            }
            partialSums[index - 1] = sum;
        }
    }
}
