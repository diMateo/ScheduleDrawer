using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDrawer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var players = new List<string>
            {
                "Mateusz Wilk",
                "Witold Bulak",
                "Tomasz Chocyk",
                "Adam Kotas",
                "Paweł Podsiadło",
                "Dawid Pilak",
                "Jakub Hutny"
            };

            var scheduleCreator = new ScheduleCreator(players);
            
            PrintSchedule(scheduleCreator.CreateSchedule(true));
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
