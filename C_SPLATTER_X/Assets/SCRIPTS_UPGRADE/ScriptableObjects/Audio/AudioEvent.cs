using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioEvent : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription;
#endif
    public abstract void Play(AudioSource source);
}
