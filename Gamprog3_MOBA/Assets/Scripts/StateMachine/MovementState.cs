using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementState : UnitStateMachine
{
    NavMeshAgent unitNavMesh;
    Ray ray;
    RaycastHit hit;

    Vector3 newLocation;

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
        newLocation = unit.GetComponent<PlayerControls>().newPos;

       

        Debug.Log(Vector3.Distance(unit.transform.position,newLocation));

        if (newLocation != null)
        {
            unitNavMesh.SetDestination(newLocation);
        }
        else
        {
            unit.GetComponent<Animator>().SetBool("IsMoving", false);
        }

       if (Vector3.Distance(unit.transform.position, newLocation) <= locationAccuracy )
       {
            newLocation = Vector3.zero;
            unit.GetComponent<Animator>().SetBool("IsMoving", false);
       }

       

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        unitNavMesh.SetDestination(unit.transform.position);
        unit.GetComponent<PlayerControls>().newPos =  Vector3.zero;
        Debug.Log("Exit movement");
    }
}


//var direction = hit.transform.position - unit.transform.position;
//unit.transform.rotation = Quaternion.Slerp(unit.transform.rotation,
//    Quaternion.LookRotation(direction),
//    rotationSpeed * Time.deltaTime);
//Debug.Log("Rotation Speed: " + rotationSpeed);