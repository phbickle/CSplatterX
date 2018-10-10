using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
    private Animator _anim;

    private int _moveHash = Animator.StringToHash("speed");
    private float _frozenTime;
    private float _unfreeze;

    private bool _facingRight;                                  //Is the player facing right?
    private bool _canMove;

    private AudioSource _audioSourceComp;
    [SerializeField] private AudioEvent _deathAudioEvent;
    [SerializeField] private AudioEvent _hitAudioEvent;
    [SerializeField] private FloatVariable _speed;              //how fast will the player be?
    [SerializeField] private FloatVariable _tvHeadBashForce;
    [SerializeField] private FloatVariable _brocoTreeBashForce;

    private Transform _myTransform;                             //player's transform component

    private Vector2 _lookBack;                                  //looking at left side of the screen
    private Vector2 _lookForward;                               //looking at right side of the screen

    private Rigidbody2D _rb;

    void Awake()
    {
        _unfreeze = 0;
        _canMove = true;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _audioSourceComp = GetComponent<AudioSource>();
        _myTransform = transform;                                                                    //initialize the player's transform component
        _lookBack = new Vector2(0f, 180.0f);                                                         
        _lookForward = Vector2.zero;
    }

	// Update is called once per frame
	void Update () 
    {
        Flip();
        MoveCounter();
	}

    void MoveCounter()
    {
        _frozenTime = Time.time;
        if(!_canMove && (_frozenTime > _unfreeze))
        {
            _canMove = true;
            _unfreeze = _frozenTime + 1.0f;
        }
    }

    void FixedUpdate()
    {
        if(_canMove)
        {
            Movement();
        }
    }
    
    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");                //Axisraw prevents incremental speeds. In other words, speed will be constant since the beginning
        float moveAbs = Mathf.Abs(move);                            //Absolute values of the move variable, it will always be a positive number. This will be used in animation
        _anim.SetFloat(_moveHash, moveAbs);

        //Axisraw will return a number ranging from -1, 0 or 1
        //Depending on the value, the player will turn to the specific side
        if(move < 0)
        {
            _facingRight = false;
        }
        else if(move > 0)
        {
            _facingRight = true;
        }
        //Apply movement using velocity
        _rb.velocity = new Vector2(move * _speed.value, _rb.velocity.y);
    }

    void Flip()
    {
        //Turn left or right
        if(!_facingRight)
        {
            _myTransform.rotation = Quaternion.Euler(_lookBack);
        }
        else if(_facingRight)
        {
            _myTransform.rotation = Quaternion.Euler(_lookForward);
        }
    }

    void DisablePlayer()
    {
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == Tags.death)
        {
            _deathAudioEvent.Play(_audioSourceComp);
            GetComponent<SpriteRenderer>().enabled = false;
            Invoke("DisablePlayer", _audioSourceComp.clip.length/_audioSourceComp.pitch);
        }

        if (col.gameObject.tag == Tags.tvHead)
        {
            _canMove = false;
            _hitAudioEvent.Play(_audioSourceComp);
            Vector3 pushVector = _myTransform.position - col.gameObject.transform.position * _tvHeadBashForce.value;
            float xForce = pushVector.x; //See what I did there? :)
            _rb.AddForce(new Vector2(xForce, _tvHeadBashForce.value/2));
        }

        if (col.gameObject.tag == Tags.brocoTree)
        {
            _canMove = false;
            _hitAudioEvent.Play(_audioSourceComp);
            Vector3 pushVector = _myTransform.position - col.gameObject.transform.position * _brocoTreeBashForce.value;
            float xForce = pushVector.x; //See what I did there? :)
            _rb.AddForce(new Vector2(xForce, _brocoTreeBashForce.value/2));
        }
    }

}
