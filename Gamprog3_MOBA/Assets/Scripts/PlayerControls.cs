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

    //public States unitStates;

    public Animator playerAnimator;

    public Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        //player = this.GetComponent<NavMeshAgent>();
        playerAnimator = this.GetComponent<Animator>();

    

       // unitStates = States.Idle;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(1))
        {
           
            playerAnimator.SetBool("IsMoving", true);

            if (Physics.Raycast(ray.origin, ray.direction, out hit)) //&& unit.GetComponent<PlayerControls>().unitStates != States.Idle)
            {
                FactionComponent targetFaction = hit.transform.gameObject.GetComponent<FactionComponent>();
                if (targetFaction)
                {
                    if (targetFaction.unitFaction != this.GetComponent<FactionComponent>().unitFaction)
                    {
                        Unit controlledUnit = this.GetComponent<Unit>();
                        controlledUnit.target = hit.transform.gameObject;
                        Debug.Log("Attack Unit");

                    }
                    else
                    {
                        Debug.Log("Friendly");
                    }
                }
                else
                {
                    newPos = hit.point;
                }
            } 
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnimator.SetBool("IsMoving", false);
            newPos = this.transform.position;
           
        }
    }

   
}
