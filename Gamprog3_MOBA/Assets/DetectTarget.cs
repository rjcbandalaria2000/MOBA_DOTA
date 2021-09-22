using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTarget : MonoBehaviour
{
    GameObject unit;
    public Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        unit = this.transform.parent.gameObject;
        playerAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        FactionComponent targetFaction = other.gameObject.GetComponent<FactionComponent>();
        if (targetFaction.unitFaction != this.transform.parent.gameObject.GetComponent<FactionComponent>().unitFaction)
        {
            Unit targetUnit = other.gameObject.GetComponent<Unit>();
            if (targetUnit)
            {
                // unit.GetComponent<PlayerControls>().unitStates = States.Attacking;
                playerAnimator.SetBool("IsAttacking", true);
                Debug.Log("Attacking Enemy");
            }
        }
    }
}
