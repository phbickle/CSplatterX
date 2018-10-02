using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleAudioEvent : AudioEvent
{
    public AudioClip[] clips;

    public RangedFloat volume;

    [MinMaxRange(0, 1)]
    public RangedFloat pitch;

    public override void Play(AudioSource source)
    {
        if(clips.Length == 0)
        {
            return;
        }
        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = Random.Range(volume.minValue, volume.maxValue);
        source.Play();
    }
}
