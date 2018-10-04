using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBehavior : MonoBehaviour
{
    private EnumValue _myType;
    public ColorSystem colorSystem;

    public EnumValue ColorType
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
        if(null != colorSystem)
        {
            //ColorType = colorSystem.defaultColorType;
        }
    }

    public void ChangeType()
    {
        colorSystem.SetGameColor(gameObject);
    }
}
