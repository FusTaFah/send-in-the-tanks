using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectionBox : MonoBehaviour
{
    // Start is called before the first frame update
    public Image SelectionBoxOriginal;
    public GameEvent BoxDrawBegin;
    public GameEvent BoxDrawEnd;

    GameEventListener BoxDrawBeginListener;
    GameEventListener BoxDrawEndListener;

    public UnityEvent BoxDrawBeginResponse;
    public UnityEvent BoxDrawEndResponse;

    bool drawingBox = false;

    Vector2 mouseInitialBoxDrawingPosition;
    Vector2 mouseCurrentBoxDrawingPosition;

    void Awake()
    {
        mouseInitialBoxDrawingPosition = mouseCurrentBoxDrawingPosition = new Vector2();
        
        BoxDrawBeginListener = new GameEventListener();
        BoxDrawBeginListener.GameEvent = BoxDrawBegin;
        BoxDrawBeginListener.Response = BoxDrawBeginResponse;

        BoxDrawEndListener = new GameEventListener();
        BoxDrawEndListener.GameEvent = BoxDrawEnd;
        BoxDrawEndListener.Response = BoxDrawEndResponse;

        SelectionBoxOriginal.color = new Color(0f, 0f, 0f, 0f);
    }

    private void OnEnable()
    {
        BoxDrawBeginListener.RegisterListener();
        BoxDrawEndListener.RegisterListener();
    }

    private void OnDisable()
    {
        BoxDrawBeginListener.DeRegisterListener();
        BoxDrawEndListener.DeRegisterListener();
    }

    public void OnBoxDrawBegin()
    {
        mouseInitialBoxDrawingPosition = mouseCurrentBoxDrawingPosition = Input.mousePosition;
        drawingBox = true;
        
    }

    public void OnBoxDrawEnd()
    {
        mouseInitialBoxDrawingPosition = mouseCurrentBoxDrawingPosition = new Vector2();
        drawingBox = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseCurrentBoxDrawingPosition = Input.mousePosition;

        Rect newSelectionRect = new Rect((mouseInitialBoxDrawingPosition + mouseCurrentBoxDrawingPosition) * 0.5f, mouseCurrentBoxDrawingPosition - mouseInitialBoxDrawingPosition);
        SelectionBoxOriginal.rectTransform.position = newSelectionRect.position;
        SelectionBoxOriginal.rectTransform.sizeDelta = new Vector2(Mathf.Abs(newSelectionRect.width), Mathf.Abs(newSelectionRect.height));
        SelectionBoxOriginal.rectTransform.ForceUpdateRectTransforms();

        if (drawingBox)
        {
            SelectionBoxOriginal.color = new Color(1f, 1f, 1f, 0.2f);
        }
        else
        {
            SelectionBoxOriginal.color = new Color(0f, 0f, 0f, 0f);
        }
    }
}
