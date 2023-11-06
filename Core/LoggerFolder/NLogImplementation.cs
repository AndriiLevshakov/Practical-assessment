using NLog;
using NLog.Config;
using System;

namespace Core.LoggerFolder
{
    public class NLogImplementation
    {
        private readonly ILogger logger;
        private readonly string nlogConfigRelativePath = @"..\..\..\..\Core\LoggerFolder\nlog.config";

        public NLogImplementation(string name)
        { 
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(basePath, nlogConfigRelativePath);
            NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(fullPath);
            logger = LogManager.GetLogger(name);
        }

        public void Trace(string message)
        {
            logger.Trace(message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Fatal(string message)
        {
            logger.Fatal(message);
        }
    }
}
