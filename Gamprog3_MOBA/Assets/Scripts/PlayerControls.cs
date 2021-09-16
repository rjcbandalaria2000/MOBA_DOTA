using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum States
{
    Idle,
    Moving,
    Attacking,
}

public class PlayerControls : MonoBehaviour
{
    //public GameObject player;

    //public NavMeshAgent player;

    public States unitStates;

    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //player = this.GetComponent<NavMeshAgent>();
        playerAnimator = this.GetComponent<Animator>();
        unitStates = States.Idle;

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(1))
       {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                FactionComponent targetFaction = hit.transform.gameObject.GetComponent<FactionComponent>();
                if (targetFaction)
                {
                    if(targetFaction.unitFaction != this.GetComponent<FactionComponent>().unitFaction)
                    {
                        
                        Debug.Log("Attack Unit");
                    }
                    else
                    {
                        Debug.Log("Friendly");
                    }
                }
                else
                {
                    unitStates = States.Moving;
                }
            }
           
            
       }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnimator.SetBool("isMoving", false);
            unitStates = States.Idle;
        }

       if (unitStates == States.Moving)
       {
           playerAnimator.SetBool("isMoving", true);
       }
       else
       {
           playerAnimator.SetBool("isMoving", false);
           unitStates = States.Idle;
       }
    }
}
