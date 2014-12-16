using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleDrawer.Entities;

namespace ScheduleDrawer.Schedule
{
    internal class ScheduleCreator
    {
        private List<string> _players;

        public IEnumerable<Match> CreateSchedule(IEnumerable<string> players, bool revangeRound)
        {
            _players = DrawPlayersOrder(players).ToList();
            var allCombinations = CreateAllCombinations();
            var scheduleWithoutRevange = DrawSchedule(allCombinations);

            return revangeRound ? AddRevangeRounds(scheduleWithoutRevange) : scheduleWithoutRevange;
        }

        private IEnumerable<string> DrawPlayersOrder(IEnumerable<string> players)
        {
            var allPlayers = players.ToList();

            if (allPlayers.Count % 2 > 0)
            {
                allPlayers.Add(string.Empty);
            }

            var playersInOrder = new List<string>();
            var seed = (int)DateTime.Now.Ticks;
            var rand = new Random(seed);

            for (var i = allPlayers.Count; i > 0; i--)
            {
                var number = rand.Next(i);
                playersInOrder.Add(allPlayers[number]);
                allPlayers.RemoveAt(number);
            }

            return playersInOrder;
        }

        private IEnumerable<Match> CreateAllCombinations()
        {
            for (var i = 0; i < _players.Count; i++)
            {
                for (var j = i + 1; j < _players.Count; j++)
                {
                    yield return new Match
                                 {
                                     Home = _players[i],
                                     Away = _players[j]
                                 };
                }
            }
        }

        private IEnumerable<Match> DrawSchedule(IEnumerable<Match> allCombinations)
        {
            var combinations = allCombinations.ToList();
            var schedule = new List<Match>();
            var seed = (int)DateTime.Now.Ticks;
            var rand = new Random(seed);
            var round = 1;

            while (combinations.Count != 0)
            {
                var combinationsPerRound = new List<Match>(combinations);

                while (combinationsPerRound.Count != 0)
                {
                    var number = rand.Next(combinationsPerRound.Count);
                    var match = combinationsPerRound[number];
                    match.Round = round;

                    schedule.Add(match);
                    combinationsPerRound.RemoveAll(c => c.Home == match.Home || c.Home == match.Away || c.Away == match.Home || c.Away == match.Away);
                    combinations.RemoveAll(c => c.Home == match.Home && c.Away == match.Away);
                }

                if (schedule.Count(m => m.Round == round) != _players.Count/2)
                {
                    combinations = allCombinations.ToList();
                    schedule = new List<Match>();
                    round = 1;
                }
                else
                {
                    round++;
                }
            }

            return schedule.OrderBy(m => m.Round).Where(m => !string.IsNullOrEmpty(m.Home) && !string.IsNullOrEmpty(m.Away));
        }

        private IEnumerable<Match> AddRevangeRounds(IEnumerable<Match> scheduleWithoutRevange)
        {
            var maxRound = scheduleWithoutRevange.Max(m => m.Round);
            var scheduleWithRevange = new List<Match>(scheduleWithoutRevange);

            foreach (var match in scheduleWithoutRevange)
            {
                scheduleWithRevange.Add(new Match
                                        {
                                            Home = match.Away,
                                            Away = match.Home,
                                            Round = match.Round + maxRound
                                        });
            }

            return scheduleWithRevange;
        }
    }
}
