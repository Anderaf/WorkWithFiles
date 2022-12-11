using System;
using System.IO;

namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(@"путь к папке");
            
            Console.WriteLine(GetDirectorySizeInBytes(directory) + " байт");
        }
        static public long GetDirectorySizeInBytes(DirectoryInfo directory)
        {
            try
            {
                if (directory.Exists)
                {
                    long sizeInBytes = 0;

                    var directories = directory.GetDirectories();
                    for (int i = 0; i < directories.Length; i++)
                    {
                        sizeInBytes += GetDirectorySizeInBytes(directories[i]);
                    }

                    var files = directory.GetFiles();
                    for (int i = 0; i < files.Length; i++)
                    {
                        sizeInBytes += files[i].Length;
                    }

                    return sizeInBytes;

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

            return 0;
        }
    }
}
