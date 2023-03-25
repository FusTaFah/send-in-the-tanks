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

    private UnitBehaviour attackTarget;
    private UnitSpawnerBehaviour demolitionTarget;
    private ActionState actionState = ActionState.IDLE;

    private enum ActionState
    {
        IDLE,
        MOVING_TO_POINT,
        MOVING_TO_ATTACK,
        ATTACK_MOVE,
        ATTACKING,
        PATROL,
        DEAD
    }

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
        actionState = ActionState.MOVING_TO_POINT;
    }

    public void Attack(UnitBehaviour unit)
    {
        actionState = ActionState.MOVING_TO_ATTACK;
        attackTarget = unit;
    }

    public void Attack(UnitSpawnerBehaviour spawner)
    {
        actionState = ActionState.MOVING_TO_ATTACK;
        demolitionTarget = spawner;
    }

    /// <summary>
    /// Move towards the specified position but attack the closest enemy unit along the way.
    /// </summary>
    /// <param name="position"></param>
    public void AttackMove(Vector3 position)
    {

    }

    public void Patrol()
    {

    }

    public void UseAbility(int abilityNumber)
    {

    }

    //private bool CheckRangeToTarget()
    //{
    //    if( gameObject.transform.position)
    //}

    private void Update()
    {
        switch (actionState)
        {
            case ActionState.IDLE:
                break;
            case ActionState.MOVING_TO_POINT:
                break;
            case ActionState.MOVING_TO_ATTACK:
                break;
            case ActionState.ATTACK_MOVE:
                break;
            case ActionState.ATTACKING:
                break;
            case ActionState.PATROL:
                break;
            case ActionState.DEAD:
                break;
        }
    }
}
