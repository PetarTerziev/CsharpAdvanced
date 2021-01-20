using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("../../..");
            Dictionary<string, Dictionary<string, double>> fileInfo = new Dictionary<string, Dictionary<string, double>>();
            FileInfo[] files = directoryInfo.GetFiles();

            foreach (var file in files)
            {
                if (!fileInfo.ContainsKey(file.Extension))
                {
                    fileInfo.Add(file.Extension, new Dictionary<string, double>());
                }

                fileInfo[file.Extension].Add(file.Name, file.Length / 1024.00);
            }


            using (var writer = new StreamWriter($@"{Environment.GetFolderPath(
                         System.Environment.SpecialFolder.DesktopDirectory)}\report.txt"))
            {
                foreach (var item in fileInfo.OrderByDescending(f => f.Value.Count).ThenBy(n => n.Key))
                {
                    writer.WriteLine($"{item.Key}");

                    foreach (var file in item.Value.OrderByDescending(f => f.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value}kb");
                    }
                }
            }
        }
    }
}
