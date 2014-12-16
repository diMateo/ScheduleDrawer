using Ninject;
using Ninject.Modules;
using ScheduleDrawer.Common;
using ScheduleDrawer.DataLayer;
using ScheduleDrawer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDrawer
{
    class ScheduleDrawerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPlayerService>().To<PlayerFileService>().WithConstructorArgument(ConfigurationProvider.AllPlayersFilePath);
            Bind<IScheduleService>().To<ScheduleFileService>();
        }
    }
}
