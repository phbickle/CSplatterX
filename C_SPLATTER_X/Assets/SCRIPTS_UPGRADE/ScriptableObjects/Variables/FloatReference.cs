using System;
using UnityEngine;

[Serializable]
public class FloatReference : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public bool UseConstant = true;
    public float ConstantValue;
    public FloatVariable Variable;

    public FloatReference()
    {

    }

    public FloatReference(float value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public float Value
    {
        get { return UseConstant ? ConstantValue : Variable.value; }
    }

    public static implicit operator float (FloatReference reference)
    {
        return reference.Value;
    }
}
