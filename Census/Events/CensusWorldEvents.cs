namespace CensusCore.Events
{
    using CensusAPI.Features;
    using System;
    using VirtualBrightPlayz.SCP_ET;
    using VirtualBrightPlayz.SCP_ET.Player;
    public class CensusWorldEvents
    {
        public CensusWorldEvents()
        {
            Instance = this;
        }

        public static CensusWorldEvents Instance { get; private set; }

    }
}