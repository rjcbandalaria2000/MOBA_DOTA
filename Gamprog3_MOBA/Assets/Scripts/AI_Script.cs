using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Script : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public NavMeshAgent creepNavMesh;
    public int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
       // creepNavMesh = this.gameObject.GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToWaypoint()
    {
        
        if(waypoints.Count > 0)
        {
            Debug.Log("Go to waypoint");
            creepNavMesh.SetDestination(waypoints[waypointIndex].position);
        }
        else
        {
            Debug.Log("NUll");

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Waypoint"))
        {
            waypointIndex += 1;
            moveToWaypoint();
        }
    }
}
