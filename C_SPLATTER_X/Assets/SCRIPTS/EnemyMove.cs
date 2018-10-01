using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMove : MonoBehaviour 
{
    private Animator anim;
    private bool inRange;                   //is the enemy in attack range?
    private bool facingRight;               //is the enemy facing right?
    private float speed;                    //how hast is the enemy?
    private int direction;                  //direction the enemy is looking at
    private Transform myTransform;          //enemy's transform component
    private Transform target;               //the player
    private Vector2 lookBack;               //when enemy to the left
    private Vector2 lookForward;            //when enemy looks to the right
    private int indexLoc;                   //Location index to spawn the next enemy
    private int health;
    private GameObject[] spawnPoints;   //List of spawn points
    private GameManager myManager;


    public int HEALTH
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

        public float SPEED
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }

    void Awake()
    {
        myManager = GameObject.FindGameObjectWithTag(Tags.GameManager).GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        inRange = false;
        indexLoc = 0;
        health = 2;
        spawnPoints = GameObject.FindGameObjectsWithTag(Tags.EnemySpawner);
        target = GameObject.FindGameObjectWithTag(Tags.player).transform;   //find the player
        myTransform = transform;                                            //initialize the enemy transform component
        speed = 2.0f;                                                       //initialize the speed
        direction = 1;                                                      //direction 1 means right, direction -1 means left
        facingRight = true;                                                 //enemy starts facing right
        lookBack = new Vector2(0.0f, 180.0f);                               //when enemy is looking at the left side of the screen, he will be rotated 180 degrees
        lookForward = Vector2.zero;                                         //When enemy looks at the right side of the screen, he will be put in it normal rotation
    }

	// Update is called once per frame
	void Update () 
    {
        Flip();
        PlayerAttack();
        CheckDeath();
        print(inRange);
	}

    public void SetPosition()
    {
        for(int i = 0; i < spawnPoints.Length; ++i)
        {
            indexLoc = Random.Range(0, spawnPoints.Length);
            myTransform.position = spawnPoints[indexLoc].transform.position;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void PlayerAttack()
    {
        if(inRange && Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("WE ARE ATTACKING");
            health--;
        }
    }

    void CheckDeath()
    {
        if(health <= 0)
        {
            inRange = false;
            myManager.SCORE += 100;
            this.gameObject.SetActive(false);
        }
    }

    void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction * speed, GetComponent<Rigidbody2D>().velocity.y);          //Use rigidbody2D velocity in order to achieve movement
        float moveAbs = Mathf.Abs(speed);                                                       //Absolute value in order to keep a positive number, this will be used when animating
        anim.SetFloat("speed", moveAbs);
        //Check when to turn towards the character. Such check is baed in position distance.
        if(target.position.x < myTransform.position.x - 2)                                      
        {
            facingRight = false;
        }
        else if(target.position.x > myTransform.position.x + 2)
        {
            facingRight = true;
        }
    }


    //Flip function will allow the enemy to rotate towards the player when the conditions are met
    void Flip()
    {
        if(facingRight)
        {
            myTransform.rotation = Quaternion.Euler(lookForward);
            direction = 1;
        }
        else if(!facingRight)
        {
            myTransform.rotation = Quaternion.Euler(lookBack);
            direction = -1;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == Tags.death)
        {
            this.gameObject.SetActive(false);
        }
        if(col.gameObject.tag == Tags.player)
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == Tags.player)
        {
            inRange = false;
        }
    }
    /*
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == Tags.player)
        {
            inRange = true;
        }
    }
     * */
}
