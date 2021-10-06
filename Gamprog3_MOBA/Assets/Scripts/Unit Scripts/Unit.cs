using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public string name;

    public HealthComponent unitHealth;
    [SerializeField]
    public GameObject target;
    [SerializeField]
    Skill[] unitSkills;
    //For attack test, will make a component for attack
    [SerializeField]
    public float attackRange;
    public float damage;
    public float turnRate = 1.0f / GameManager.distanceUnit;
    public float moveSpeed = 0;
    NavMeshAgent unitNavmesh;

    public Creeps_ScriptableObject creepsObj;
        
    // Start is called before the first frame update
    void Start()
    {
        if(creepsObj != null)
        {
            InitializeCreeps();
        }
        else // Hero Characters
        {
            InitializeUnit();
        }

 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeUnit()
    {
        attackRange /= GameManager.distanceUnit;
        moveSpeed /= GameManager.distanceUnit;
        unitNavmesh = this.GetComponent<NavMeshAgent>();
        
        if (unitNavmesh)
        {
            unitNavmesh.speed = moveSpeed;
        }
    }

    public void UseSkill()
    {
        // Attack skill for testing 
        Unit unitTarget = target.GetComponent<Unit>();
        if (unitTarget)
        {
            FactionComponent targetFaction = target.GetComponent<FactionComponent>();
            if (targetFaction)
            {
                if(targetFaction.unitFaction != this.gameObject.GetComponent<FactionComponent>().unitFaction)
                {
                    HealthComponent targetHealth = target.GetComponent<HealthComponent>();
                    if (targetHealth)
                    {
                        targetHealth.TakeDamage(damage);
                    }
                }
            }
        }
    }

    void InitializeCreeps()
    {
        name = creepsObj.creepName;
        unitHealth.SetMaxHP(creepsObj.maxHP);
        damage = creepsObj.ATK;
        attackRange = creepsObj.attackRange;
        moveSpeed = creepsObj.moveSpeed;

        if (unitNavmesh)
        {
            unitNavmesh.speed = moveSpeed;
        }
    }
}
