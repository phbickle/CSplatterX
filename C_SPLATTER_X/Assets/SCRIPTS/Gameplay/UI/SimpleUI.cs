using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class SimpleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private IntegerVariable _score;
    [SerializeField] private BooleanVariable _isPlayerDead;
    private string _scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        _scoreText = string.Format("Score: {0}", _score.value);
        InvokeRepeating("ScoreUpdate", 1.0f, 1.0f);
    }

    void ScoreUpdate()
    {
        _score.value++;
        _scoreText = string.Format("Score: {0}", _score.value);
        _textMesh.text = _scoreText;
    }

    private void Update()
    {
        if(_isPlayerDead.value)
        {
            SceneManager.LoadScene(2);
        }
    }
}
