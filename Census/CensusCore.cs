namespace CensusCore
{
    using PluginFramework;
    using CensusAPI.Features;
    using System;

    public class CensusCore : CensusAPI.Features.Plugin
    {

        public static HarmonyLib.Harmony Harmony { get; private set; }

        public override string Name => "CensusCore";

        public override string Prefix => Name;

        public override Version Version => new Version(1,0,0);

        public override string Author => "Census Team";

        private static int __reloads = 0;

        private EventHandlers evs;

        public override void OnDisable()
        {
            base.OnDisable();

            Harmony.UnpatchAll();

            Harmony = null;
        }

        public override void OnEnable()
        {
            base.OnEnable();
            Log.Info("Loading CensusCore...");
            Harmony = new HarmonyLib.Harmony("censuscore.instance."+__reloads);
            __reloads++;
            Harmony.PatchAll();

            evs = new EventHandlers();

           // PluginSystem.PlayerJoinFinalEvent. evs.OnPlayerJoined;
        }
    }
}
