using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Script : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public NavMeshAgent creepNavMesh;
    public int waypointIndex = 0;
    public Transform lastWaypoint;
    [SerializeField]
    Animator aiAnimator;
    public List<GameObject> targets;
    // Start is called before the first frame update
    void Start()
    {
        // creepNavMesh = this.gameObject.GetComponent<NavMeshAgent>();
        aiAnimator = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Unit aiUnit = this.gameObject.GetComponent<Unit>();
        if (targets.Count > 0)
        {
            //Unit aiUnit = this.gameObject.GetComponent<Unit>();
            if (aiUnit)
            {
                if(aiUnit.target == null)
                {
                    for (int i = 0; i < targets.Count; i++)
                    {
                        if(targets[i] != null)
                        {
                            aiUnit.target = targets[i];
                            break;
                        }
                        else
                        {
                            targets.RemoveAt(i);
                        }

                    } 
                }
            }
        }
        if(aiUnit.target == null)
        {
            aiAnimator.SetBool("IsMoving", true);
        }
    }

    
}
