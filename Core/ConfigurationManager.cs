using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ConfigurationManager
    {
        private static IConfigurationRoot config;

        static ConfigurationManager()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var relarivePath = @"..\..\..\..\Core\urls.json";
            var fullPath = Path.Combine(basePath, relarivePath);
            var builder = new ConfigurationBuilder()
                .AddJsonFile(fullPath);

            config = builder.Build();
        }

        public static string GetLoginPageUrl()
        {
            string currentDirectory = Environment.CurrentDirectory;
            Console.WriteLine($"Current directory: {currentDirectory}");

            return config.GetSection("AppSettings")["LoginPageUrl"];
        }


    }
}
