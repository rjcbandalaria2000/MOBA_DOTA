using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIdleState : StateMachineBehaviour
{
    GameObject tower;
    TowerComponent towerComponent;

    public float unitBaseAttackTime;
    protected float attackTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tower = animator.gameObject;
        unitBaseAttackTime = tower.GetComponent<UnitStats>().GetBaseAttackTime();
        towerComponent = tower.GetComponent<TowerComponent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(towerComponent.targets.Count > 0)
        {
            if (!animator.GetBool("isAttacking"))
            {
               
                if (attackTime <= 0)
                {
                    attackTime = unitBaseAttackTime;//attackInterval;
                    animator.SetBool("isAttacking", true);
                    //animator.SetBool("isAttacking", false);
                }
                else
                {
                    attackTime -= Time.deltaTime;


                }

            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
