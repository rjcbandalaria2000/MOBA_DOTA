using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class VengefulAura : Aura
{
    [SerializeField]
    GameObject source;
    [SerializeField]
    int auraRange;
    [SerializeField]
    SphereCollider auraDetector;
    [SerializeField]
    GameObject buffPrefab;
    // Start is called before the first frame update
    void Start()
    {
        source = this.gameObject.transform.parent.gameObject;
        auraDetector = this.GetComponent<SphereCollider>();
        Assert.IsNotNull(auraDetector);
        auraDetector.radius = auraRange / GameManager.distanceUnit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ActivateAura(GameObject target)
    {
        base.ActivateAura(target);
    }
    public override void DeactivateAura(GameObject target)
    {
        base.DeactivateAura(target);
    }
    public override void OnActiveAura(GameObject target)
    {
        //base.OnActiveAura(target);
        Buff vengefulBuff = Instantiate(buffPrefab.GetComponent<Buff>());
        vengefulBuff.targetUnit = target;
        vengefulBuff.gameObject.transform.parent = target.transform;
        vengefulBuff.ActivateBuff(target);

    }
    public override void OnDeactiveAura(GameObject target)
    {
        //base.OnDeactiveAura(target);
        VengefulAuraBuff vengefulAuraBuff = target.GetComponentInChildren<VengefulAuraBuff>();
        Assert.IsNotNull(vengefulAuraBuff);
        vengefulAuraBuff.DeactivateBuff(target);
        Destroy(vengefulAuraBuff.gameObject);
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
                        Debug.Log("Aura Given To: " + other.gameObject.name);
                        Debug.Log("Vengeful Buff");
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
                        Debug.Log("Vengeful Aura Removed");
                        DeactivateAura(other.gameObject);
                    }
                }

            }
        }
    }
}
