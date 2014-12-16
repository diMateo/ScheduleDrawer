using System.Collections.Generic;
using ScheduleDrawer.Entities;

namespace ScheduleDrawerTests.TestObjects
{
    internal static class ScheduleObjects
    {
        public static IEnumerable<Match> ScheduleTest
        {
            get
            {
                return new List<Match>
                    {
                        new Match
                        {
                            Home = "Player_01",
                            Away = "Player_02",
                            Round = 1,
                            Result = new int?[] { 1, 0 }
                        },
                        new Match
                        {
                            Home = "Player_03",
                            Away = "Player_04",
                            Round = 1,
                            Result = new int?[] { 2, 2 }
                        },
                        new Match
                        {
                            Home = "Player_02",
                            Away = "Player_03",
                            Round = 2,
                            Result = new int?[] { null, null }
                        },
                        new Match
                        {
                            Home = "Player_04",
                            Away = "Player_01",
                            Round = 2,
                            Result = new int?[] { null, null }
                        }
                    };
            }
            private set { }
        }
    }
}
