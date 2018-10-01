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

[CreateAssetMenu(fileName = "Game State", menuName = "Gameplay/State", order = 1)]
public class GameState : ScriptableObject
{
    
}
