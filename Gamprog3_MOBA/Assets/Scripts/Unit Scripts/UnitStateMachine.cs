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

    public float attackInterval;

    public float rotationSpeed = 0.0f; 
    

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        unit = animator.gameObject;
        if (unit)
        {
            rotationSpeed = unit.GetComponent<Unit>().turnRate;
        }
       // NavMeshAgent unitNavMesh = unit.GetComponent<NavMeshAgent>();
    }

        
}
