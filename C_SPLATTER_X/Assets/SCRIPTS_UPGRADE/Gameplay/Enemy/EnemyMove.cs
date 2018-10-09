using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMove : MonoBehaviour 
{
    private Animator _anim;
    private int _moveHash = Animator.StringToHash("speed");
    private bool _facingRight;                               //is the enemy facing right?
    [SerializeField] private FloatVariable _speed;           //how hast is the enemy?
    private int _direction;                                  //direction the enemy is looking at
    private Transform _myTransform;                          //enemy's transform component
    private Transform _target;                               //the player
    private Vector2 _lookBack;                               //when enemy to the left
    private Vector2 _lookForward;                            //when enemy looks to the right
    private int _indexLoc;                                   //Location index to spawn the next enemy
    private GameObject[] _spawnPoints;                       //List of spawn points
    

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _indexLoc = 0;
        _spawnPoints = GameObject.FindGameObjectsWithTag(Tags.EnemySpawner);
        _target = GameObject.FindGameObjectWithTag(Tags.player).transform;   //find the player
        _myTransform = transform;                                            //initialize the enemy transform component
        _direction = 1;                                                      //direction 1 means right, direction -1 means left
        _facingRight = true;                                                 //enemy starts facing right
        _lookBack = new Vector2(0.0f, 180.0f);                               //when enemy is looking at the left side of the screen, he will be rotated 180 degrees
        _lookForward = Vector2.zero;                                         //When enemy looks at the right side of the screen, he will be put in it normal rotation
    }

	// Update is called once per frame
	void Update () 
    {
        Flip();
        Debug.Log(this.name + " Facing Right? " + _facingRight);
	}

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //Use rigidbody2D to achieve movement
        GetComponent<Rigidbody2D>().velocity = new Vector2(_direction * _speed.value, GetComponent<Rigidbody2D>().velocity.y);
        //Absolute value to keep a positive number, this will be used when animating
        float moveAbs = Mathf.Abs(_speed.value);                                                       
        _anim.SetFloat(_moveHash, moveAbs);
        //Check when to turn towards the character. Such check is based in position distance.
        if(_target.position.x < _myTransform.position.x - 2)                                      
        {
            _facingRight = false;
        }
        else if(_target.position.x > _myTransform.position.x + 2)
        {
            _facingRight = true;
        }
    }

    //Flip function will allow the enemy to rotate towards the player when the conditions are met
    void Flip()
    {
        if(_facingRight)
        {
            _myTransform.rotation = Quaternion.Euler(_lookForward);
            _direction = 1;
        }
        else if(!_facingRight)
        {
            _myTransform.rotation = Quaternion.Euler(_lookBack);
            _direction = -1;
        }
    }
}
