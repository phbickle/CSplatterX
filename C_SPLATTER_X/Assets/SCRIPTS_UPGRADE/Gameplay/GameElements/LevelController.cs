using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private ColorSystem _colorSystem;
    [SerializeField] private GameEvent _event;
    [SerializeField] private FloatVariable _timeBeforeChange;
    [SerializeField] private IntegerVariable _score;
    [SerializeField] private IntegerVariable _colorIndex;
    [SerializeField] private float _colorChangeTimer;
    
    // Start is called before the first frame update
    void Awake()
    {
        _colorChangeTimer = 0.0f;
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
            _colorIndex.SetValue(Random.Range(0, _colorSystem.details.Count));
            _event.Raise();
            _colorChangeTimer = 0.0f;
        }
    }
}
