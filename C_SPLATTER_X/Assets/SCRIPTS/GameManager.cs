﻿using UnityEngine;
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
    private float colorChangeTimer;
    public GameObject myCanvas;
    public PhysicsMaterial2D myMaterial;
    public GameObject[] enemy;
    public GameObject player;
    public GameObject[] Platforms;
    private bool isGreenOn;

    public bool GREEN
    {
        get
        {
            return isGreenOn;
        }
    }
    void Awake()
    {
        isGreenOn = false;
        colorChangeTimer = 0.0f;
        menu = GameStates.idle;
        myColor = CurrentColor.white;
        player = GameObject.FindGameObjectWithTag(Tags.player);
        //enemy = GameObject.FindGameObjectsWithTag(Tags.enemy);
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
        colorChangeTimer += Time.deltaTime;
        if(colorChangeTimer >= 20.0f)
        {
            myColor = (CurrentColor)Random.Range(1, 8);
            colorChangeTimer = 0.0f;
        }
        
        switch(myColor)
        {
            case CurrentColor.blue:
                Camera.main.backgroundColor = Color.blue;
                rigidBodiesIncreaseMass();
                DecreaseSpeed();
                RegularKeys();
                VisibleFloor();
                ScaleDown();
                myMaterial.bounciness = 0;
                break;
            case CurrentColor.black:
                Camera.main.backgroundColor = Color.black;
                returnMassToNormal();
                DecreaseSpeed();
                RegularKeys();
                InvisibleFloor();
                ScaleDown();
                myMaterial.bounciness = 0;
                break;
            case CurrentColor.green:
                Camera.main.backgroundColor = Color.green;
                returnMassToNormal();
                DecreaseSpeed();
                RegularKeys();
                VisibleFloor();
                ScaleUp();
                myMaterial.bounciness = 0;
                break;
            case CurrentColor.orange:
                Camera.main.backgroundColor = Color.magenta;
                returnMassToNormal();
                DecreaseSpeed();
                RegularKeys();
                VisibleFloor();
                ScaleDown();
                myMaterial.bounciness = 1;
                break;
            case CurrentColor.purple:
                Camera.main.backgroundColor = Color.cyan;
                returnMassToNormal();
                DecreaseSpeed();
                StickyKeys();
                VisibleFloor();
                ScaleDown();
                myMaterial.bounciness = 0;
                break;
            case CurrentColor.red:
                Camera.main.backgroundColor = Color.red;
                returnMassToNormal();
                IncreaseSpeed();
                RegularKeys();
                VisibleFloor();
                ScaleDown();
                myMaterial.bounciness = 0;
                break;
            case CurrentColor.white:
                Camera.main.backgroundColor = Color.white;
                returnMassToNormal();
                DecreaseSpeed();
                RegularKeys();
                VisibleFloor();
                ScaleDown();
                myMaterial.bounciness = 0;
                break;
            case CurrentColor.yellow:
                Camera.main.backgroundColor = Color.yellow;
                returnMassToNormal();
                DecreaseSpeed();
                RegularKeys();
                VisibleFloor();
                ScaleDown();
                myMaterial.bounciness = 0;
                break;
            default:
                returnMassToNormal();
                DecreaseSpeed();
                RegularKeys();
                VisibleFloor();
                ScaleDown();
                myMaterial.bounciness = 0;
                break;
        }
    }

    public void StartGame()
    {
        menu = GameStates.inPlay;
        myCanvas.SetActive(false);
    }

    void rigidBodiesIncreaseMass()
    {
        enemy = GameObject.FindGameObjectsWithTag(Tags.enemy);
        for(int i = 0; i < enemy.Length; ++i)
        {
            enemy[i].collider2D.rigidbody2D.mass = 1000;
            player.collider2D.rigidbody2D.mass = 1000;
        }
    }

    void returnMassToNormal()
    {
        enemy = GameObject.FindGameObjectsWithTag(Tags.enemy);
        for (int i = 0; i < enemy.Length; ++i)
        {
            enemy[i].collider2D.rigidbody2D.mass = 1;
            player.collider2D.rigidbody2D.mass = 1;
        }
    }

    void IncreaseSpeed()
    {
        enemy = GameObject.FindGameObjectsWithTag(Tags.enemy);
        for(int i = 0; i < enemy.Length; ++i)
        {
            enemy[i].GetComponent<EnemyMove>().SPEED = 4.0f;
            player.GetComponent<PlayerMove>().SPEED = 5.0f;
        }
    }

    void DecreaseSpeed()
    {
        enemy = GameObject.FindGameObjectsWithTag(Tags.enemy);
        for (int i = 0; i < enemy.Length; ++i)
        {
            enemy[i].GetComponent<EnemyMove>().SPEED = 2.0f;
            player.GetComponent<PlayerMove>().SPEED = 2.5f;
        }
    }

    void StickyKeys()
    {
        isGreenOn = true;
    }

    void RegularKeys()
    {
        isGreenOn = false;
    }

    void InvisibleFloor()
    {
        Platforms = GameObject.FindGameObjectsWithTag(Tags.Ground);
        for(int i = 0; i < Platforms.Length; ++i)
        {
            Platforms[i].renderer.enabled = false;
        }
    }

    void VisibleFloor()
    {
        Platforms = GameObject.FindGameObjectsWithTag(Tags.Ground);
        for (int i = 0; i < Platforms.Length; ++i)
        {
            Platforms[i].renderer.enabled = true;
        }
    }

    void ScaleUp()
    {
        enemy = GameObject.FindGameObjectsWithTag(Tags.enemy);
        for (int i = 0; i < enemy.Length; ++i)
        {
            enemy[i].transform.localScale = new Vector2(3.0f, 3.0f);
            player.transform.localScale = new Vector2(3.0f, 3.0f);
        }
    }

    void ScaleDown()
    {
        enemy = GameObject.FindGameObjectsWithTag(Tags.enemy);
        for (int i = 0; i < enemy.Length; ++i)
        {
            enemy[i].transform.localScale = new Vector2(1.0f, 1.0f);
            player.transform.localScale = new Vector2(1.0f, 1.0f);
        }
    }
}
