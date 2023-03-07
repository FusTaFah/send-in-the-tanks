using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Utils;

public class UnitBehaviour : MonoBehaviour
{
    NavMeshAgent agent;

    public string Name;
    public string DisplayName;
    public List<Ability> Abilities;
    public Player ControllingPlayer;
    public int MaximumHealth;
    public int CurrentHealth;
    public int Armour;
    public int Damage;
    private GameObject ProjectileOriginal;
    public int Range;
    public int MovementSpeed;
    private enum MovementState
    {
        Startup,
        Resume,
        Stopped
    }

    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void SetInfo(string name, string displayName, List<Ability> abilities, Player controllingPlayer, int health, int armour, int damage, GameObject projectile, int range, int movementSpeed, MobilityType mobilityDetail)
    {
        Name = name;
        DisplayName = displayName;
        Abilities = abilities;
        ControllingPlayer = controllingPlayer;
        MaximumHealth = CurrentHealth = health;
        Armour = armour;
        Damage = damage;
        ProjectileOriginal = projectile;
        Range = range;
        MovementSpeed = movementSpeed;

    }

    public void MoveTo(Vector3 position)
    {
        agent.SetDestination(position);
    }

    public void Attack(UnitBehaviour unit)
    {

    }

    public void Patrol()
    {

    }

    public void UseAbility(int abilityNumber)
    {

    }
}
