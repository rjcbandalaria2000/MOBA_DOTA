using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Skill
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ActivateSkill(GameObject target, GameObject attacker = null)
    {
        base.ActivateSkill(target, attacker);
    }
    public override void OnActivate(GameObject target, GameObject attacker = null)
    {
        base.OnActivate(target, attacker);
        Unit unitTarget = target.GetComponent<Unit>();
        UnitStats attackerStats = attacker.GetComponent<UnitStats>();
        if (unitTarget)
        {
            FactionComponent targetFaction = target.GetComponent<FactionComponent>();
            if (targetFaction)
            {
                if (targetFaction.unitFaction != attacker.GetComponent<FactionComponent>().unitFaction)
                {
                    HealthComponent targetHealth = target.GetComponent<HealthComponent>();
                    if (targetHealth)
                    {
                        Debug.Log("Damage: " + target.name);
                        if (attackerStats)
                        {
                            targetHealth.TakeDamage(attackerStats.GetBaseDamage());
                        }
                        
                    }
                }
            }
        }
    }

}
