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
    public Object[] myPlayList;
    public Text scoreText;
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

    private int score;
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

    public int SCORE
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
    void Awake()
    {
        isGreenOn = false;
        colorChangeTimer = 0.0f;
        menu = GameStates.idle;
        myColor = CurrentColor.white;
        player = GameObject.FindGameObjectWithTag(Tags.player);
        myPlayList = Resources.LoadAll("MUSIC", typeof(AudioClip));
        GetComponent<AudioSource>().clip = myPlayList[0] as AudioClip;
        score = 0;
        //enemy = GameObject.FindGameObjectsWithTag(Tags.enemy);
    }

	// Update is called once per frame
	void Update () 
    {
        UpdateStates();
        UpdateColors();
        UpdateScore();
	}

    void UpdateScore()
    {
        scoreText.text = "SCORE " + score;
    }

    void PlayBlueMusic()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = myPlayList[1] as AudioClip;
            //Debug.Break();
            GetComponent<AudioSource>().Play();
        }
    }

    void PlayRedMusic()
    {
        if(!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = myPlayList[5] as AudioClip;
            GetComponent<AudioSource>().Play();
        }
    }

    void PlayBlackMusic()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = myPlayList[0] as AudioClip;
            GetComponent<AudioSource>().Play();
        }
    }

    void PlayGreenMusic()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = myPlayList[2] as AudioClip;
            GetComponent<AudioSource>().Play();
        }
    }

    void PlayOrangeMusic()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = myPlayList[3] as AudioClip;
            GetComponent<AudioSource>().Play();
        }
    }

    void PlayPurpleMusic()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = myPlayList[4] as AudioClip;
            GetComponent<AudioSource>().Play();
        }
    }

    void PlayWhiteMusic()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = myPlayList[6] as AudioClip;
            GetComponent<AudioSource>().Play();
        }
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
                PlayBlueMusic();
                myMaterial.bounciness = 0;
                break;
            case CurrentColor.black:
                Camera.main.backgroundColor = Color.black;
                returnMassToNormal();
                DecreaseSpeed();
                RegularKeys();
                InvisibleFloor();
                ScaleDown();
                PlayBlackMusic();
                myMaterial.bounciness = 0;
                break;
            case CurrentColor.green:
                Camera.main.backgroundColor = Color.green;
                returnMassToNormal();
                DecreaseSpeed();
                RegularKeys();
                VisibleFloor();
                ScaleUp();
                PlayGreenMusic();
                myMaterial.bounciness = 0;
                break;
            case CurrentColor.orange:
                Camera.main.backgroundColor = Color.magenta;
                returnMassToNormal();
                DecreaseSpeed();
                RegularKeys();
                VisibleFloor();
                ScaleDown();
                PlayOrangeMusic();
                myMaterial.bounciness = 1;
                break;
            case CurrentColor.purple:
                Camera.main.backgroundColor = Color.cyan;
                returnMassToNormal();
                DecreaseSpeed();
                StickyKeys();
                VisibleFloor();
                ScaleDown();
                PlayPurpleMusic();
                myMaterial.bounciness = 0;
                break;
            case CurrentColor.red:
                Camera.main.backgroundColor = Color.red;
                returnMassToNormal();
                IncreaseSpeed();
                RegularKeys();
                VisibleFloor();
                ScaleDown();
                PlayRedMusic();
                myMaterial.bounciness = 0;
                break;
            case CurrentColor.white:
                Camera.main.backgroundColor = Color.white;
                returnMassToNormal();
                DecreaseSpeed();
                RegularKeys();
                VisibleFloor();
                ScaleDown();
                PlayWhiteMusic();
                myMaterial.bounciness = 0;
                break;
            case CurrentColor.yellow:
                Camera.main.backgroundColor = Color.yellow;
                returnMassToNormal();
                DecreaseSpeed();
                RegularKeys();
                VisibleFloor();
                ScaleDown();
                PlayRedMusic();
                myMaterial.bounciness = 0;
                break;
            default:
                returnMassToNormal();
                DecreaseSpeed();
                RegularKeys();
                VisibleFloor();
                ScaleDown();
                PlayBlackMusic();
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
            enemy[i].GetComponent<Collider2D>().GetComponent<Rigidbody2D>().mass = 1000;
            player.GetComponent<Collider2D>().GetComponent<Rigidbody2D>().mass = 1000;
        }
    }

    void returnMassToNormal()
    {
        enemy = GameObject.FindGameObjectsWithTag(Tags.enemy);
        for (int i = 0; i < enemy.Length; ++i)
        {
            enemy[i].GetComponent<Collider2D>().GetComponent<Rigidbody2D>().mass = 1;
            player.GetComponent<Collider2D>().GetComponent<Rigidbody2D>().mass = 1;
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
            Platforms[i].GetComponent<Renderer>().enabled = false;
        }
    }

    void VisibleFloor()
    {
        Platforms = GameObject.FindGameObjectsWithTag(Tags.Ground);
        for (int i = 0; i < Platforms.Length; ++i)
        {
            Platforms[i].GetComponent<Renderer>().enabled = true;
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

    public void ReloadLevel()
    {
        Application.LoadLevel("main");
    }
}
