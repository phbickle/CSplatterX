using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "Gameplay/Event", order = 3)]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> _listeners = new List<GameEventListener>();

    public void Raise()
    {
        for(int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        if(!_listeners.Contains(listener))
        {
            _listeners.Add(listener);
        }
        else
        {
            Debug.LogWarning("Listener registered to event");
        }
    }

    public void UnregisterListener(GameEventListener listener)
    {
        _listeners.Remove(listener);
    }

}
