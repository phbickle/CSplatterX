﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Color System", menuName = "Systems/ColorSystem", order = 1)]
public class ColorSystem : ScriptableObject
{
#if UNITY_EDITOR
    public string DeveloperDescription = "";
#endif

    [Header("Colors available to play, can be extended")]
    public List<ColorDetails> details;

    [Header("Current color at play")]
    public ColorDetails currentColorType;

    public IntegerVariable colorIndex;

    public FloatVariable speedValue;
    public void SetGameColor(GameObject obj)
    {
        ColorBehavior beh = obj.GetComponent<ColorBehavior>();
        if(null == beh)
        {
            return;
        }

        Camera cam = obj.GetComponent<Camera>();
        if(null == cam)
        {
            return;
        }

        currentColorType = details[colorIndex.value];

        cam.backgroundColor = currentColorType.curreColor;

    }

    public void SetMeshRenderer(GameObject obj)
    {
        PlatformBehavior beh = obj.GetComponent<PlatformBehavior>();
        if(null == beh)
        {
            return;
        }

        MeshRenderer rend = obj.GetComponent<MeshRenderer>();
        if (rend == null)
        {
            return;
        }

        Collider2D col = obj.GetComponent<Collider2D>();
        if(null == col)
        {
            return;
        }

        currentColorType = details[colorIndex.value];
        rend.enabled = currentColorType.canSeeFloor;
        col.sharedMaterial = currentColorType.physMat2D;
    }

    public void SetMusic(GameObject obj)
    {
        MusicPlayer mus = obj.GetComponent<MusicPlayer>();
        if(null == mus)
        {
            return;
        }

        AudioSource aud = obj.GetComponent<AudioSource>();
        if(null == aud)
        {
            return;
        }

        currentColorType = details[colorIndex.value];

        aud.clip = currentColorType.musicToPlay;
        aud.Play();
    }

    public void SetPlayerStats(GameObject obj)
    {
        PlayerBehavior beh = obj.GetComponent<PlayerBehavior>();
        if(null == beh)
        {
            return;
        }

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if(null == rb)
        {
            return;
        }

        currentColorType = details[colorIndex.value];
        speedValue.value = currentColorType.colorSpeed;
        rb.gravityScale = currentColorType.gravityScale;
        rb.transform.localScale = new Vector2(currentColorType.scaleValue, currentColorType.scaleValue);
    }
}