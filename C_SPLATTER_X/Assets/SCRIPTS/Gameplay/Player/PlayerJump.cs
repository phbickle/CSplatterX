using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private bool _hasJumped;
    private bool _isGrounded;
    private bool _jumpRequest;
    private AudioSource _audioSourceComp;

    [SerializeField] private AudioEvent _jumpAudioEvent;
    [SerializeField] private FloatVariable _jumpForce;
    [SerializeField] private FloatVariable _jumpDelay;
    [SerializeField] private GameColor _currColor;

    private Transform _myTransform;
    [SerializeField] private Transform _groundCheck;

    private Rigidbody2D _rb;

    private Vector2 _jumpMove;

    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioSourceComp = GetComponent<AudioSource>();
        _myTransform = transform;
        _hasJumped = false;
        _isGrounded = false;
        _jumpRequest = false;
    }

    private void Update()
    {
        CheckGround();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButtonDown("Jump"))
        {
            JumpCheck();
        }
    }

    void CheckGround()
    {
        _isGrounded = Physics2D.Linecast(_myTransform.position, _groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
    }

    void JumpCheck()
    {
        if(_currColor.playColorValue == PlayColor.green)
        {
            _jumpRequest = true;
        }

        if(_jumpRequest)
        {
            float delay = 0;
            delay += Time.deltaTime;
            if(delay >= _jumpDelay.value)
            {
                Jump();
                _hasJumped = true;
                delay = 0;
                _jumpRequest = false;
            }
        }
        else
        {
            Jump();
        }
    }

    void Jump()
    {
        if(_isGrounded)
        {
            _jumpAudioEvent.Play(_audioSourceComp);
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce.value);
            _hasJumped = false;
        }
    }
}