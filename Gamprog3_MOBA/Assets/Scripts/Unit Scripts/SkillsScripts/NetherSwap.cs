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

        Animator targetAnimator = target.GetComponent<Animator>();
        
        InterruptActions(targetAnimator);
        

        attacker.GetComponent<NavMeshAgent>().SetDestination(targetPos);
    }

    public override void ActivateSkill(GameObject target, GameObject attacker = null)
    {
        base.ActivateSkill(target, attacker);
        isCoolDown = true;
        coolDownRoutine = StartCoroutine(SkillCoolDown(skillCooldown[skillLevel - 1], skillIndex));
    }
    void InterruptActions(Animator targetAnimator)
    {
        Debug.Log("Interrupt");
        AI_Script unitAI = targetAnimator.gameObject.GetComponent<AI_Script>();
        if(unitAI)
        {
            unitAI.targets.Clear();
        }
        targetAnimator.SetBool("IsMoving", false);
        targetAnimator.SetBool("IsAttacking", false);
        targetAnimator.gameObject.GetComponent<Unit>().target = null;
        targetAnimator.SetBool("hasTarget", false);
    }
}
