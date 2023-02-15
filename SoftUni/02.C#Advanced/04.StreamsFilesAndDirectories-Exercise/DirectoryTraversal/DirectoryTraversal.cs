namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath, "*");

            var filesInfo = new Dictionary<string, Dictionary<string, double>>();

            foreach (var path in files)
            {
                string fileName = Path.GetFileName(path);
                string extension = Path.GetExtension(path);
                double size = new FileInfo(path).Length / 1024.0;

                if (!filesInfo.ContainsKey(extension))
                    {
                    filesInfo.Add(extension, new Dictionary<string, double>()); 
                }

                filesInfo[extension].Add(fileName, size);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in filesInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                sb.Append(item.Key);

                foreach (var file in item.Value.OrderBy(x => x.Value))
                {
                    sb.AppendLine($"--{file.Key} - {file.Value:f3}kb");
                }
            }
            return sb.ToString().TrimEnd();
        }


        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";

            File.WriteAllText(path, reportFileName);
        }

    }
}
