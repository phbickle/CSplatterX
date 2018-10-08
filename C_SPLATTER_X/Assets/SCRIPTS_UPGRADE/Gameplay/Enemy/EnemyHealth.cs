using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private IntegerVariable _health;

    private Rigidbody2D _rb;
    private Transform _myTransform;

    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _myTransform = transform;
    }

    public void TakeDamage(int damage)
    {
        _health.value -= damage;
        if(_health.value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
