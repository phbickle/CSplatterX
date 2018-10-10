using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _anim;
    private int _attackHash = Animator.StringToHash("attack");
    private AudioSource _audioSourceComp;

    [SerializeField] private AudioEvent _attackAudioEvent;
    [SerializeField] Collider2D _attackBox;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _audioSourceComp = GetComponent<AudioSource>();
        _attackBox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttacking = Input.GetButtonDown("Fire1");
        _attackBox.enabled = isAttacking;
        if(isAttacking)
        {
            Attack();
        }
    }

    void Attack()
    {
        _attackAudioEvent.Play(_audioSourceComp);
        _anim.SetTrigger(_attackHash);
    }
}