using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrimThisText.Console.Configuration
{
    public static class AppConfiguration
    {
        public static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables() 
                .Build();
        }

        public static T GetOptions<T>(IConfiguration configuration, string sectionName) where T : class, new()
        {
            T options = new();
            configuration.GetSection(sectionName).Bind(options);
            return options;
        }
    }
}
