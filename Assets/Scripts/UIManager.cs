using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private UIExposure uiExposure;
    private GameObject canvasGo;

    public void SetupUIDepedencies()
    {
        //attach procedurally the "UIExposure" class to avoid manually attaching things in the Editor
        //gameObject.AddComponent<UIExposure>();
        uiExposure = gameObject.AddComponent<UIExposure>();


        //find references to buttons... ugh.
        canvasGo = GameObject.FindGameObjectWithTag("Canvas");
        Button button1 = canvasGo.transform.Find("Button (1)").GetComponent<Button>();
        button1.onClick.AddListener(() =>
        {
             uiExposure.Button1();
        });

    }
}
