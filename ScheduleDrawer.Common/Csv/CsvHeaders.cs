using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDrawer.Common
{
    public class CsvHeaders
    {
        private IList<String> _names = new List<String>();
        
        public IList<string> Names
        {
            get
            {
                return _names;
            }
        }
    }
}
