using System;
using System.Collections.Generic;
namespace Ps.Utils
{
    public delegate void EventHandler<TEventData>(TEventData data);
    public interface IEventDispatcher<TEvent, TEventData>
    {
        void addEventHandler(TEvent eventType, EventHandler<TEventData> handler);
        void removeEventHandler(TEvent eventType, EventHandler<TEventData> handler);

    }
    public class EventDispatcher<TEvent, TEventData> : IEventDispatcher<TEvent, TEventData>
    {
        Dictionary<TEvent, List<EventHandler<TEventData>>> listeners = new Dictionary<TEvent, List<EventHandler<TEventData>>>();

        public void addEventHandler(TEvent eventType, EventHandler<TEventData> handler)
        {
            if (!listeners.ContainsKey(eventType))
            {
                listeners[eventType] = new List<EventHandler<TEventData>>();
            }
            listeners[eventType].Add(handler);
        }

        public void removeEventHandler(TEvent eventType, EventHandler<TEventData> handler)
        {
            if (!listeners.ContainsKey(eventType))
            {
                listeners[eventType].Remove(handler);
            }
        }

        public void triggerEvent(TEvent eventType, TEventData data)
        {
            if (listeners.ContainsKey(eventType))
            {
                foreach (EventHandler<TEventData> handler in listeners[eventType])
                {
                    handler.Invoke(data);
                }
            }
        }
    }
}