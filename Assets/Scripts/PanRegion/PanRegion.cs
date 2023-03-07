using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanRegion : MonoBehaviour
{
    private bool mouseIn = false;
    public GameEvent PanEvent;

    private void Update()
    {
        if (mouseIn)
        {
            PanEvent.Raise();
        }
    }

    public void OnMouseEnter()
    {
        mouseIn = true;
    }

    public void OnMouseExit()
    {
        mouseIn = false;
    }
}
