namespace CensusCore.Events.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CensusWorldEvent : Attribute
    {
        public CensusWorldEventType EventType { get; }

        public CensusWorldEvent(CensusWorldEventType type)
        {
            EventType = type;
        }
    }
}
