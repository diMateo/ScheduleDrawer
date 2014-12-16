using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleDrawer.Csv;
using ScheduleDrawer.Entities;
using ScheduleDrawer.Schedule;

namespace ScheduleDrawer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var players = new List<string>
            {
                "Mateusz W",
                "Witold B",
                "Tomasz Ch",
                "Adam K",
                "Paweł P",
                "Dawid P",
                "Jakub H"
            };

            var scheduleManager = new ScheduleManager();

            var scheduleList = scheduleManager.CreateSchedule(players, true);
            scheduleManager.SaveScheduleToCsv("SuperLeague", scheduleList);

            PrintSchedule(scheduleList);
        }

        private static void PrintSchedule(IEnumerable<Match> scheduleList)
        {
            if (scheduleList == null)
            {
                return;
            }

            foreach (var round in scheduleList.Select(x => x.Round).Distinct())
            {
                Console.WriteLine(string.Format("*** ROUND {0} ***", round));
                Console.WriteLine();

                foreach (var matchInfo in scheduleList.Where(x => x.Round == round))
                {
                    Console.WriteLine(string.Format("{0} - {1}", matchInfo.Home, matchInfo.Away));
                }

                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
