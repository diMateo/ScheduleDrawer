using System;
using System.Collections.Generic;
using ScheduleDrawer.Csv;
using ScheduleDrawer.Entities;

namespace ScheduleDrawer.Schedule
{
    public class ScheduleManager
    {
        private readonly ScheduleCreator _scheduleCreator;
        private readonly ScheduleConverter _scheduleConverter;
        private readonly CsvProcessor _csvProcessor;

        public ScheduleManager()
        {
            _scheduleCreator = new ScheduleCreator();
            _scheduleConverter = new ScheduleConverter();
            _csvProcessor = new CsvProcessor();
        }

        public IEnumerable<Match> CreateSchedule(IEnumerable<string> players, bool revangeRound = false)
        {
            if (players == null)
            {
                throw new ArgumentNullException("players", "Parameter cannot be null.");
            }

            return _scheduleCreator.CreateSchedule(players, revangeRound);
        }

        public void SaveScheduleToCsv(string fileName, IEnumerable<Match> schedule)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName", "Parameter cannot be null.");
            }

            if (schedule == null)
            {
                throw new ArgumentNullException("schedule", "Parameter cannot be null.");
            }

            var convertedSchedule = _scheduleConverter.ConvertScheduleToString(schedule);
            _csvProcessor.Save(fileName, convertedSchedule);
        }

        public IEnumerable<Match> ReadScheduleFromCsv(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName", "Parameter cannot be null.");
            }

            var fileContent = _csvProcessor.Read(fileName);
            return _scheduleConverter.ConvertStringToSchedule(fileContent);
        }
    }
}
