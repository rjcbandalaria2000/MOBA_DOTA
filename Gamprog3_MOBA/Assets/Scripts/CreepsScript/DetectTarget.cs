using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTarget : MonoBehaviour
{
    [SerializeField]GameObject unit;
    [SerializeField]SphereCollider sphereCollider;
    [SerializeField] float radiusOffset;
    [SerializeField] float sightRadius;
    // Start is called before the first frame update
    void Start()
    {
        InitializeCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Unit detectedTarget = other.gameObject.GetComponent<Unit>();
        if (detectedTarget)
        {
            FactionComponent targetFaction = other.GetComponent<FactionComponent>();
            if (targetFaction)
            {
                if(unit.GetComponent<FactionComponent>().unitFaction != targetFaction.unitFaction)
                {
                    AI_Script unitAI = unit.GetComponent<AI_Script>();
                    if (unitAI)
                    {
                        unitAI.targets.Add(detectedTarget.gameObject);
                    }
                    //Unit unitParent = unit.GetComponent<Unit>();
                    //if (unitParent)
                    //{
                    //    unitParent.SetTarget(detectedTarget.gameObject);
                    //}
                }
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Unit detectedTarget = other.gameObject.GetComponent<Unit>();
        if (detectedTarget)
        {
            FactionComponent targetFaction = other.GetComponent<FactionComponent>();
            if (targetFaction)
            {
                if (unit.GetComponent<FactionComponent>().unitFaction != targetFaction.unitFaction)
                {
                    AI_Script unitAI = unit.GetComponent<AI_Script>();
                    if (unitAI)
                    {
                        unitAI.targets.Remove(detectedTarget.gameObject);
                    }
                    //Unit unitParent = unit.GetComponent<Unit>();
                    //if (unitParent)
                    //{
                    //    unitParent.SetTarget(detectedTarget.gameObject);
                    //}
                }
            }

        }
    }
    void InitializeCollider()
    {   
        unit = this.transform.parent.gameObject;
        sphereCollider = this.GetComponent<SphereCollider>();
        if (sphereCollider)
        {
            UnitStats unitStats = unit.GetComponent<UnitStats>();
            sphereCollider.radius = (sightRadius / GameManager.distanceUnit) + radiusOffset; //(unitStats.GetAttackRange() / GameManager.distanceUnit) + radiusOffset;
        }
    }
}
