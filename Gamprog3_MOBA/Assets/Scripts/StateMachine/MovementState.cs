using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementState : UnitStateMachine
{
    NavMeshAgent unitNavMesh;
    Ray ray;
    RaycastHit hit; 
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        unitNavMesh = unit.GetComponent<NavMeshAgent>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

       

        if (Physics.Raycast(ray.origin, ray.direction, out hit)) //&& unit.GetComponent<PlayerControls>().unitStates != States.Idle)
        { 
            
            //var direction = hit.transform.position - unit.transform.position;
            //unit.transform.rotation = Quaternion.Slerp(unit.transform.rotation,
            //    Quaternion.LookRotation(direction),
            //    rotationSpeed * Time.deltaTime);
            //Debug.Log("Rotation Speed: " + rotationSpeed);
            unitNavMesh.SetDestination(hit.point);
        }
        Debug.Log(Vector3.Distance(unit.transform.position, hit.point));
        if (Vector3.Distance(unit.transform.position, hit.point) <= 2)
        {
            unit.GetComponent<PlayerControls>().unitStates = States.Idle;
            // unitNavMesh.SetDestination(hit.point);
        }



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        unitNavMesh.SetDestination(unit.transform.position);

        Debug.Log("Exit movement");
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
