using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayColor
{
    blue = 1,
    red,
    green,
    orange,
    purple,
    black,
    white,
    yellow
}

[CreateAssetMenu(fileName = "Color", menuName = "Gameplay/Color", order = 2)]
public class GameColor : ScriptableObject
{
    public PlayColor playColorValue;
}
