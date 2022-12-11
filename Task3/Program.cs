using System;
using System.IO;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(@"путь к папке");
            try
            {
                if (directory.Exists)
                {
                    long initialDirectorySizeInBytes = Task2.Program.GetDirectorySizeInBytes(directory);
                    Console.WriteLine("Исходный размер папки: {0}", initialDirectorySizeInBytes);

                    Task1.Program.CleanDirectory(directory);
                    long directorySizeInBytes = Task2.Program.GetDirectorySizeInBytes(directory);
                    Console.WriteLine("Освобождено: {0}", initialDirectorySizeInBytes - directorySizeInBytes);

                    Console.WriteLine("Текущий размер папки: {0}", directorySizeInBytes);
                }
                else
                {
                    Console.WriteLine("Папка не существует");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: {0}", e);
            }
            
        }
    }
}
