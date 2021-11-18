using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NetherSwap : Skill
{
    Vector3 currentPos; //Caster Pos
    Vector3 targetPos;

   
    public override void OnActivate(GameObject target, GameObject attacker = null)
    {
        base.OnActivate(target, attacker);

        currentPos = attacker.transform.position;
        targetPos = target.transform.position;

        attacker.transform.position = targetPos;
        target.transform.position = currentPos;

        attacker.GetComponent<NavMeshAgent>().SetDestination(targetPos);
    }

    public override void ActivateSkill(GameObject target, GameObject attacker = null)
    {
        base.ActivateSkill(target, attacker);
    }
}
