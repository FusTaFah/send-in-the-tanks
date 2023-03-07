using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "My Assets/UnitSpawner")]
public class UnitSpawner : ScriptableObject
{
    public string Name;
    public string DisplayName;
    public GameObject UnitSpawnerOriginalPrefab;
    public List<Unit> SpawnableUnits;
    
}
