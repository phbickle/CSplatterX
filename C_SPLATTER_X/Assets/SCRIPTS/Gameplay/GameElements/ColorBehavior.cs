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
        ChangeType();
    }

    public void ChangeType()
    {
        colorSystem.SetGameColor(gameObject);
    }
}
