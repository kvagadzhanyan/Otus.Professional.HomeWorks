using System.Management;

namespace HomeWork4.Threads
{
    /// <summary>
    /// Класс для получения данных о системе.
    /// </summary>
    public static class ComputerInfo
    {
        /// <summary>
        /// Выводит на экран информацию о системе.
        /// </summary>
        public static void PrintSystemInfo()
        {
            Console.WriteLine("=== Информация о системе ===");
            Console.WriteLine();

            Console.WriteLine("Операционная система:");
            Console.WriteLine(GetOsInfo());
            Console.WriteLine();

            Console.WriteLine("Процессор:");
            Console.WriteLine(GetProcessorInfo());
            Console.WriteLine();

            Console.WriteLine("Оперативная память:");
            Console.WriteLine(GetMemoryInfo());
            Console.WriteLine();

            Console.WriteLine("Жесткие диски:");
            Console.WriteLine(GetDiskInfo());

            Console.WriteLine("=== Конец секции информации о системе ===");
        }

        private static string GetOsInfo()
        {
            return $"{Environment.OSVersion} (Platform: {Environment.OSVersion.Platform})";
        }

        private static string GetProcessorInfo()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("select Name from Win32_Processor"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        return obj["Name"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка получения информации: {ex.Message}";
            }
            return "Не удалось определить процессор.";
        }

        private static string GetMemoryInfo()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("select TotalVisibleMemorySize, FreePhysicalMemory from Win32_OperatingSystem"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        var totalKb = (ulong)obj["TotalVisibleMemorySize"];
                        var freeKb = (ulong)obj["FreePhysicalMemory"];

                        var totalGb = totalKb / 1024.0 / 1024.0;
                        var freeGb = freeKb / 1024.0 / 1024.0;

                        return $"Всего: {totalGb:F2} ГБ, Свободно: {freeGb:F2} ГБ";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка получения информации: {ex.Message}";
            }
            return "Не удалось определить память.";
        }

        private static string GetDiskInfo()
        {
            try
            {
                var drives = DriveInfo.GetDrives();
                string info = "";
                foreach (var drive in drives)
                {
                    if (drive.IsReady && drive.DriveType == DriveType.Fixed)
                    {
                        var totalSize = drive.TotalSize;
                        var freeSpace = drive.TotalFreeSpace;

                        var totalGb = totalSize / 1024.0 / 1024.0 / 1024.0;
                        var freeGb = freeSpace / 1024.0 / 1024.0 / 1024.0;

                        info += $"{drive.Name} - Общий объем: {totalGb:F2} ГБ, Свободно: {freeGb:F2} ГБ\n";
                    }
                }
                return info.TrimEnd();
            }
            catch (Exception ex)
            {
                return $"Ошибка получения информации: {ex.Message}";
            }
        }
    }
}
