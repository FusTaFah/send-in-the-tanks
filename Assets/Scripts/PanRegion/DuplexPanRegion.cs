using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplexPanRegion : MonoBehaviour
{
    private bool mouseIn = false;
    public GameEvent PanEvent1;
    public GameEvent PanEvent2;

    private void Update()
    {
        if (mouseIn)
        {
            PanEvent1.Raise();
            PanEvent2.Raise();
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
