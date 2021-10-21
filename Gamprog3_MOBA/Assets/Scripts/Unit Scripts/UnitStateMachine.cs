using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitStateMachine : StateMachineBehaviour
{
    public GameObject unit;
    public GameObject target;

    public bool isMoving;
    public bool isAttacking;
    
    public float unitBaseAttackTime;
    public float attackInterval;
    [SerializeField]
    protected float attackTime;
    public float rotationSpeed = 0.0f;
    [SerializeField]
    protected float locationAccuracy = 1;
    


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        unit = animator.gameObject;
        unitBaseAttackTime = unit.GetComponent<UnitStats>().GetBaseAttackTime();

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        target = unit.GetComponent<Unit>().target;
        if (target != null)
        {
            Debug.Log("Target Detected");
            animator.SetBool("hasTarget", true);
            //target = unit.GetComponent<Unit>().target;
            //For Chasing
            animator.SetFloat("Distance", Vector3.Distance(unit.transform.position, target.transform.position));
            if (!animator.GetBool("IsAttacking"))
            {

                if (attackTime <= 0)
                {
                    attackTime = unitBaseAttackTime;//attackInterval;
                    animator.SetBool("IsAttacking", true);
                    //animator.SetBool("isAttacking", false);
                }
                else
                {
                    attackTime -= Time.deltaTime;


                }

            }
            else
            {

            }
        }
        else
        {
            animator.SetFloat("Distance", 0);
            animator.SetBool("hasTarget", false);
        }
    }


}
