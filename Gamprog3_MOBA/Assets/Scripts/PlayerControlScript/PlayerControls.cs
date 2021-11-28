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
        // On Right Click 
        if (Input.GetMouseButtonDown(1))
        {
            //playerAnimator.SetBool("IsMoving", true);

            if (Physics.Raycast(ray.origin, ray.direction, out hit)) //&& unit.GetComponent<PlayerControls>().unitStates != States.Idle)
            {
                SpawnArrowIndicator(hit.point);
                Unit unitTarget = hit.transform.gameObject.GetComponent<Unit>();
                if (unitTarget)
                {
                    FactionComponent unitFaction = unitTarget.gameObject.GetComponent<FactionComponent>();
                    if(unitFaction.unitFaction != controlledUnit.GetComponent<FactionComponent>().unitFaction)
                    {
                        HealthComponent unitHealthComponent = unitTarget.gameObject.GetComponent<HealthComponent>();
                        if (unitHealthComponent)
                        {
                            if (unitHealthComponent.isInvincible)
                            {
                                Debug.Log("Is Invincible");
                                controlledUnit.target = null;
                            }
                            else
                            {
                                controlledUnit.target = unitTarget.gameObject;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("Friendly Unit");
                    }
                }
                else
                {
                    playerAnimator.SetBool("IsMoving", true);
                    if (controlledUnit.target)
                    {
                        controlledUnit.target = null;
                    }
                    newPos = hit.point;
                    Debug.Log("Move to location: " + newPos);
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
                    if(controlledUnit.gameObject.GetComponent<ManaComponent>().GetCurrentMana() > controlledUnit.unitSkills[1].getManaCost() && controlledUnit.unitSkills[1].isCoolDown == false)
                    {
                        if(controlledUnit.unitSkills[1].skillLevel > 0)
                        {
                            controlledUnit.gameObject.GetComponent<ManaComponent>().SetCurrentMana(controlledUnit.gameObject.GetComponent<ManaComponent>().GetCurrentMana() - controlledUnit.unitSkills[1].getManaCost());
                            controlledUnit.unitSkills[1].skillIndex = 0;
                            controlledUnit.unitSkills[1].ActivateSkill(skillTarget, this.gameObject); //Change in state machine
                        }
                        else
                        {
                            Debug.Log("Skill Not Yet Learned");
                        }
                        
                    }
                    else
                    {
                            Debug.Log("Insufficient Mana");
                    }
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

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Unit unitSelected = hitInfo.transform.gameObject.GetComponent<Unit>();
                FactionComponent targetFaction = hitInfo.transform.gameObject.GetComponent<FactionComponent>();


                Debug.Log("WaveofTerror");
                Debug.Log(hitInfo.transform.gameObject + " is the target");
                if (controlledUnit.gameObject.GetComponent<ManaComponent>().GetCurrentMana() > controlledUnit.unitSkills[2].getManaCost() && controlledUnit.unitSkills[2].isCoolDown == false)
                {
                    if(controlledUnit.unitSkills[2].skillLevel > 0)
                    {
                        controlledUnit.gameObject.GetComponent<ManaComponent>().SetCurrentMana(controlledUnit.gameObject.GetComponent<ManaComponent>().GetCurrentMana() - controlledUnit.unitSkills[1].getManaCost());
                        controlledUnit.unitSkills[2].skillIndex = 1;
                        controlledUnit.unitSkills[2].ActivateSkill(null, this.gameObject); //Change in state machine
                    }
                    else
                    {
                        Debug.Log("Skill Not Yet Learned");
                    }

                }
                else
                {
                    Debug.Log("Insufficient Mana");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Pressed R");
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                GameObject unitTarget = hitInfo.transform.gameObject;
                if (controlledUnit.gameObject.GetComponent<ManaComponent>().GetCurrentMana() > controlledUnit.unitSkills[4].getManaCost() && controlledUnit.unitSkills[4].isCoolDown == false)
                {
                    Debug.Log("Not Cooldown and Has Mana");
                    if (controlledUnit.unitSkills[4].skillLevel > 0)
                    {
                        controlledUnit.gameObject.GetComponent<ManaComponent>().SetCurrentMana(controlledUnit.gameObject.GetComponent<ManaComponent>().GetCurrentMana() - controlledUnit.unitSkills[4].getManaCost());
                        controlledUnit.unitSkills[4].skillIndex = 3;
                        controlledUnit.unitSkills[4].ActivateSkill(unitTarget, this.gameObject); //Change in state machine
                        Debug.Log("Activate Skill");
                    }
                    else
                    {
                        Debug.Log("Skill Not Yet Learned");
                    }
                    
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


//FactionComponent targetFaction = hit.transform.gameObject.GetComponent<FactionComponent>();
////Check if there is faction 
//if (targetFaction)
//{
//    // If faction is opposite to player 
//    if (targetFaction.unitFaction != this.GetComponent<FactionComponent>().unitFaction)
//    {
//        //Set Target
//        controlledUnit.target = hit.transform.gameObject;
//        Debug.Log("Attack Unit");

//        if (controlledUnit.target.GetComponent<TowerComponent>() != null || controlledUnit.target.GetComponent<BaseComponent>() != null)
//        {
//            if (controlledUnit.target.GetComponent<HealthComponent>().isInvincible)
//            {
//                Debug.Log("Cant Target. Its invincible");
//                controlledUnit.target = null;
//                return;
//            }
//        }
//    }
//    //else
//    //{
//    //    //playerAnimator.SetBool("IsMoving", false);
//    //    controlledUnit.target = null;
//    //    //newPos = hit.point;
//    //    Debug.Log("Friendly");
//    //}
//}
//else // Set Position of Player 
//{
//    //Clears the selected target
//   // Unit controlledUnit = this.GetComponent<Unit>();
//    if (controlledUnit.target)
//    {
//        controlledUnit.target = null;
//    }
//    newPos = hit.point;
//    Debug.Log(hit.transform.name);
//}