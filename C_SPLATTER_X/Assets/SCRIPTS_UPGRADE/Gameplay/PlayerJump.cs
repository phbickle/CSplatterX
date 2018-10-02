using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private BooleanVariable _hasJumped;
    [SerializeField] private BooleanVariable _isGrounded;
    [SerializeField] private BooleanVariable _jumpRequest;

    [SerializeField] private FloatVariable _jumpForce;
    [SerializeField] private FloatVariable _jumpDelay;

    [SerializeField] private GameColor _currColor;

    private Transform _myTransform;
    private Transform _groundCheck;

    private Rigidbody2D _rb;

    private Vector2 _jumpMove;

    // Start is called before the first frame update
    void Awake()
    {
        _groundCheck = transform.Find("Player/GroundCheck");
        _rb = GetComponent<Rigidbody2D>();
        _myTransform = transform;
        _hasJumped.SetValue(false);
        _isGrounded.SetValue(false);
        _jumpMove = new Vector2(0, _jumpForce.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckGround()
    {
        bool isGrounded = Physics2D.Linecast(_myTransform.position, _groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        _isGrounded.SetValue(isGrounded);
    }

    void JumpCheck()
    {
        if(_currColor.playColorValue == PlayColor.green)
        {
            _jumpRequest.SetValue(true);
        }

        if(_jumpRequest.value)
        {
            float delay = 0;
            delay += Time.deltaTime;
            if(delay >= _jumpDelay.value)
            {
                _hasJumped.SetValue(true);
                delay = 0;
                _jumpRequest.SetValue(false);
            }
        }
    }

    void Jump()
    {
        if(_hasJumped.value)
        {
            _rb.AddForce(_jumpMove);
            _hasJumped.SetValue(false);
        }
    }
}
