using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private ColorSystem _colorSystem;
    [SerializeField] private GameEvent _event;
    [SerializeField] private FloatVariable _timeBeforeChange;
    [SerializeField] private IntegerVariable _score;
    [SerializeField] private IntegerVariable _colorIndex;
    [SerializeField] private float _colorChangeTimer;
    private int _index;
    
    // Start is called before the first frame update
    void Awake()
    {
        _colorChangeTimer = 0.0f;
        _score.SetValue(0);
        InvokeRepeating("ChangeColor", _timeBeforeChange.value, _timeBeforeChange.value);
    }

    public void Something()
    {
        Debug.Log("EVENT HAS BEEN RAISED");
    }

    //Used by invoke repeating instead of polling it on every update
    void ChangeColor()
    {
        _colorIndex.SetValue(Random.Range(0, _colorSystem.details.Count));
        _event.Raise();
    }

/*
    void ChangeColor()
    {
        _colorChangeTimer += Time.deltaTime;
        if(_colorChangeTimer >= _timeBeforeChange.value)
        {
            _colorIndex.SetValue(Random.Range(0, _colorSystem.details.Count + 1));
            _event.Raise();
            _colorChangeTimer = 0.0f;
        }
    }
*/
}
