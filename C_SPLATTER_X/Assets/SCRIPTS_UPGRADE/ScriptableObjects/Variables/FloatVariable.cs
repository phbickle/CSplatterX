using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Float Variable", menuName = "Variables/Float", order = 1)]
public class FloatVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public float value;

    public void SetValue(float newValue)
    {
        value = newValue;
    }

    public void SetValue(FloatVariable newValue)
    {
        value = newValue.value;
    }

    public void ApplyChange(float amount)
    {
        value += amount;
    }

    public void ApplyChange(FloatVariable amount)
    {
        value += amount.value;
    }
}
