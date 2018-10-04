using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
    private GameManager _myManager;
    private Animator _anim;

    [SerializeField] private BooleanVariable _facingRight;

    [SerializeField] private FloatVariable _speed;                    //how fast will the player be?
    
    
    private Transform _myTransform;          //player's transform component

    private Vector2 _lookBack;               //looking at left side of the screen
    private Vector2 _lookForward;            //looking at right side of the screen

    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _myTransform = transform;                                                                    //initialize the player's transform component
        _lookBack = new Vector2(0f, 180.0f);                                                         
        _lookForward = Vector2.zero;
    }

	// Update is called once per frame
	void Update () 
    {
        Flip();
	}

    void FixedUpdate()
    {
        Movement();
    }
    
    void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            _anim.SetTrigger("attack");
            //AudioSource.PlayClipAtPoint(attackClip, myTransform.position);
        }
    }



    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");                //Axisraw prevents incremental speeds. In other words, speed will be constant since the beginning
        float moveAbs = Mathf.Abs(move);                            //Absolute values of the move variable, it will always be a positive number. This will be used in animation
        _anim.SetFloat("speed", moveAbs);

        //Axisraw will return a number ranging from -1, 0 or 1
        //Depending on the value, the player will turn to the specific side
        if(move < 0)
        {
            _facingRight.SetValue(false);
        }
        else if(move > 0)
        {
            _facingRight.SetValue(true);
        }
        //Apply movement using velocity
        _rb.velocity = new Vector2(move * _speed.value, _rb.velocity.y);
    }

    void Flip()
    {
        //Turn left or right
        if(!_facingRight.value)
        {
            _myTransform.rotation = Quaternion.Euler(_lookBack);
        }
        else if(_facingRight.value)
        {
            _myTransform.rotation = Quaternion.Euler(_lookForward);
        }
    }
}
