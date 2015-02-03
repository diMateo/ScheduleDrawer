using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDrawer.Common
{
    public class CsvLine
    {
        private List<string> _cells = new List<string>();

        public IList<string> Cells
        {
            get
            {
                return _cells;
            }
        }
    }
}
