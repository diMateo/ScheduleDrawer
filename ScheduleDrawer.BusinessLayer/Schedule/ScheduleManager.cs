using ScheduleDrawer.Entities;
using ScheduleDrawer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDrawer.BusinessLayer.Schedule
{
    public class ScheduleManager
    {
        private ScheduleCreator _scheduleCreator;
        private IScheduleService _scheduleService;

        public ScheduleManager(ScheduleCreator scheduleCreator, IScheduleService scheduleService)
        {
            _scheduleCreator = scheduleCreator;
            _scheduleService = scheduleService;
        }

        public Entities.Schedule Create(bool revenge)
        {
            return _scheduleCreator.Create(revenge);
        }

        public void Save(Entities.Schedule schedule)
        {
            if(schedule == null)
            {
                throw new ArgumentNullException("schedule", "Parameter 'schedule' cannot be null");
            }

            if (!schedule.Matches.Any())
            {
                throw new ArgumentNullException("schedule", "Parameter 'schedule.Matches' cannot be null or empty");
            }

             _scheduleService.Save(schedule);
        }

    }
}
