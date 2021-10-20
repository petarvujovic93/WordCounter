using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordCounter.Common.Configuration
{
    
    public class WebConfiguration
    {
        private static WebConfiguration _Instance = null;
        private static IConfiguration _configuration = null;

        private WebConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static WebConfiguration Instance(IConfiguration configuration)
        {
            if (_Instance == null)
                _Instance = new WebConfiguration(configuration);
            return _Instance;
        }
        public static string GetConfigurationItem(string Key)
        {
            return _configuration[Key];
        }

        public static string GetApiUrl() { return GetConfigurationItem("ApiUrl"); }
    }
}
