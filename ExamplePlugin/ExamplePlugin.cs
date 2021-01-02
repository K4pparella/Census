using System;

namespace ExamplePlugin
{
    public class ExamplePlugin : CensusAPI.Features.Plugin
    {
        public override string Name => "ExamplePlugin";

        public override string Prefix => Name;
        public override Version Version => new Version(1, 0, 0);

        public override string Author => "Census Team";

        public override void OnDisable()
        {
            base.OnDisable();
        }

        public override void OnEnable()
        {
            base.OnEnable();
            CensusCore.CensusCore.InjectEvents();
        }
    }
}