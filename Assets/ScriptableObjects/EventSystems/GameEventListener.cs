using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener
{
    public GameEvent GameEvent;

    public UnityEvent Response;

    public GameEventListener()
    {
        Response = new UnityEvent();
    }

    public void Raise()
    {
        Response.Invoke();
    }

    public void RegisterListener()
    {
        GameEvent.Register(this);
    }

    public void DeRegisterListener()
    {
        GameEvent.DeRegister(this);
    }
}
