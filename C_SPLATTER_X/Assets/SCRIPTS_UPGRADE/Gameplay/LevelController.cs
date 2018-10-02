using UnityEngine;

public class LevelController : MonoBehaviour
{
    private GameColor _gameColor;
    private FloatVariable _timeBeforeChange;
    private IntegerVariable _score;
    private float _colorChangeTimer;
    // Start is called before the first frame update
    void Awake()
    {
        _colorChangeTimer = 0.0f;
        _gameColor.playColorValue = PlayColor.white;
        _score.SetValue(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
