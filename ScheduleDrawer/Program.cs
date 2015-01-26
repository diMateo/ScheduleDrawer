using Ninject;
using ScheduleDrawer.BusinessLayer;
using ScheduleDrawer.BusinessLayer.Schedule;
using ScheduleDrawer.Entities;
using ScheduleDrawer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace ScheduleDrawer
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                IKernel kernel = new StandardKernel(new ScheduleDrawerModule());
                
                var playerManager = new PlayerManager(kernel.Get<IPlayerService>());
                var players = playerManager.GetAll();

                var scheduleCreator = new ScheduleCreator(players);
                var scheduleManager = new ScheduleManager(scheduleCreator, kernel.Get<IScheduleService>());

                var schedule = scheduleManager.Create(true);

                PrintSchedules(schedule.Matches);
                scheduleManager.Save(schedule);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("{0} {1}", "There was an error during the program execution.", e.Message));
            }

            Console.ReadKey();
            
        }

        

        private static void PrintSchedules(IEnumerable<Match> scheduleList)
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
                    Console.WriteLine(string.Format("{0} - {1}", matchInfo.Home.Name, matchInfo.Away.Name));
                }

                Console.WriteLine();
                Console.WriteLine();
            }

        }

    }
}
