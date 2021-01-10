namespace CensusAPI.Features
{
    using PluginFramework;
    using PluginFramework.Logging;
    using System.Reflection;

    public class Log
    {
        public static Logger Logger => PluginSystem.Manager.Logger;

        public static void Debug(object message, bool should_be_sent = true)
        {
            if (should_be_sent)
            {
                Logger.Debug(Assembly.GetCallingAssembly().GetName().Name, message.ToString());
            }
        }

        public static void Info(object message)
        {
            Logger.Info(Assembly.GetCallingAssembly().GetName().Name, message.ToString());
        }

        public static void Warn(object message)
        {
            Logger.Warn(Assembly.GetCallingAssembly().GetName().Name, message.ToString());
        }

        public static void Error(object message)
        {
            Logger.Error(Assembly.GetCallingAssembly().GetName().Name, message.ToString());
        }
    }
}