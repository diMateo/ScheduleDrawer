using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDrawer.Entities
{
    public class Schedule
    {
        private IList<Match> _matches = new List<Match>();
        public IList<Match> Matches 
        { 
            get
            {
                return _matches;
            }
        }
    }
}
