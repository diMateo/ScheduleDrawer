using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDrawer.Common
{
    public static class ConfigurationProvider
    {
        public static string AllPlayersFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["AllPlayersFilePath"].ToString();
            }
        }
    }
}
