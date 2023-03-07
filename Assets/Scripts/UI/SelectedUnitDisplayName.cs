using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SelectedUnitDisplayName : MonoBehaviour
{
    public UnitSelectionCollection selectedUnits;
    public TMPro.TMP_Text unitListDisplay;

    // Update is called once per frame
    void Update()
    {
        //TODO: create an event system to notify this behaviour that the selection has changed. only call this when selection has changed
        string totalText = string.Empty;
        List<UnitBehaviour> unitsByName = selectedUnits.GetUnits().OrderBy(x => x.Name).ToList();
        string currentName = string.Empty;
        string currentDisplayName = string.Empty;
        int currentCount = 0;
        foreach (UnitBehaviour unit in unitsByName)
        {
            currentCount++;
            if (unit.Name != currentName)
            {
                currentName = unit.Name;
                currentDisplayName = unit.DisplayName;
                if (currentCount > 0)
                {
                    totalText += currentCount.ToString() + "x " + currentDisplayName + Environment.NewLine;
                }
                currentCount = 0;
            }
        }
        unitListDisplay.text = totalText;
    }
}
