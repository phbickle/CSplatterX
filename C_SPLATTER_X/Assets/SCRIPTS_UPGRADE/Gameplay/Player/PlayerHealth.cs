using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private IntegerVariable _health;
    [SerializeField] private IntegerVariable _maxHealth;
    [SerializeField] private FloatVariable _tvHeadBashForce;
    [SerializeField] private FloatVariable _brocoTreeBashForce;

    private Rigidbody2D _rb;
    private Transform _myTransform;

    private void Awake()
    {
        _health.value =_maxHealth.value;
        _rb = GetComponent<Rigidbody2D>();
        _myTransform = transform;
    }

    //This function is in charge of pushing the player in the opposite direction
    //of the enemy he touched
    void PushBack(GameObject obj, float bashForce)
    {
       
        Debug.Log("Pushing Back");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == Tags.death)
        {
            this.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == Tags.tvHead)
        {
            //Vector3 pushVector = _myTransform.position - col.gameObject.transform.position;
            //pushVector.Normalize();
            _rb.AddForce(new Vector2(_rb.velocity.x * _tvHeadBashForce.value, _tvHeadBashForce.value));
            _health.value--;
        }

        if (col.gameObject.tag == Tags.brocoTree)
        {
            //Vector3 pushVector = _myTransform.position - col.gameObject.transform.position;
            //pushVector.Normalize();
            _rb.AddForce(new Vector2(_rb.velocity.x * _brocoTreeBashForce.value, _brocoTreeBashForce.value));
            _health.value--;
        }
    }
}