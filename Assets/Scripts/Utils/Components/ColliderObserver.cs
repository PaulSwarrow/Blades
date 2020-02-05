using UnityEngine;
using System.Collections.Generic;
using Ps.Utils;
using System;

public class ColliderObserver : MonoBehaviour, IEventDispatcher<ColliderObserver.ColliderEvent, Collision>
{
    //data:
    public enum ColliderEvent {  enter, stay, exit  }

    EventDispatcher<ColliderEvent, Collision> dispatcher = new EventDispatcher<ColliderEvent, Collision>();

    // events:
    void OnCollisionEnter(Collision collision)
    {
        dispatcher.triggerEvent(ColliderEvent.enter, collision);
    }
    void OnCollisionStay(Collision collision)
    {
        dispatcher.triggerEvent(ColliderEvent.stay, collision);
    }
    void OnCollisionExit(Collision collision)
    {
        dispatcher.triggerEvent(ColliderEvent.exit, collision);
    }
     
    //interface:
    public void addEventHandler(ColliderEvent eventType, Ps.Utils.EventHandler<Collision> handler)
    {
        dispatcher.addEventHandler(eventType, handler);
    }

    public void removeEventHandler(ColliderEvent eventType, Ps.Utils.EventHandler<Collision> handler)
    {
        dispatcher.removeEventHandler(eventType, handler);
    }
}