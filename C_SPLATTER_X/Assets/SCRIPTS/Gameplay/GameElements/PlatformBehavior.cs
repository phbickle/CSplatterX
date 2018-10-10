using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    public ColorSystem colorSystem;

    private void Awake()
    {
        ChangeType();
    }

    public void ChangeType()
    {
        colorSystem.SetMeshRenderer(gameObject);
    }
}