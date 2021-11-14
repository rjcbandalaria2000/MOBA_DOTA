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
    [SerializeField]
    GameObject arrowIndicator;

    //public NavMeshAgent player;

    //public States unitStates;

    public Animator playerAnimator;

    public Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        //player = this.GetComponent<NavMeshAgent>();
        playerAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Unit controlledUnit = this.GetComponent<Unit>();
        if (Input.GetMouseButtonDown(1))
        {
           
            playerAnimator.SetBool("IsMoving", true);

            if (Physics.Raycast(ray.origin, ray.direction, out hit)) //&& unit.GetComponent<PlayerControls>().unitStates != States.Idle)
            {
                SpawnArrowIndicator(hit.point);
                FactionComponent targetFaction = hit.transform.gameObject.GetComponent<FactionComponent>();
                if (targetFaction)
                {
                    if (targetFaction.unitFaction != this.GetComponent<FactionComponent>().unitFaction)
                    {
                       // Unit controlledUnit = this.GetComponent<Unit>();
                        //HealthComponent healthUnit = this.GetComponent<HealthComponent>();
                        //if (healthUnit)
                        //{
                        //    if (healthUnit.isInvincible)
                        //    {
                        //        Debug.Log("Immune");
                        //        return;
                        //    }
                               
                        //}
                        //else
                        //{}
                           
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
                    //Clears the selected target
                   // Unit controlledUnit = this.GetComponent<Unit>();
                    if (controlledUnit.target)
                    {
                        controlledUnit.target = null;
                    }
                    newPos = hit.point;
                }
            } 
        }



        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnimator.SetBool("IsMoving", false);
            newPos = this.transform.position;
            //Clears the selected target 
           // Unit controlledUnit = this.GetComponent<Unit>();
            if (controlledUnit.target)
            {
                controlledUnit.target = null;
            }

        }
    }

   void SpawnArrowIndicator(Vector3 location)
    {
        GameObject spawnedArrow = Instantiate(arrowIndicator, location, Quaternion.identity);
        if (spawnedArrow)
        {
            Destroy(spawnedArrow, 0.5f);
        }
    }
}
