using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : UnitStateMachine
{
    UnitStats unitStats;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        unitStats = unit.GetComponent<UnitStats>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        unit.transform.LookAt(target.transform.position);

        if (animator.GetFloat("Distance") <= unitStats.GetAttackRange())
        {
           
            animator.SetBool("IsMoving", false);
            Debug.Log("Attack");
            animator.SetBool("IsAttacking", false);
            
        }
        else
        {
            animator.SetBool("inRange", false);
            animator.SetBool("IsAttacking", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
