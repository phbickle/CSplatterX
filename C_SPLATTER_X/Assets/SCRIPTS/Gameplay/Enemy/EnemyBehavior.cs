using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public ColorSystem colorSystem;

    // Start is called before the first frame update
    void Awake()
    {
        ChangeType();
    }

    // Update is called once per frame
    public void ChangeType()
    {
        colorSystem.SetEnemyStats(gameObject);
    }
}
