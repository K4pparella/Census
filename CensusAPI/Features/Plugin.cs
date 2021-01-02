namespace CensusAPI.Features
{
    using System;

    public abstract class Plugin : PluginFramework.Plugin
    {
        public abstract string Name { get; }

        public virtual string Prefix
        {
            get
            {
                return Name;
            }
        }

        public abstract Version Version { get; }
        public abstract string Author { get; }

        public override void OnEnable()
        {
            Log.Info($"Loading plugin {Name}-{Version} (by {Author})");
        }

        public override void OnDisable()
        {
            Log.Info($"Unloading plugin {Name}-{Version} (by {Author})");
        }
    }
}