namespace ExamplePlugin
{
    using System;
    using CensusAPI.Features;
    public class ExamplePlugin : CensusAPI.Features.Plugin<ExampleConfig>
    {
        public override string Name => "ExamplePlugin";

        public override string Prefix => Name;
        public override Version Version => new Version(1, 0, 0);

        public override string Author => "Census Team";
        public static ExamplePlugin Instance { get; private set; }

        public override void Disable()
        {
            Instance = null;
        }

        public override void Enable()
        {
            Instance = this;
            CensusCore.CensusCore.InjectEvents();
            Log.Info($"Parsed value: {Config.SomeValue}");
        }
    }
}