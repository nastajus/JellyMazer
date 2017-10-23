using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{

    private Dictionary<string, UnityEvent> eventDictionary;

    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    //Utils.LogError("There needs to be one active EventManager script on a GameObject in your scene.");
                    Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }
            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartLisening(string eventName, UnityAction listenerActionFunctionPointer)
    {
        //we need to create a new unity event
        UnityEvent thisEvent = null;    
        //because we want to make sure there is a key-value pair there. normally we'd do a ContainsKey, but not this time.

        //TryGetValue is at least as fast, or faster, than ContainsKey.
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listenerActionFunctionPointer);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listenerActionFunctionPointer);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listenerAction)
    {
        //if we've destroyed or not found our event manager, we want to make sure we don't get a null exception.
        if (eventManager == null) return;

        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listenerAction);
        }
    }

    //we finally need something that's going to *trigger* it
    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            //we'll simply invoke the event.
            // and the function will call *ALL* the functions that are on the listeners that are listening for the event.
            thisEvent.Invoke();
        }
    }
}
