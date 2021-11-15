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
                        controlledUnit.target = hit.transform.gameObject;
                        Debug.Log("Attack Unit");

                        if (controlledUnit.target.GetComponent<TowerComponent>() != null || controlledUnit.target.GetComponent<BaseComponent>() != null)
                        {
                            if (controlledUnit.target.GetComponent<HealthComponent>().isInvincible)
                            {
                                Debug.Log("Cant Target. Its invincible");
                                controlledUnit.target = null;
                                return;
                            }
                        }
                    }
                    else
                    {
                        playerAnimator.SetBool("IsMoving", false);
                        controlledUnit.target = null;
                        newPos = hit.point;
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
          
          if (Physics.Raycast(ray, out RaycastHit hitInfo))
          {
            Unit unitSelected = hitInfo.transform.gameObject.GetComponent<Unit>();
            FactionComponent targetFaction = hitInfo.transform.gameObject.GetComponent<FactionComponent>();
            GameObject skillTarget = unitSelected.gameObject;
            //TowerComponent towerSelected = hitInfo.transform.gameObject.GetComponent<TowerComponent>();

            if (unitSelected && !unitSelected.GetComponent<TowerComponent>() && !unitSelected.GetComponent<BaseComponent>())
            {
               if (targetFaction.unitFaction != this.GetComponent<FactionComponent>().unitFaction)
               {
                    Debug.Log("MagicMissle");
                    Debug.Log(unitSelected.gameObject + " is the target");
                    controlledUnit.unitSkills[1].ActivateSkill(skillTarget, this.gameObject); //Change in state machine
               }
               else
               {
                    Debug.Log("Invalid Target skill");
               }

            }
            else
            {
              Debug.Log("Invalid Target skill");
            }
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
