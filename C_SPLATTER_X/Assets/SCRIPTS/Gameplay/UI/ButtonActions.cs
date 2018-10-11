using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    [SerializeField] private BooleanVariable _isPlayerDead;
    public void LoadCustomScene(string sceneToLoad)
    {
        _isPlayerDead.SetValue(true);
        SceneManager.LoadScene(sceneToLoad);
    }
}
