using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : UnitStateMachine
{
    NavMeshAgent unitNavmesh;
    UnitStats unitStats;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        unitNavmesh = unit.GetComponent<NavMeshAgent>();
        unitStats = unit.GetComponent<UnitStats>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (animator.GetFloat("Distance") > unitStats.GetAttackRange())
        {
            unitNavmesh.SetDestination(target.transform.position);
            animator.SetBool("IsMoving", true);
        }
        else
        {
            unit.transform.position = unit.transform.position;
            Debug.Log("Target In Range");
            animator.SetBool("inRange", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }

  
}
