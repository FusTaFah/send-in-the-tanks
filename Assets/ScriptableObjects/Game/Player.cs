using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Actors/Player")]
public class Player : ScriptableObject
{
    public string Name;
    public int Gold;
    public int Food;
    public int Wood;
    public int Capital;
}
