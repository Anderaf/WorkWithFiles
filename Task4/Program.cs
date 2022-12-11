using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string directoryPath = desktopPath + @"\students";
                var directory = new DirectoryInfo(directoryPath);

                if (!directory.Exists)
                    directory.Create();

                string binaryFilePath = desktopPath + @"\Students.dat";
                var binaryFile = new FileInfo(binaryFilePath);

                if (binaryFile.Exists)
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    Student[] students;

                    using (var fs = new FileStream(binaryFilePath, FileMode.OpenOrCreate))
                    {
                        students = (Student[])formatter.Deserialize(fs);
                    }

                    for (int i = 0; i < students.Length; i++)
                    {
                        string filePath = directoryPath + @"\" + students[i].Group + ".txt";
                        FileInfo file = new FileInfo(filePath);

                        using (StreamWriter sw = file.AppendText())
                        {
                            sw.WriteLine("{0}, {1}", students[i].Name, students[i].DateOfBirth);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Бинарный файл не найден");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: {0}", e);
            }
            
        }
    }
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
