namespace CensusAPI.Features
{
    using System;
    public abstract class Plugin : PluginFramework.Plugin
    {
        public abstract string Name { get; }
        public abstract string Prefix { get; }
        public abstract Version Version { get; }
        public abstract string Author { get; }
        public override void OnEnable()
        {
            Log.Info($"Plugin {Name}-{Version} (by {Author}) loaded!");
        }
        public override void OnDisable()
        {
            Log.Info($"Plugin {Name}-{Version} (by {Author}) unloaded!");
        }
    }
}
