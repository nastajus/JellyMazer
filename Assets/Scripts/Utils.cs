using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

    public static void Log(object message)
    {
        //notify UI messaging

        //output to traditional unity debug log
        Debug.Log(message);
    }

    public static void LogError(object message)
    {
        //notify UI messaging

        //output to traditional unity debug log
        Debug.LogError(message);
    }
}
