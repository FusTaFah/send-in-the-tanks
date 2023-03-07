using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Utils;

[CreateAssetMenu(menuName = "My Assets/Ability")]
public class Ability : ScriptableObject
{
    [Tooltip("The name of this ability")]
    public string Name;
    [Tooltip("The display name of this ability")]
    public string DisplayName;
    [Tooltip("The amount of time in seconds before this ability begins use")]
    public int WindupTime;
    [Tooltip("The amount of time in seconds this ability stays in the channelling phase")]
    public int ChannellTime;
    [Tooltip("The time in seconds it takes for the effect of this ability to ware off")]
    public int Duration;
    [Tooltip("The time in seconds to takes for this ability to come back to use after its effect ends")]
    public int CoolDown;
    public int FoodCost;
    public int GoldCost;
    public int WoodCost;
    public int CapitalCost;
    [Tooltip("If true, using this ability will create a targeting cursor for the player to point and click")]
    public bool RequiresTargeting;
    [Tooltip("Effects how this ability spawns into the world")]
    public AbilityEffectOriginType AbilityProjectileOrEffectBehaviour;
    public GameObject ProjectileOrEffectOriginal;
    [Tooltip("The icon that will show up in the UI for display")]
    public Sprite Icon;
}
