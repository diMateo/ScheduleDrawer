using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleDrawer.Entities;

namespace ScheduleDrawer.Schedule
{
    internal class ScheduleConverter
    {
        public string ConvertScheduleToString(IEnumerable<Match> schedule)
        {
            var stringBuilder = new StringBuilder();
            var groupedSchedule = schedule.ToList().OrderBy(match => match.Round).ToList();

            stringBuilder.AppendLine("Round;Home;Away;Home Goals;Away Goals");
            groupedSchedule.ForEach(match => stringBuilder.AppendLine
                (
                    string.Format("{0};{1};{2};{3};{4}",
                    match.Round,
                    match.Home,
                    match.Away,
                    match.Result != null ? match.Result[0] : null,
                    match.Result != null ? match.Result[1] : null
                    ))
                );

            return stringBuilder.ToString();
        }

        public IEnumerable<Match> ConvertStringToSchedule(string scheduleContent)
        {
            var schedule = new List<Match>();

            scheduleContent.Split(new [] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList().FindAll(s => s != "Round;Home;Away;Home Goals;Away Goals").ForEach(
                text =>
                {
                    var textArray = text.Split(';');
                    schedule.Add(new Match
                                 {
                                     Round = int.Parse(textArray[0]),
                                     Home = textArray[1],
                                     Away = textArray[2],
                                     Result = new int?[]
                                              {
                                                  string.IsNullOrEmpty(textArray[3]) ? (int?) null : int.Parse(textArray[3]), 
                                                  string.IsNullOrEmpty(textArray[4]) ? (int?) null : int.Parse(textArray[4])
                                              }
                                 });
                });

            return schedule;
        }
    }
}
