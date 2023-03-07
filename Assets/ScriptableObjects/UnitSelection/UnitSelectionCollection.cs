using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

[CreateAssetMenu(menuName = "My Actors/UnitSelectionCollection")]
public class UnitSelectionCollection : ScriptableObject
{
    private List<UnitBehaviour> Units;
    public GameEvent UnitSelectionEvent;
    public GameEvent UnitDeselectionEvent;

    public int Count => Units.Count;

    private void OnEnable()
    {
        Units = new List<UnitBehaviour>();
    }

    public void Select(UnitBehaviour un)
    {
        if (!Units.Contains(un))
        {
            Units.Add(un);
            UnitSelectionEvent.Raise();
        }
    }

    public void Highlight(UnitBehaviour un)
    {

    }

    public void DeSelect(UnitBehaviour un)
    {
        if (Units.Contains(un))
        {
            Units.Remove(un);
            UnitDeselectionEvent.Raise();
        }
    }

    public void DeSelectAll()
    {
        Units.Clear();
        UnitDeselectionEvent.Raise();
    }

    public void MoveTo(Vector3 position)
    {
        Vector3 averageCenterPositionOfCurrentUnits = 
            new Vector3(
                Units.Sum(x => x.transform.position.x), 
                Units.Sum(x => x.transform.position.y), 
                Units.Sum(z => z.transform.position.z)
                ) / Units.Count;
        Stack<Vector3> offsets = new Stack<Vector3>();
        Vector3 columnDirection = (position - averageCenterPositionOfCurrentUnits).normalized;
        Vector3 rowDirection = Vector3.Cross(Vector3.up, columnDirection);
        int sqrtCount = Mathf.FloorToInt(Mathf.Sqrt(Units.Count));
        int column = -sqrtCount / 2;
        int row = -sqrtCount / 2;
        for(int i = 0; i < Units.Count; i++)
        {
            if(i % sqrtCount == 0)
            {
                row++;
                column = -sqrtCount / 2;
            }
            offsets.Push(column++ * rowDirection * 20.0f + row * columnDirection * 20.0f);
        }
        Units.ForEach(x => x.MoveTo(position + offsets.Pop()));
    }

    public IList<UnitBehaviour> GetUnits()
    {
        return Units.AsReadOnlyList<UnitBehaviour>();
    }
}
