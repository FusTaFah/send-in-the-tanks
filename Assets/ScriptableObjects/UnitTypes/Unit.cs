using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utils;

[CreateAssetMenu(menuName = "My Assets/Unit")]
public class Unit : ScriptableObject
{
    [Tooltip("The name of this ability")]
    public string Name;
    [Tooltip("The display name of this ability")]
    public string DisplayName;
    [Tooltip("The prefab that contains the model and behaviour of this unit")]
    public GameObject UnitOriginalPrefab;
    [Tooltip("The maximum health of this unit")]
    public int MaximumHealth;
    [Tooltip("The Armour value of this unit. Damage taken is calculated as ThisUnitArmour - OtherUnitDamage")]
    public int Armour;
    [Tooltip("The damage this unit does with its main attack. Damage given is calculated as OtherUnitArmour - ThisUnitDamage")]
    public int Damage;
    [Tooltip("Thr prefab that contains the model and behaviour of the projectile associated with this unit's attack")]
    public GameObject ProjectileOriginalPrefab;
    [Tooltip("The range of this unit's main attack")]
    public int Range;
    [Tooltip("The movement speed of this unit in units per second")]
    public int Speed;
    [Tooltip("Specifies the overall movement behaviour of the unit")]
    public MobilityType MobilityDetail;
    [Tooltip("As opposed to attacking, this list contains all other player-activatable actions this unit can take")]
    public List<Ability> Abilities;
}
