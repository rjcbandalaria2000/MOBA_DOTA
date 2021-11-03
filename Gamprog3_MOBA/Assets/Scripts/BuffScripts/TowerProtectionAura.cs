using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProtectionAura : Buff
{
    [SerializeField]
    GameObject source;
    [SerializeField]
    int bonusArmor;
    // Start is called before the first frame update
    void Start()
    {
        source = this.gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Unit collidedUnit = other.gameObject.GetComponent<Unit>();
        if (collidedUnit)
        { 
            Debug.Log("Unit Detected");
            FactionComponent collidedUnitFaction = other.gameObject.GetComponent<FactionComponent>();
            if (collidedUnitFaction)
            {
                Debug.Log("Unit Faction Detected");
                FactionComponent sourceFaction = source.GetComponent<FactionComponent>();
                if (sourceFaction)
                {
                    if(collidedUnitFaction.unitFaction == sourceFaction.unitFaction)
                    {
                        Debug.Log("Armor Buff");
                        ActivateBuff(other.gameObject);
                    }
                }
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Unit collidedUnit = other.gameObject.GetComponent<Unit>();
        if (collidedUnit)
        {
            Debug.Log("Unit Detected");
            FactionComponent collidedUnitFaction = other.gameObject.GetComponent<FactionComponent>();
            if (collidedUnitFaction)
            {
                Debug.Log("Unit Faction Detected");
                FactionComponent sourceFaction = source.GetComponent<FactionComponent>();
                if (sourceFaction)
                {
                    if (collidedUnitFaction.unitFaction == sourceFaction.unitFaction)
                    {
                        Debug.Log("Armor Buff");
                        DeactivateBuff(other.gameObject);
                    }
                }

            }
        }
    }
    public override void ActivateBuff(GameObject target)
    {
        base.ActivateBuff(target);
    }
    public override void OnActiveBuff(GameObject target)
    {
        //base.OnActiveBuff(target);
        UnitStats targetStats = target.GetComponent<UnitStats>();
        if (targetStats)
        {
            Debug.Log("Give armor");
            targetStats.SetTotalArmor(targetStats.GetBaseArmor() + bonusArmor);
        }

    }
    public override void DeactivateBuff(GameObject target)
    {
        base.DeactivateBuff(target);
    }
    public override void OnDeactiveBuff(GameObject target)
    {
        //base.OnDeactiveBuff(target);
        UnitStats targetStats = target.GetComponent<UnitStats>();
        if (targetStats)
        {
            targetStats.SetTotalArmor(targetStats.GetTotalArmor() - bonusArmor);
        }
    }
}
