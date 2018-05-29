using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataGenerator
{
    public static class Configurations
    {
        public static string Storage
        {
            get
            {
                var result = ConfigurationManager.AppSettings["DataFile"];
                if (string.IsNullOrEmpty(result))
                {
                    return Helpers.DataStorage;
                }
                return result;
            }
        }

        public static int NumberOfInstances
        {
            get
            {
                var result = 0;
                if (!int.TryParse(ConfigurationManager.AppSettings["NumberOfInstances"], out result))
                {
                    result = 100;
                }
                return result;
            }
        }
    }
}
