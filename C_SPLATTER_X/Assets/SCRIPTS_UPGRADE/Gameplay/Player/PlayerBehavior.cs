using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public ColorSystem colorSystem;

    private void Awake()
    {
        ChangeType();
    }

    public void ChangeType()
    {
        colorSystem.SetPlayerStats(gameObject);
    }
}
