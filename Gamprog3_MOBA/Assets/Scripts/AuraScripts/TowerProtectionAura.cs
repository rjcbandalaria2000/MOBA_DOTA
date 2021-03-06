using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProtectionAura : Aura
{
    [SerializeField]
    GameObject owner;
    [SerializeField]
    GameObject buff;
    // Start is called before the first frame update
    void Start()
    {
        owner = this.gameObject.transform.parent.gameObject;
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
                FactionComponent sourceFaction = owner.GetComponent<FactionComponent>();
                if (sourceFaction)
                {
                    if (collidedUnitFaction.unitFaction == sourceFaction.unitFaction)
                    {
                        Debug.Log("Aura Given To: " + other.gameObject.name);
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
                FactionComponent sourceFaction = owner.GetComponent<FactionComponent>();
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
        Buff towerBuff = Instantiate(buff.GetComponent<Buff>());
        towerBuff.targetUnit = target;
        towerBuff.gameObject.transform.parent = target.transform;
        towerBuff.ActivateBuff(target);
    }
    public override void DeactivateAura(GameObject target)
    {
        base.DeactivateAura(target);
    }
    public override void OnDeactiveAura(GameObject target)
    {
        TowerProtectionBuff targetTowerBuff = target.GetComponentInChildren<TowerProtectionBuff>();
        if (targetTowerBuff)
        {
            targetTowerBuff.DeactivateBuff(target);
            Destroy(targetTowerBuff.gameObject);
        }

    }
}
