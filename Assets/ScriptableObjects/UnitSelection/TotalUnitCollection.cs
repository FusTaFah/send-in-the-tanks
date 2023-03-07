using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Actors/TotalUnitCollection")]
public class TotalUnitCollection : ScriptableObject
{
    private List<UnitBehaviour> TotalUnits;

    private void OnEnable()
    {
        TotalUnits = new List<UnitBehaviour>();
    }

    public void RegisterUnit(UnitBehaviour unitBehaviour)
    {
        if (!TotalUnits.Contains(unitBehaviour))
        {
            TotalUnits.Add(unitBehaviour);
        }
    }

    public void DeRegisterUnit(UnitBehaviour unitBehaviour)
    {
        if (TotalUnits.Contains(unitBehaviour))
        {
            TotalUnits.Remove(unitBehaviour);
        }
    }
}
