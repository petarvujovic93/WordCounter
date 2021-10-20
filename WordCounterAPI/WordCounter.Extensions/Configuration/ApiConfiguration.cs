using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace WordCounter.Extensions.Configuration
{
    public class ApiConfiguration
    {
        private static ApiConfiguration _Instance = null;
        private static IConfiguration _configuration = null;

        private ApiConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static ApiConfiguration Instance(IConfiguration configuration)
        {
            if (_Instance == null)
                _Instance = new ApiConfiguration(configuration);
            return _Instance;
        }

        public static string GetConnectionString(string ConnectionStringName)
        {
            return _configuration.GetConnectionString(ConnectionStringName);
        }

        public static string GetConfigurationItem(string Key)
        {
            return _configuration[Key];
        }

        public static List<string> GetConfigurationList (string sectionName)
        {
            return _configuration.GetSection(sectionName).Get<List<string>>();
        }

    }
}
