using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTargets : MonoBehaviour
{
    [SerializeField]TowerComponent tower;

    // Start is called before the first frame update
    void Start()
    {
        tower = this.gameObject.GetComponentInParent<TowerComponent>();
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
                if (tower.GetComponent<FactionComponent>().unitFaction != targetFaction.unitFaction)
                {
                   
                    if (tower)
                    {
                        tower.targets.Add(detectedTarget.gameObject);
                    }
                    
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
                if (tower.GetComponent<FactionComponent>().unitFaction != targetFaction.unitFaction)
                {

                    if (tower)
                    {
                        tower.targets.Remove(detectedTarget.gameObject);
                    }

                }
            }
        }
    }
}
