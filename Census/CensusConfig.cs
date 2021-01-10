namespace CensusCore
{
    using CensusAPI.Interfaces;

    public class CensusConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool DebugMode { get; set; } = false;
    }
}