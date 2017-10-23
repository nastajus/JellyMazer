using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamepadManager : MonoBehaviour
{

    private UnityAction someListenerAction;

	// Use this for initialization
    /*
	void Start ()
	{
	    DetectGamepads();
	}
    */

    void Awake()
    {
        someListenerAction = new UnityAction(SomeFunction);
    }


    void OnEnable()
    {
        EventManager.StartLisening("test", someListenerAction);
        //DetectGamepads();
    }

    //OnDisable is necessary to manage properly memory and thus avoid memory leaks
    void OnDisable()
    {
        EventManager.StopListening("test", someListenerAction);
    }

    static void DetectGamepads()
    {
        
    }

    void SomeFunction()
    {
        Debug.Log("Some Function was called!");
    }
}
