using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;

public class AbilityDisplay : MonoBehaviour
{
    public Image IconBase;
    public UnitSelectionCollection SelectedUnits;
    private List<Image> iconsList;
    private int uiIndex;
    private Image thisPanel;
    public GameEvent SelectedEvent;
    public GameEvent DeSelectedEvent;
    public UnityEvent SelectedUnitEventResponse;
    public UnityEvent DeSelectedUnitEventResponse;
    GameEventListener SelectedResponse;
    GameEventListener DeSelectedResponse;

    void Start()
    {
        thisPanel = gameObject.GetComponent<Image>();
        iconsList = new List<Image>();
        
    }

    private void Awake()
    {
        SelectedResponse = new GameEventListener();
        SelectedResponse.GameEvent = SelectedEvent;
        SelectedResponse.Response = SelectedUnitEventResponse;
        DeSelectedResponse = new GameEventListener();
        DeSelectedResponse.GameEvent = DeSelectedEvent;
        DeSelectedResponse.Response = DeSelectedUnitEventResponse;
    }

    private void OnEnable()
    {
        SelectedResponse.RegisterListener();
        DeSelectedResponse.RegisterListener();
    }

    private void OnDisable()
    {
        SelectedResponse.DeRegisterListener();
        SelectedResponse.DeRegisterListener();
    }

    public void SelectionResponse()
    {
        if (SelectedUnits.Count > 0 && SelectedUnits.GetUnits().Select(x => x.Name).Distinct().Count() == 1)
        {
            UnitBehaviour selectedUnit = SelectedUnits.GetUnits()[0];
            selectedUnit.Abilities.ForEach(x => SlotNewAbility(x));
        }
    }

    public void DeSelectionResponse()
    {
        iconsList.ForEach(x => Destroy(x));
        iconsList.Clear();
        uiIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SlotNewAbility(Ability abil)
    {
        Image currentIcon = Instantiate(IconBase);
        currentIcon.sprite = abil.Icon;
        currentIcon.rectTransform.SetParent(thisPanel.transform);
        currentIcon.rectTransform.localPosition = 
            new Vector3(
                -thisPanel.rectTransform.rect.width * 0.5f + currentIcon.rectTransform.rect.width * 0.5f,
                thisPanel.rectTransform.rect.height * 0.5f - currentIcon.rectTransform.rect.height * 0.5f,
                0.0f);
        //currentIcon.rectTransform.position += new Vector3(uiIndex * 40.0f, 0.0f, 0.0f);
        iconsList.Add(currentIcon);
        uiIndex++;
    }
}
