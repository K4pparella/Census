namespace ExamplePlugin
{
    using CensusAPI.Interfaces;

    public class ExampleConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public int SomeValue { get; set; } = 12345;
    }
}