using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameEvent _event;
    [SerializeField] private GameColor _gameColor;
    [SerializeField] private FloatVariable _timeBeforeChange;
    [SerializeField] private IntegerVariable _score;
    [SerializeField] private float _colorChangeTimer;
    
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
        ChangeColor();
    }

    public void Something()
    {
        Debug.Log("EVENT HAS BEEN RAISED");
    }

    void ChangeColor()
    {
        _colorChangeTimer += Time.deltaTime;
        if(_colorChangeTimer >= _timeBeforeChange.value)
        {
            _event.Raise();
            _colorChangeTimer = 0.0f;
        }
    }
}
