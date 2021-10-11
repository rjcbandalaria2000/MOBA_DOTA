using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepBaseStateMachine : StateMachineBehaviour
{
    public GameObject unit;
    public GameObject target;
    public float attackInterval;
    [SerializeField]
    protected float attackTime;
    public float rotationSpeed = 0.0f;
    [SerializeField]
    protected float locationAccuracy = 1;
    [SerializeField]
    bool isAttacking;
    [SerializeField]
    bool isMoving;
    [SerializeField]
    float targetDistance;
    [SerializeField]
    bool inRange;
    // Start is called before the first frame update
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        unit = animator.gameObject;


    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        //Debug.Log("StateUpdate");
        //target = unit.GetComponent<Unit>().target;
        //Debug.Log("Target: " + target.name);
        if (target != null)
        {
            Debug.Log("Target Detected");
            animator.SetBool("hasTarget", true);
            target = unit.GetComponent<Unit>().target;
            //For Chasing
            animator.SetFloat("Distance", Vector3.Distance(unit.transform.position, target.transform.position));
            if (!animator.GetBool("IsAttacking"))
            {

                if (attackTime <= 0)
                {
                    attackTime = attackInterval;
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
