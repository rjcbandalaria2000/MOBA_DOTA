using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum CombatType
{
    Melee,
    Ranged,
}
public enum UnitType
{
    Hero, 
    MeleeCreep,
    RangedCreep, 
    SiegeCreep,
    Tower,
    Building,
}

public class Unit : MonoBehaviour
{
    public string name;
    [SerializeField]
    public GameObject target;
    public List<Skill> unitSkills;
    [SerializeField]
    UnitStats unitStats;
    [SerializeField]
    public UnitType unitType;
    [SerializeField]
    CombatType combatType;
    //For attack test, will make a component for attack
    public float turnRate = 1.0f / GameManager.distanceUnit;
    NavMeshAgent unitNavmesh;

    private void Awake()
    {
        //SingletonManager.Register(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeUnit();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = null;
        }
    }

    void InitializeUnit()
    {
        //attackRange /= GameManager.distanceUnit;
        //moveSpeed /= GameManager.distanceUnit;
        unitNavmesh = this.GetComponent<NavMeshAgent>();
        unitStats = this.GetComponent<UnitStats>();
        if (unitNavmesh)
        {
            unitNavmesh.speed = unitStats.GetMovementSpeed()/GameManager.distanceUnit;
            //unitNavmesh.angularSpeed = turnRate / GameManager.distanceUnit;
        }
    }

    public void UseSkill()
    {
        // Attack skill for testing 
        //Unit unitTarget = target.GetComponent<Unit>();
        //if (unitTarget)
        //{
        //    FactionComponent targetFaction = target.GetComponent<FactionComponent>();
        //    if (targetFaction)
        //    {
        //        if(targetFaction.unitFaction != this.gameObject.GetComponent<FactionComponent>().unitFaction)
        //        {
        //            HealthComponent targetHealth = target.GetComponent<HealthComponent>();
        //            if (targetHealth)
        //            {
        //                Debug.Log("Damage: " + target.name);
        //                targetHealth.TakeDamage(unitStats.GetBaseDamage());
        //            }
        //        }
        //    }
        //}
        unitSkills[0].ActivateSkill(target, this.gameObject);
    }

    public void useFirstSkill()
    {
        if(unitSkills[1] != null)
        { 
            unitSkills[1].ActivateSkill(target, this.gameObject);
        }
        else
        {
            Debug.Log("No Skill");
        }
    }

    public void SetTarget(GameObject targetAcquired)
    {
        target = targetAcquired;
    }

    public Skill GetSkill(int skillIndex)
    {
        return unitSkills[skillIndex];
    }

    public void OnDeath()
    {

    }
}
