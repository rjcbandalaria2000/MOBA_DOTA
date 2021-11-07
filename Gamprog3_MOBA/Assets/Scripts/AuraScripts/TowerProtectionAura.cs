using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProtectionAura : Aura
{
    [SerializeField]
    GameObject source;
    [SerializeField]
    int bonusArmor;
    [SerializeField]
    GameObject buff;
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
                    if (collidedUnitFaction.unitFaction == sourceFaction.unitFaction)
                    {
                        Debug.Log("Armor Buff");
                        ActivateAura(other.gameObject);
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
                        DeactivateAura(other.gameObject);
                    }
                }

            }
        }
    }
    public override void ActivateAura(GameObject target)
    {
        base.ActivateAura(target);
    }
    public override void OnActiveAura(GameObject target)
    {
        //base.OnActiveBuff(target);
        UnitStats targetStats = target.GetComponent<UnitStats>();
        if (targetStats)
        {
            Debug.Log("Give armor");
            targetStats.SetTotalArmor(targetStats.GetBaseArmor() + bonusArmor);
        }

    }
    public override void DeactivateAura(GameObject target)
    {
        base.DeactivateAura(target);
    }
    public override void OnDeactiveAura(GameObject target)
    {
        //base.OnDeactiveBuff(target);
        UnitStats targetStats = target.GetComponent<UnitStats>();
        if (targetStats)
        {
            targetStats.SetTotalArmor(targetStats.GetTotalArmor() - bonusArmor);
        }
    }
}
