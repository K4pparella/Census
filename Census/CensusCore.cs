namespace CensusCore
{
    using PluginFramework;
    using CensusAPI.Features;
    using System;

    public class CensusCore : CensusAPI.Features.Plugin
    {

        public static HarmonyLib.Harmony Harmony { get; private set; }

        public override string Name => "CensusCore";

        public override Version Version => new Version(1,0,0);

        public override string Author => "Census Team";

        private static int __reloads = 0;

        public static CensusCore Instance { get; private set; }

        public override void OnDisable()
        {
            Harmony.UnpatchAll();

            Harmony = null;

            base.OnDisable();
        }

        public override void OnEnable()
        {
            Instance = this;
            Log.Info("Loading CensusCore...");
            Harmony = new HarmonyLib.Harmony("censuscore.instance."+__reloads);
            __reloads++;
            Harmony.PatchAll();
            base.OnEnable();
        }
    }
}
