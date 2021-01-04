namespace CensusCore
{
    using CensusAPI.Features;
    using Events;
    using Events.Attributes;
    using PluginFramework.Classes;
    using System;
    using System.Reflection;

    public class CensusCore : Plugin
    {
        public static HarmonyLib.Harmony Harmony { get; private set; }

        public override string Name => "CensusCore";

        public override Version Version => new Version(1, 0, 0);

        public override string Author => "Census Team";

        private static int __reloads = 0;

        public static CensusCore Instance { get; private set; }
        public static CensusWorldEvents WorldEvents { get; private set; }
        public static CensusPlayerEvents PlayerEvents { get; private set; }

        public override void OnDisable()
        {
            base.OnDisable();

            Harmony.UnpatchAll();

            Harmony = null;
        }

        public override void OnEnable()
        {
            base.OnEnable();
            Instance = this;
            WorldEvents = new CensusWorldEvents();
            PlayerEvents = new CensusPlayerEvents();
            Log.Info("Loading CensusCore...");
            Harmony = new HarmonyLib.Harmony("censuscore.instance." + __reloads);
            __reloads++;
            Harmony.PatchAll();
        }

        public static void InjectEvents()
        {
            Log.Debug("Injecting CENSUS events...");
            Assembly assembly = Assembly.GetCallingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetInterface("IScript") == typeof(IScript))
                {
                    foreach (MethodInfo methodInfo in type.GetMethods())
                    {
                        CensusWorldEvent attrib = methodInfo.GetCustomAttribute<CensusWorldEvent>();
                        if (attrib != null)
                        {
                            Log.Info($"Injected CENSUS event: {attrib.EventType:g}");
                            EventInfo @event;
                            string name = attrib.EventType.ToString("g");
                            @event = CensusWorldEvents.Instance.GetType().GetEvent(name + "Event");
                            @event.AddEventHandler(null, Delegate.CreateDelegate(@event.EventHandlerType, methodInfo));
                        }
                        CensusPlayerEvent attrib1 = methodInfo.GetCustomAttribute<CensusPlayerEvent>();
                        if (attrib1 != null)
                        {
                            Log.Info($"Injected CENSUS event: {attrib1.EventType:g}");
                            EventInfo @event;
                            string name = attrib1.EventType.ToString("g");
                            @event = CensusPlayerEvents.Instance.GetType().GetEvent(name + "Event");
                            @event.AddEventHandler(null, Delegate.CreateDelegate(@event.EventHandlerType, methodInfo));
                        }
                    }
                }
            }
        }
    }
}