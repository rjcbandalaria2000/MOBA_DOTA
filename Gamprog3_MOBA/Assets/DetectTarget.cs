using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTarget : MonoBehaviour
{
    GameObject unit;
    SphereCollider sphereCollider;
    //public Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        unit = this.transform.parent.gameObject;
        sphereCollider = this.GetComponent<SphereCollider>();
        //sphereCollider.radius = unit.GetComponent<Unit>().attackRange / GameManager.distanceUnit;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    FactionComponent targetFaction = other.gameObject.GetComponent<FactionComponent>();
    //    if (targetFaction)
    //    { 
    //        if (targetFaction.unitFaction != this.transform.parent.gameObject.GetComponent<FactionComponent>().unitFaction)
    //        {
    //            Unit targetUnit = other.gameObject.GetComponent<Unit>();
    //            if (targetUnit)
    //            {
    //                //unit.GetComponent<Unit>().target = targetUnit.gameObject;
    //                // unit.GetComponent<PlayerControls>().unitStates = States.Attacking;
    //                // playerAnimator.SetBool("IsAttacking", true);
    //                //Debug.Log("Attacking Enemy");
    //            }
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    unit.GetComponent<Unit>().target = null;
    //    Debug.Log("No Target");
    //}
}
