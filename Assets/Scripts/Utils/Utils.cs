using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public enum MobilityType
    {
        [Tooltip("Unit moves like a 4x4 vehicle")]
        WHEELS,
        [Tooltip("Unit moves like a tank or tracked vehicle")]
        TRACKED,
        [Tooltip("Unit moves freely")]
        FEET,
        [Tooltip("Unit moves like a lorry")]
        CADDY
    }

    public enum AbilityEffectOriginType
    {
        [Tooltip("The Ability or effect will originate from the GameObject")]
        FROM_GAMEOBJECT,
        [Tooltip("The Ability or effect will originate from the source's pre designated firing position on the gameobject")]
        FROM_FIRINGSPOT,
        [Tooltip("The Ability will effect or originate from wherever the player places their cursor")]
        DIRECT_TO_CURSOR,
        [Tooltip("The Ability will spawn in from the sky and travel to the ground")]
        FROM_SKY
    }
}
