using ScheduleDrawer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDrawer.BusinessLayer
{
    public class ScheduleCreator
    {
        private readonly List<Player> _players; 

        public ScheduleCreator(IEnumerable<Player> players)
        {
            if(players == null)
            {
                throw new ArgumentNullException("players", "Parameter 'players' cannot be null");
            }
            _players = DrawPlayersOrder(players).ToList();
        }

        public Entities.Schedule Create(bool revengeRound)
        {
            var schedule = new Entities.Schedule();
            var matches = CreateScheduleMatches(revengeRound);
            
            foreach(var match in matches)
            {
                schedule.Matches.Add(match);
            }

            return schedule;
        }

        public IEnumerable<Match> CreateScheduleMatches(bool revengeRound)
        {
            var allCombinations = CreateAllCombinations();
            var scheduleWithoutrevenge = DrawSchedule(allCombinations);

            return revengeRound ? AddrevengeRounds(scheduleWithoutrevenge) : scheduleWithoutrevenge;
        }

        private static IEnumerable<Player> DrawPlayersOrder(IEnumerable<Player> players)
        {
            var allPlayers = players.ToList();

            if (allPlayers.Count % 2 > 0)
            {
                allPlayers.Add(new Player());
            }

            var playersInOrder = new List<Player>();
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

            return schedule.OrderBy(m => m.Round).Where(m => m.Home != null && m.Away != null);
        }

        private static IEnumerable<Match> AddrevengeRounds(IEnumerable<Match> scheduleWithoutrevenge)
        {
            var maxRound = scheduleWithoutrevenge.Max(m => m.Round);
            var scheduleWithrevenge = new List<Match>(scheduleWithoutrevenge);

            foreach (var match in scheduleWithoutrevenge)
            {
                scheduleWithrevenge.Add(new Match
                                        {
                                            Home = match.Away,
                                            Away = match.Home,
                                            Round = match.Round + maxRound
                                        });
            }

            return scheduleWithrevenge;
        }
    }
}
