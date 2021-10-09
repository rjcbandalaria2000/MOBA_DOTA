using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : UnitStateMachine
{

    public AI_Script aiMovement;
    public NavMeshAgent aiNavMesh;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        aiMovement = unit.GetComponent<AI_Script>();
        aiNavMesh = unit.GetComponent<NavMeshAgent>();
    }

 
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (aiMovement)
        {
            float distanceToWaypoint = Vector3.Distance(unit.transform.position, 
                aiMovement.waypoints[aiMovement.waypointIndex].position);
            if(distanceToWaypoint > locationAccuracy)
            {
                GoToWaypoint();
            }
            else if(distanceToWaypoint <= locationAccuracy)
            {
                if(aiMovement.waypointIndex < aiMovement.waypoints.Count)
                {
                    aiMovement.waypointIndex++;
                }
                
            }
            
        }

    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    void GoToWaypoint()
    {
        if (aiMovement.waypoints.Count > 0)
        {
            if (aiMovement.waypointIndex < aiMovement.waypoints.Count)
            { 
                if (aiNavMesh)
                { 
                    aiNavMesh.SetDestination(aiMovement.waypoints[aiMovement.waypointIndex].position);
                }

            }
            
        }
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
