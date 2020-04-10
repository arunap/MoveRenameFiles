using System;
using System.IO;

namespace RenameFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter Source Path:");
                string sourcePath = Console.ReadLine();

                Console.WriteLine("\nEnter Target Path");
                string targetPath = Console.ReadLine();

                if (!Directory.Exists(sourcePath))
                {
                    return;
                }

                if (Directory.Exists(targetPath))
                    Directory.Delete(targetPath, true);

                Directory.CreateDirectory(targetPath);

                Console.WriteLine("\nEnter Target file Extension");
                string targetExt = Console.ReadLine();

                Console.WriteLine("\nMax files Per Directory");
                int filesPerDirectory = int.Parse(Console.ReadLine());

                string[] files = Directory.GetFiles(sourcePath);

                int idx = 0; int directoryCount = 0;

                string filePathFormat = "{0}\\mediasubstar{1}\\{2}.{3}";
                string destinationPath;

                for (int i = 0; i < files.Length; i++)
                {
                    if (idx == 0 || ((idx % filesPerDirectory) == 0 ))
                    {
                        ++directoryCount;
                        Directory.CreateDirectory($"{targetPath}\\mediasubstar{directoryCount}");
                    }

                    ++idx;
                    destinationPath = string.Format(filePathFormat, targetPath, directoryCount, idx, targetExt);

                    Console.WriteLine($"Moving {files[i]} to {destinationPath}");
                    File.Move(files[i], destinationPath);
                }
            }
        }
    }
}
