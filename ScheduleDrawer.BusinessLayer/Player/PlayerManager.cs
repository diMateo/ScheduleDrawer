using ScheduleDrawer.Entities;
using ScheduleDrawer.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDrawer.BusinessLayer
{
    public class PlayerManager
    {
        private IPlayerService _playerService;
       
        public PlayerManager(IPlayerService playerService)
        {
            if(playerService == null)
            {
                throw new ArgumentNullException("playerService", "Parameter 'playerService' cannot be null or empty");
            }

            _playerService = playerService;
        }


        public IList<Player> GetAll()
        {
            return _playerService.GetAll();
        }
    }
}
