using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveUIRegion : MonoBehaviour
{
    RectTransform thisRectTransform;
    bool insideThisUIElement = false;
    public GameEvent CursorEnterInteractiveUIElement;
    public GameEvent CursorExitInteractiveUIElement;

    private void Start()
    {
        thisRectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseEnter()
    {
        if (!insideThisUIElement)
        {
            insideThisUIElement = true;
            CursorEnterInteractiveUIElement.Raise();
            Debug.Log("inside ui element");
        }
    }

    public void OnMouseExit()
    {
        if (insideThisUIElement)
        {
            insideThisUIElement = false;
            CursorExitInteractiveUIElement.Raise();
            Debug.Log("outside ui element");
        }
    }
}
