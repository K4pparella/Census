namespace CensusAPI.Features
{
    using global::CensusAPI.Interfaces;
    using System;
    using System.IO;
    using Newtonsoft.Json;
    public abstract class Plugin<T>: PluginFramework.Plugin where T : IConfig, new()
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
        public T Config { get; private set; }
        public override void OnEnable()
        {
            Log.Info($"Loading plugin {Name}-{Version} (by {Author})");
            if (!Directory.Exists(Paths.ConfigDir))
            {
                Directory.CreateDirectory(Paths.ConfigDir);
            }
            string cfg_path = Path.Combine(Paths.ConfigDir, Prefix+".json");
            if (!File.Exists(cfg_path))
            {
                Log.Info($"Creating default config file...");
                Config = new T();
                StreamWriter sw = File.CreateText(cfg_path);
                sw.Write(JsonConvert.SerializeObject(Config));
                sw.Close();
            }
            else
            {
                try
                {
                    StreamReader sr = File.OpenText(cfg_path);
                    Config = JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
                    sr.Close();
                }
                catch (Exception e)
                {
                    Log.Warn($"Failed to parse config: {e}, falling back to default values");
                    Config = new T();
                }
            }
            if (!Config.IsEnabled)
            {
                Log.Info($"Plugin {Name} is disabled!");
            }
            else
            {
                Enable();
            }
        }

        public override void OnDisable()
        {
            Log.Info($"Unloading plugin {Name}-{Version} (by {Author})");
            Disable();
        }

        public abstract void Enable();
        public abstract void Disable();
    }
}