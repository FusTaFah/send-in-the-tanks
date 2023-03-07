using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitSpawnerBehaviour : MonoBehaviour
{
    public string Name;
    public TotalUnitCollection TotalUnits;
    private Dictionary<string, Unit> spawnableUnits;
    public Player ControllingPlayer;

    public void InitialiseSpawner(string name, List<Unit> buildableUnits)
    {
        spawnableUnits = new();
        Name = name;
        foreach(Unit un in buildableUnits)
        {
            spawnableUnits[un.Name] = un;
        }
    }

    public void SpawnUnit(string name)
    {
        Unit unitToSpawn = spawnableUnits[name];
        if (unitToSpawn != null)
        {
            GameObject tnk = Instantiate(unitToSpawn.UnitOriginalPrefab);
            tnk.GetComponent<UnitBehaviour>().SetInfo(unitToSpawn.Name, unitToSpawn.DisplayName, unitToSpawn.Abilities, ControllingPlayer, unitToSpawn.MaximumHealth, unitToSpawn.Armour, unitToSpawn.Damage, unitToSpawn.ProjectileOriginalPrefab, unitToSpawn.Range, unitToSpawn.Speed, unitToSpawn.MobilityDetail);
            TotalUnits.RegisterUnit(tnk.GetComponent<UnitBehaviour>());
        }
        else
        {
            throw new System.Exception("Cannot spawn unit type " + name + " from this unit spawner " + Name);
        }
    }
}
