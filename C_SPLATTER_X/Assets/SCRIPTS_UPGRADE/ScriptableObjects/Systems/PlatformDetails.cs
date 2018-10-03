using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Platform Details", menuName = "Details/PlatformDetails", order = 1)]
public class PlatformDetails : ScriptableObject
{
    public Material typeMaterial;
    public PhysicsMaterial2D physicMaterial;
}
