using System;
using System.IO;

namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"путь к очищаемой папке";
            DirectoryInfo directory = new DirectoryInfo(path);

            CleanDirectory(directory);
        }
        public static void CleanDirectory(DirectoryInfo directory)
        {
            try
            {
                if (directory.Exists)
                {
                    var directories = directory.GetDirectories();
                    for (int i = 0; i < directories.Length; i++)
                    {
                        if ((DateTime.Now - directories[i].LastAccessTime) >= TimeSpan.FromMinutes(30))
                        {
                            directories[i].Delete(true);
                        }
                    }

                    var files = directory.GetFiles();
                    for (int i = 0; i < files.Length; i++)
                    {
                        if ((DateTime.Now - files[i].LastAccessTime) >= TimeSpan.FromMinutes(30))
                        {
                            files[i].Delete();
                        }
                    }
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
