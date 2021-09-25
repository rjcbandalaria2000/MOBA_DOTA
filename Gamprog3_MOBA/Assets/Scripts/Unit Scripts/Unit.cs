using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


        
    // Start is called before the first frame update
    void Start()
    {
        attackRange /= GameManager.distanceUnit;

    }

    // Update is called once per frame
    void Update()
    {
        
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
}
