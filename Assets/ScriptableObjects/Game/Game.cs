using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Metas/Game")]
public class Game : ScriptableObject
{
    public List<Player> Players;
}
