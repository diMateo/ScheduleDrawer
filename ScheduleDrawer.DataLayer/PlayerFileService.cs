using ScheduleDrawer.Common;
using ScheduleDrawer.Entities;
using ScheduleDrawer.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDrawer.DataLayer
{
    public class PlayerFileService : IPlayerService
    {
        private string _allPlayersFilePath;

        public PlayerFileService(string allPlayersFilePath)
        {
            if (string.IsNullOrWhiteSpace(allPlayersFilePath))
            {
                throw new ArgumentNullException("allPlayersFilePath", "Parameter 'allPlayersFilePath' cannot be null or empty");
            }

            _allPlayersFilePath = allPlayersFilePath;
        }

        public IList<Entities.Player> GetAll()
        {
            return ReadPlayersFromFile(_allPlayersFilePath).ToList();
        }

        private static IEnumerable<Player> ReadPlayersFromFile(string playersCsvFile)
        {
            List<Player> players = null;
            string fileContent = File.ReadAllText(playersCsvFile);

            CsvFile csvFile = new CsvFile(fileContent);

            if (csvFile.Lines.Any())
            {
                players = ReadPlayers(csvFile.Lines);
            }

            return players;

        }

        private static List<Player> ReadPlayers(IEnumerable<CsvLine> lines)
        {
            List<Player> players = new List<Player>();

            foreach (var line in lines)
            {
                players.Add(ReadPlayer(line));
            }
            
            return players;
        }

        private static Player ReadPlayer(CsvLine line)
        {
            var cells = line.Cells.ToArray();
            return new Player 
                        {
                            Name = cells[0],
                            Team = cells[1] 
                        };

        }
    }
}
