using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMove : MonoBehaviour 
{
    private bool facingRight;               //is the enemy facing right?
    private float speed;                    //how hast is the enemy?
    private int direction;                  //direction the enemy is looking at
    private Transform myTransform;          //enemy's transform component
    private Transform target;               //the player
    private Vector2 lookBack;               //when enemy to the left
    private Vector2 lookForward;            //when enemy looks to the right
    private int indexLoc;                   //Location index to spawn the next enemy
    private GameObject[] spawnPoints;   //List of spawn points


    void Awake()
    {
        indexLoc = 0;
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
        //SetPosition();
        
	}

    public void SetPosition()
    {
        for(int i = 0; i < spawnPoints.Length; ++i)
        {
            indexLoc++; //= Random.Range(0, spawnPoints.Length);
            myTransform.position = spawnPoints[i].transform.position;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rigidbody2D.velocity = new Vector2(direction * speed, rigidbody2D.velocity.y);          //Use rigidbody2D velocity in order to achieve movement
        float moveAbs = Mathf.Abs(speed);                                                       //Absolute value in order to keep a positive number, this will be used when animating
        
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

}
