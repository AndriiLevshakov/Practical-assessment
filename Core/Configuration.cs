using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Configuration
    {
        public static ConfigModel Model { get; }

        static Configuration()
        {
            Model = new ConfigModel();
            var basePath = AppContext.BaseDirectory;
            var relativePath = @"..\..\..\..\Core\config.json";
            var fullPath = System.IO.Path.Combine(basePath, relativePath);

            new ConfigurationBuilder()
                .AddJsonFile(fullPath)
                .Build()
                .Bind(Model);
        }
    }
}
