using System;

namespace ExamplePlugin
{
    public class ExamplePlugin : CensusAPI.Features.Plugin<ExampleConfig>
    {
        public override string Name => "ExamplePlugin";

        public override string Prefix => Name;
        public override Version Version => new Version(1, 0, 0);

        public override string Author => "Census Team";

        public override void Disable()
        {
        }

        public override void Enable()
        {
            CensusCore.CensusCore.InjectEvents();
        }
    }
}