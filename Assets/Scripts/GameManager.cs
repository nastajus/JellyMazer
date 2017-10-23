using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;      //static instance of game maanager which allows it be accessed by another script.
    private BoardManager boardManager;
    private GamepadManager gamepadManager;
    private EventManager eventManager;
    private UIManager uiManager;
    private int level = 0;

	void Awake () {
		//Check if instance already exists
	    if (instance == null)
	    {
	        //if not, set instance to this
	        instance = this;
	    }

        //If instance already exists and it's not this: 
        else if (instance != this)
	    {
	        //Then destroy this. This enfources our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
	    }

        //Sets this to not be destoryed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Add a component reference by attaching BoardManager script
	    boardManager = gameObject.AddComponent<BoardManager>();

        //Call the InitGame function to initialize the first level
	    InitGame();

	}

    void InitGame()
    {
        boardManager.SetupScene(level);

        eventManager = gameObject.AddComponent<EventManager>();

        gamepadManager = gameObject.AddComponent<GamepadManager>();

        uiManager = gameObject.AddComponent<UIManager>();

        uiManager.SetupUIDepedencies();

    }

}
