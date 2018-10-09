using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private IntegerVariable _health;
    
    private Rigidbody2D _rb;
    private Transform _myTransform;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _myTransform = transform;
    }

    //This function is in charge of pushing the player in the opposite direction
    //of the enemy he touched
    void PushBack(GameObject obj)
    {
        Vector3 pushVector = _myTransform.position - obj.transform.position;
        _rb.AddForce(pushVector);
    }
}