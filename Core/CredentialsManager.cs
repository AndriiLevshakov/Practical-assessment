using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CredentialsManager
    {
        private static IConfigurationRoot config;

        static CredentialsManager()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var relativePath = @"..\..\..\..\Core\credentials.json";
            var fullPath = Path.Combine(basePath, relativePath);
            var builder = new ConfigurationBuilder()
                .AddJsonFile(fullPath);

            config = builder.Build();
        }

        public static string GetName()
        {
            return config.GetSection("AppCredentials")["Name"];
        }

        public static string GetPassword()
        {
            return config.GetSection("AppCredentials")["Password"];
        }
    }
}
