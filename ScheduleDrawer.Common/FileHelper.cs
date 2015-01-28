using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDrawer.Common
{
    public static class FileHelper
    {
        public static IList<string> ReadFileLines(string filePath)
        {
            if(string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("filePath", "Parameter 'filePath' cannot be null or empty");
            }

            return File.ReadAllLines(filePath).ToList();
        }

        public static void WriteFile(string filePath, string fileContent)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("filePath", "Parameter 'filePath' cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(fileContent))
            {
                throw new ArgumentNullException("fileContent", "Parameter 'fileContent' cannot be null or empty");
            }

            File.WriteAllText(filePath, fileContent);
        }
    }
}
