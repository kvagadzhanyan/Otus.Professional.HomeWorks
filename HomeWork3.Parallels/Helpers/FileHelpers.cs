namespace HomeWork3.Parallels
{
    public static class FileHelpers
    {
        /// <summary>
        /// Считает количество символов в файле.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="simbol">Символ для поиска.</param>
        /// <returns>Задачу для подсчета количества символов.</returns>
        public static async Task<int> CountSimbolsInFileAsync(string filePath, char simbol)
        {
            Console.WriteLine($"Начало обработки файла {filePath}");
            var fileContent = await File.ReadAllTextAsync(filePath);
            var result = fileContent.Count(c => c == simbol);
            Console.WriteLine($"В файле {filePath} найдено {result} указанных символов.");
            return result;
        }

        /// <summary>
        /// Считает количество вхождений указанных символов в файлах каталога.
        /// </summary>
        /// <param name="folderPath">Путь к каталогу.</param>
        /// <param name="simbol">Символ для поиска.</param>
        /// <returns>Задачу для подсчета количества символов.</returns>
        public static async Task<int> CountSimbolsInFolder(string folderPath, char simbol)
        {
            if (Directory.Exists(folderPath) == false)
            {
                Console.WriteLine($"Каталог по указанному пути {folderPath} не найден.");
                return -1;
            }
            var files = Directory.GetFiles(folderPath);
            var tasks = new List<Task<int>>();

            for (int i = 0; i < files.Length; i++)
            {
                tasks.Add(CountSimbolsInFileAsync(files[i], simbol));
            }

            int result = (await Task.WhenAll(tasks)).Sum();
            Console.WriteLine($"В каталоге {folderPath} найдено {result} вхождений указанных символов.");
            return result;
        }
    }
}
