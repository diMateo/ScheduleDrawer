using System;
using System.IO;
using System.Text;

namespace ScheduleDrawer.Csv
{
    public class CsvProcessor
    {
        public void Save(string fileName, string text)
        {
            try
            {
                File.WriteAllText(GetPathForOutputFile(fileName), text, Encoding.UTF8);
            }
            catch (IOException e)
            {
                throw new IOException(string.Format("File cannot be saved. Make sure it is not used by any other process.\n{0}", e.Message));
            }
        }

        public string Read(string fileName)
        {
            var fileContent = string.Empty;
            var filePath = GetPathForOutputFile(fileName);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format("File with the specified path does not exist ({0}).", filePath)); 
            }

            try
            {
                fileContent = File.ReadAllText(filePath, Encoding.UTF8);
            }
            catch (IOException e)
            {
                throw new IOException(string.Format("Error reading from file.\n{0}", e.Message));
            }

            return fileContent;
        }

        private string GetPathForOutputFile(string fileName)
        {
            var debugLocation = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            var currentLocation = debugLocation.Remove(debugLocation.IndexOf(@"\bin\", StringComparison.Ordinal));

            return string.Format(@"{0}\Results\{1}.csv", currentLocation, fileName);
        }
    }
}
