using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerTester : MonoBehaviour {

    public void TestEventTrigger()
    {
        EventManager.TriggerEvent("test");
    }
    
}
