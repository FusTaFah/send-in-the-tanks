using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

/// <summary>
/// Collection of behaviour for the principle player of this current instace of the game
/// </summary>
public class Controls : MonoBehaviour
{
    public UnitSpawner unitSpawner;

    public float CameraMoveSpeed;
    public float CameraZoomSpeed;

    public GameEvent LeftPanEvent;
    public GameEvent UpPanEvent;
    public GameEvent RightPanEvent;
    public GameEvent DownPanEvent;

    public GameEvent CursorEnterInteractiveUIEvent;
    public GameEvent CursorExitInteractiveUIEvent;

    public GameEvent BoxDrawBegin;
    public GameEvent BoxDrawEnd;

    GameEventListener leftPanEventListener;
    GameEventListener upPanEventListener;
    GameEventListener rightPanEventListener;
    GameEventListener downPanEventListener;

    GameEventListener cursorEnterInteractiveUIEventListener;
    GameEventListener cursorExitInteractiveUIEventListener;

    public UnityEvent LeftPanResponse;
    public UnityEvent UpPanResponse;
    public UnityEvent RightPanResponse;
    public UnityEvent DownPanResponse;

    public UnityEvent CursorEnterInteractiveUIResponse;
    public UnityEvent CursorExitInteractiveUIResponse;

    private bool cursorInInteractiveUI = false;

    private bool cursorConfined = true;
    private bool mouseLeftClickDown = false;
    private bool alreadyBegunDrawingBox = false;

    public Player ControllingPlayer;

    Vector2 bufferedMousePosition;
    float timeSinceLastClick = 0.0f;

    public UnitSelectionCollection SelectedUnits;
    private List<UnitSpawnerBehaviour> selectedSpawners;

    private Vector3 Forward
    {
        get
        {
            return Vector3.Cross(Vector3.up, - gameObject.transform.right);
        }
    }

    private void Awake()
    {
        leftPanEventListener = new GameEventListener();
        leftPanEventListener.GameEvent = LeftPanEvent;
        leftPanEventListener.Response = LeftPanResponse;
        upPanEventListener = new GameEventListener();
        upPanEventListener.GameEvent = UpPanEvent;
        upPanEventListener.Response = UpPanResponse;
        rightPanEventListener = new GameEventListener();
        rightPanEventListener.GameEvent = RightPanEvent;
        rightPanEventListener.Response = RightPanResponse;
        downPanEventListener = new GameEventListener();
        downPanEventListener.GameEvent = DownPanEvent;
        downPanEventListener.Response = DownPanResponse;

        cursorEnterInteractiveUIEventListener = new GameEventListener();
        cursorEnterInteractiveUIEventListener.GameEvent = CursorEnterInteractiveUIEvent;
        cursorEnterInteractiveUIEventListener.Response = CursorEnterInteractiveUIResponse;

        cursorExitInteractiveUIEventListener = new GameEventListener();
        cursorExitInteractiveUIEventListener.GameEvent = CursorExitInteractiveUIEvent;
        cursorExitInteractiveUIEventListener.Response = CursorExitInteractiveUIResponse;

        bufferedMousePosition = new Vector2();

        selectedSpawners = new();
    }

    void Start()
    {
        
    }

    private void OnEnable()
    {
        leftPanEventListener.RegisterListener();
        upPanEventListener.RegisterListener();
        rightPanEventListener.RegisterListener();
        downPanEventListener.RegisterListener();

        cursorEnterInteractiveUIEventListener.RegisterListener();
        cursorExitInteractiveUIEventListener.RegisterListener();
    }

    private void OnDisable()
    {
        leftPanEventListener.DeRegisterListener();
        upPanEventListener.DeRegisterListener();
        rightPanEventListener.DeRegisterListener();
        downPanEventListener.DeRegisterListener();

        cursorEnterInteractiveUIEventListener.DeRegisterListener();
        cursorExitInteractiveUIEventListener.DeRegisterListener();
    }

    public void PanLeft()
    {
        gameObject.transform.Translate(-gameObject.transform.right * CameraMoveSpeed * Time.deltaTime);
    }

    public void PanUp()
    {
        gameObject.transform.Translate(Forward * CameraMoveSpeed * Time.deltaTime, Space.World);
    }

    public void PanRight()
    {
        gameObject.transform.Translate(gameObject.transform.right * CameraMoveSpeed * Time.deltaTime);
    }

    public void PanDown()
    {
        gameObject.transform.Translate(-Forward * CameraMoveSpeed * Time.deltaTime, Space.World);
    }

    public void CursorEnterInteractiveUI()
    {
        cursorInInteractiveUI = true;
    }

    public void CursorExitInteractiveUI()
    {
        cursorInInteractiveUI = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            cursorConfined = !cursorConfined;
        }

        gameObject.transform.Translate(Vector3.up * CameraZoomSpeed * -Input.mouseScrollDelta.y * Time.deltaTime, Space.World);

        Cursor.lockState = cursorConfined ? CursorLockMode.Confined : CursorLockMode.None;

        //initial click
        if (Input.GetKey(KeyCode.Mouse0) && !mouseLeftClickDown && !cursorInInteractiveUI)
        {
            SelectedUnits.DeSelectAll();
            mouseLeftClickDown = true;
            Vector2 currentMousePos = Input.mousePosition;
            bufferedMousePosition = currentMousePos;
        }
        //click and drag
        else if (Input.GetKey(KeyCode.Mouse0) && mouseLeftClickDown)
        {
            timeSinceLastClick += Time.deltaTime;
            Vector2 currentMousePos = Input.mousePosition;
            if ((currentMousePos - bufferedMousePosition).sqrMagnitude > 25f && !alreadyBegunDrawingBox)
            {
                BoxDrawBegin.Raise();
                alreadyBegunDrawingBox = true;
            }
        }
        //let go
        else if(Input.GetKeyUp(KeyCode.Mouse0) && mouseLeftClickDown)
        {
            Vector2 currentMousePosition = Input.mousePosition;

            if (alreadyBegunDrawingBox)
            {
                //selection box
                Rect selectionBox = CreateSelectionRect(bufferedMousePosition, currentMousePosition);

                foreach (UnitBehaviour unit in GameObject.FindGameObjectsWithTag("unit").Select(x => x.GetComponent<UnitBehaviour>()))
                {
                    Vector2 point = Camera.main.WorldToScreenPoint(unit.transform.position);
                    if (selectionBox.Contains(point))
                    {
                        SelectedUnits.Select(unit);
                    }
                }
            }
            else
            {
                
            }

            BoxDrawEnd.Raise();
            mouseLeftClickDown = false;
            timeSinceLastClick = 0.0f;
            alreadyBegunDrawingBox = false;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && !cursorInInteractiveUI)
        {
            RaycastHit[] totalClickDataInWorldSpace = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
            Vector3 groundPoint = totalClickDataInWorldSpace.Where(x => x.collider.tag == "terrain").Single().point;
            SelectedUnits.MoveTo(groundPoint);
        }
    }

    private void HighlightUnit()
    {

    }

    private void HighlightSpawner()
    {

    }

    private void SelectSpawner()
    {

    }

    Rect CreateSelectionRect(Vector2 initialMousePosition, Vector2 currentMousePosition)
    {
        Vector2 differece = currentMousePosition - initialMousePosition;
        if(differece.x >= 0.0f && differece.y >= 0.0f)
        {
            return new Rect(initialMousePosition, differece);
        }
        else if(differece.x >= 0.0f && differece.y < 0.0f)
        {
            Vector2 origin = new Vector2(initialMousePosition.x, currentMousePosition.y);
            Vector2 opposite = new Vector2(currentMousePosition.x, initialMousePosition.y);
            return new Rect(origin, opposite - origin);

        }
        else if(differece.x < 0.0f && differece.y < 0.0f)
        {
            Vector2 origin = new Vector2(currentMousePosition.x, currentMousePosition.y);
            Vector2 opposite = new Vector2(initialMousePosition.x, initialMousePosition.y);
            return new Rect(origin, opposite - origin);

        }
        else if(differece.x < 0.0f && differece.y >= 0.0f)
        {
            Vector2 origin = new Vector2(currentMousePosition.x, initialMousePosition.y);
            Vector2 opposite = new Vector2(initialMousePosition.x, currentMousePosition.y);
            return new Rect(origin, opposite - origin);
        }
        else
        {
            throw new System.Exception("Unknown selection");
        }
    }
}
