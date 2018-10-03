using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    private EnumValue _myType;
    public PlatformSystem platformSystem;

    public EnumValue PlatformType
    {
        get
        {
            return _myType;
        }
        set
        {
            _myType = value;
            ChangeType();
        }
    }

    private void Start()
    {
        if(null != platformSystem)
        {
            PlatformType = platformSystem.defaultPlatformType;
        }
    }

    public void ChangeType()
    {
        platformSystem.SetPlatformMaterial(gameObject);
    }
}
