using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    //This manager controls:
    //Colour changes 
    //Amount of Enemies
    //Music
    //Menu

    //this enmum will be used to control the main menu
    private enum GameStates
    {
        idle = 1,
        inPlay
    };
    
    //Enum to control the different states of the game while in play.
    //This will be done using a switch statement
    private enum CurrentColor
    {
        blue = 1,
        red,
        green,
        orange,
        purple,
        black,
        white,
        yellow
    };

    private GameStates menu;
    private CurrentColor myColor;
    public GameObject myCanvas;

    void Awake()
    {
        menu = GameStates.idle;
        myColor = CurrentColor.white;
    }

	// Update is called once per frame
	void Update () 
    {
        UpdateStates();
        UpdateColors();
	}

    void UpdateStates()
    {
        switch(menu)
        {
            case GameStates.idle:
                Time.timeScale = 0;
                break;
            case GameStates.inPlay:
                Time.timeScale = 1;
                break;
            default:
                break;
        }
    }

    void UpdateColors()
    {
        switch(myColor)
        {
            case CurrentColor.blue:
                Camera.main.backgroundColor = Color.blue;
                break;
            case CurrentColor.black:
                Camera.main.backgroundColor = Color.black;
                break;
            case CurrentColor.green:
                Camera.main.backgroundColor = Color.green;
                break;
            case CurrentColor.orange:
                Camera.main.backgroundColor = Color.magenta;
                break;
            case CurrentColor.purple:
                Camera.main.backgroundColor = Color.cyan;
                break;
            case CurrentColor.red:
                Camera.main.backgroundColor = Color.red;
                break;
            case CurrentColor.white:
                Camera.main.backgroundColor = Color.white;
                break;
            case CurrentColor.yellow:
                Camera.main.backgroundColor = Color.yellow;
                break;
            default:
                break;
        }
    }

    public void StartGame()
    {
        menu = GameStates.inPlay;
        myCanvas.SetActive(false);
    }
}
