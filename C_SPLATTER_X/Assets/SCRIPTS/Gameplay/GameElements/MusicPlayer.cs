using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public ColorSystem colorSystem;
    // Start is called before the first frame update

    public void Awake()
    {
        SwitchMusic();
    }

    public void SwitchMusic()
    {
        colorSystem.SetMusic(gameObject);
    }

}
