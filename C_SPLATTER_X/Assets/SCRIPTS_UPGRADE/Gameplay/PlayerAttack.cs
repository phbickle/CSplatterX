using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _anim;
    private int _attackHash = Animator.StringToHash("Attack");

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        bool isAttacking = Input.GetButton("Fire1");
        if(isAttacking)
        {
            _anim.SetTrigger(_attackHash);
        }
    }
}