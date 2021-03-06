﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Color Details", menuName = "Details/ColorDetails", order = 1)]
public class ColorDetails : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription;
#endif
    public Color curreColor;
    public PhysicsMaterial2D physMat2D;
    public bool isSticky;
    public bool canSeeFloor;
    public int gravityScale;    
    public int scaleValue;
    public float colorSpeed;
    public AudioClip musicToPlay;
}
