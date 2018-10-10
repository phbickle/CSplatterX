using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    [SerializeField] private IntegerVariable _playerDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var Enemy = collision.GetComponent<EnemyHealth>();

        if(null != Enemy)
        {
            Enemy.TakeDamage(_playerDamage.value);
        }
    }
}
