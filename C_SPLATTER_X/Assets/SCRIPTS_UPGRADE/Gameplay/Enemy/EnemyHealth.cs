using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private IntegerVariable _playerHealth;
    [SerializeField] private IntegerVariable _maxHealth;
    [SerializeField] private IntegerVariable _enemyCounter;
    [SerializeField] private FloatVariable _bashForce;

    private int _health;
    private Transform _myTransform;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Awake()
    {
        _health = _maxHealth.value;
        _myTransform = transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            _enemyCounter.value--;
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == Tags.death)
        {
            _enemyCounter.value--;
            this.gameObject.SetActive(false);
        }

        
    }

    private void OnEnable()
    {
        _health = _maxHealth.value;
    }
}
