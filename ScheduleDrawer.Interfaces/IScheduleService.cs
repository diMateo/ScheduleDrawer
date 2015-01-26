using ScheduleDrawer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDrawer.Interfaces
{
    public interface IScheduleService
    {
        void Save(Schedule schedule);
    }
}
