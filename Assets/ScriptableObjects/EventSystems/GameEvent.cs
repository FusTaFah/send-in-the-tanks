using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Events/Game Event")]
public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> GameEventListeners;

    public GameEvent()
    {
        GameEventListeners = new List<GameEventListener>();
    }

    public void Raise()
    {
        foreach(GameEventListener listener in GameEventListeners)
        {
            listener.Raise();
        }
    }

    public void Register(GameEventListener other)
    {
        if (!GameEventListeners.Contains(other))
        {
            GameEventListeners.Add(other);
        }
    }

    public void DeRegister(GameEventListener other)
    {
        if (GameEventListeners.Contains(other))
        {
            GameEventListeners.Remove(other);
        }
    }
}
