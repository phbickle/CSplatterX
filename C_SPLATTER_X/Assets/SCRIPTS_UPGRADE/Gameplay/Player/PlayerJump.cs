﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private bool _hasJumped;
    private bool _isGrounded;
    private bool _jumpRequest;
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
        _groundCheck = transform.Find("GroundCheck");
        _rb = GetComponent<Rigidbody2D>();
        _myTransform = transform;
        _hasJumped = false;
        _isGrounded = false;
        _jumpRequest = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckGround();
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
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
            _rb.AddForce(new Vector2(0, _jumpForce.value));
            _hasJumped = false;
        }
    }
}
