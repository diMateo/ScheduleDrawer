using ScheduleDrawer.Common;
using ScheduleDrawer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDrawer.DataLayer
{
    public class ScheduleFileService : IScheduleService
    {
        private const string FileNamePattern = "schedule-{0}.csv";

        public void Save(Entities.Schedule schedule)
        {
            CsvFile scheduleFile = new CsvFile();

            CreateHeaders(scheduleFile);
            CreateValues(schedule, scheduleFile);

            FileHelper.WriteFile(string.Format(FileNamePattern, DateTime.Now.ToString("ddMMyyyyHHmmss")), scheduleFile.ToString());

        }

        private static void CreateValues(Entities.Schedule schedule, CsvFile scheduleFile)
        {
            foreach (var match in schedule.Matches)
            {
                CsvLine line = new CsvLine();
                line.Cells.Add(FormatPlayerCell(match.Home));
                line.Cells.Add(FormatPlayerCell(match.Away));
                line.Cells.Add(match.Round.ToString());

                scheduleFile.Lines.Add(line);
            }
        }

        private static string FormatPlayerCell(Entities.Player player)
        {
            return String.Format("{0} ({1})", player.Name, player.Team);
        }

        private static void CreateHeaders(CsvFile scheduleFile)
        {
            scheduleFile.Headers.Names.Add("Home");
            scheduleFile.Headers.Names.Add("Away");
            scheduleFile.Headers.Names.Add("Round");
        }
    }
}
