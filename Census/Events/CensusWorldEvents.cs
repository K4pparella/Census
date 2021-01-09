namespace CensusCore.Events
{
    public class CensusWorldEvents
    {
        public CensusWorldEvents()
        {
            Instance = this;
        }

        public static CensusWorldEvents Instance { get; private set; }
    }
}