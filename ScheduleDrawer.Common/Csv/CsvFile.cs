using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDrawer.Common
{
    public class CsvFile
    {
        #region Properties
        public CsvHeaders Headers 
        { 
            get
            {
                return _headers;
            }
        }
        
        public IList<CsvLine> Lines 
        {
            get 
            { 
                return _lines; 
            }
        }
        #endregion

        #region Variables

        private char[] _separators = new char[] {',' ,';' };
        private const int HeaderLine = 0;
        private List<CsvLine> _lines = new List<CsvLine>();
        private CsvHeaders _headers = new CsvHeaders();

        #endregion

        #region Constructors

        public CsvFile()
        {

        }

        public CsvFile(string content)
        {
            if(string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException("content", "Parameter 'content' cannot be null");
            }

            var lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            CreateHeaders(lines);

            lines.RemoveAt(0);
            CreateValues(lines);
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.AppendLine(string.Join(",", _headers.Names.ToArray()));

            foreach(var line in _lines)
            {
                csvBuilder.AppendLine(string.Join(",", line.Cells.Select(c => string.Format("\"{0}\"", c)).ToArray()));
            }

            return csvBuilder.ToString();
        }

        private void CreateValues(List<string> lines)
        {
            foreach (var line in lines)
            {
                CsvLine csvLine = new CsvLine();
                var cells = line.Split(_separators);
                foreach (var cellValue in cells)
                {
                    csvLine.Cells.Add(cellValue);
                }

                _lines.Add(csvLine);
            }
        }

        private void CreateHeaders(List<string> lines)
        {
            var headers = lines[HeaderLine].Split(_separators);

            foreach (var header in headers)
            {
                Headers.Names.Add(header);
            }
        }

        #endregion
    }
}
