using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//purpose: expose methods to attach manually to in Editor to Button OnClick() 
//aka: have a one-to-one mapping of methods here to buttons in UI screen.
public class UIExposure : MonoBehaviour
{

    public void Button1()
    {
        Debug.Log("Yo");
        EventManager.TriggerEvent("test");
    }

    public void Button2()
    {

    }

    public void Button3()
    {
        
    }
}
