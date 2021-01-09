namespace CensusCore.Events.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CensusPlayerEvent : Attribute
    {
        public CensusPlayerEventType EventType { get; }

        public CensusPlayerEvent(CensusPlayerEventType type)
        {
            EventType = type;
        }
    }
}