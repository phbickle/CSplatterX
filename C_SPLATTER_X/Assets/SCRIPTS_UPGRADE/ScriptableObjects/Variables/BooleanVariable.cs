using UnityEngine;

[CreateAssetMenu(fileName = "Boolean Variable", menuName = "Variables/Boolean", order = 3)]
public class BooleanVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public bool value;

    public void SetValue(bool newValue)
    {
        value = newValue;
    }

    public void SetValue(BooleanVariable newValue)
    {
        value = newValue.value;
    }

    public void TriggerValue()
    {
        value = !value;
    }
}
