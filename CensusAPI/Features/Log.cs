namespace CensusAPI.Features
{
    using PluginFramework;
    using PluginFramework.Logging;
    using System.Reflection;
    public class Log
    {
        public static Logger Logger => PluginSystem.Manager.Logger;
        public static void Debug(string message, bool should_be_sent)
        {
            if (should_be_sent)
            {
                Logger.Debug(Assembly.GetCallingAssembly().GetName().Name, message);
            }
        }
        public static void Info(string message)
        {
            Logger.Info(Assembly.GetCallingAssembly().GetName().Name, message);
        }
        public static void Warn(string message)
        {
            Logger.Warn(Assembly.GetCallingAssembly().GetName().Name, message);
        }
        public static void Error(string message)
        {
            Logger.Error(Assembly.GetCallingAssembly().GetName().Name, message);
        }
    }
}
