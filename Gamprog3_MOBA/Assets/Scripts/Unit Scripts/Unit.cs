using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AttackType
{
    Melee,
    Ranged,
}

public class Unit : MonoBehaviour
{
    public string name;
    [SerializeField]
    public GameObject target;
    [SerializeField]
    List<Skill> unitSkills;
    [SerializeField]
    UnitStats unitStats;
    [SerializeField]
    AttackType attackType;
    //For attack test, will make a component for attack
    public float turnRate = 1.0f / GameManager.distanceUnit;
    NavMeshAgent unitNavmesh;

        
    // Start is called before the first frame update
    void Start()
    {
        InitializeUnit();
    }

    // Update is called once per frame
    void Update()
    {
        
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
