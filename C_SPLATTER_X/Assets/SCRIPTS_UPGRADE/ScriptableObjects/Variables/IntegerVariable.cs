using UnityEngine;

[CreateAssetMenu(fileName = "Integer Variable", menuName = "Variables/Integer", order = 2)]
public class IntegerVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public int value;

    public void SetValue(int newValue)
    {
        value = newValue;
    }

    public void SetNewValue(IntegerVariable newValue)
    {
        value = newValue.value;
    }

    public void ApplyChange(int amount)
    {
        value += amount;
    }
}
