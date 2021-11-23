using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EXPReceiver : MonoBehaviour
{
    SphereCollider expSphereCollider;
    [SerializeField]
    float expRadius = 1600;
    [SerializeField]
    LevelComponent unitLevelComponent;
    [SerializeField]
    List<GameObject> unitsInRange;
    // Start is called before the first frame update
    void Start()
    {
        expSphereCollider = this.gameObject.GetComponent<SphereCollider>();
        Assert.IsNotNull(expSphereCollider, "Exp Radius Detector not initialized");
        expSphereCollider.radius = expRadius / GameManager.distanceUnit;
        unitLevelComponent = this.gameObject.transform.parent.gameObject.GetComponent<LevelComponent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Unit unitDetected = other.gameObject.GetComponent<Unit>();
        if (unitDetected)
        {
            FactionComponent unitDetectedFaction = unitDetected.gameObject.GetComponent<FactionComponent>();
            FactionComponent sourceFaction = this.gameObject.transform.parent.gameObject.GetComponent<FactionComponent>();
            if (unitDetectedFaction)
            {

                if(unitDetectedFaction.unitFaction != sourceFaction.unitFaction)
                {
                    unitsInRange.Add(unitDetected.gameObject);
                    HealthComponent unitDetectedHP = unitDetected.gameObject.GetComponent<HealthComponent>();
                    LevelComponent unitLevelComponent = unitDetected.gameObject.GetComponent<LevelComponent>();
                    if (unitDetectedHP)
                    {
                        if (unitLevelComponent) 
                        {
                            unitLevelComponent.numOfHeroesInRadius += 1;
                        
                        }
                        unitDetectedHP.death.AddListener(ReceiveExperiencePoints);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Unit unitDetected = other.gameObject.GetComponent<Unit>();
        if (unitDetected)
        {
            FactionComponent unitDetectedFaction = unitDetected.gameObject.GetComponent<FactionComponent>();
            FactionComponent sourceFaction = this.gameObject.transform.parent.gameObject.GetComponent<FactionComponent>();
            if (unitDetectedFaction)
            {

                if (unitDetectedFaction.unitFaction != sourceFaction.unitFaction)
                {
                    unitsInRange.Remove(unitDetected.gameObject);
                    HealthComponent unitDetectedHP = unitDetected.gameObject.GetComponent<HealthComponent>();
                    LevelComponent unitLevelComponent = unitDetected.gameObject.GetComponent<LevelComponent>();
                    if (unitDetectedHP)
                    {
                        if (unitLevelComponent)
                        {
                            unitLevelComponent.numOfHeroesInRadius -= 1;

                        }
                       
                        unitDetectedHP.death.RemoveListener(ReceiveExperiencePoints);
                    }
                }
            }
        }
    }

    public void ReceiveExperiencePoints(HealthComponent healthComponent)
    {
        GameObject unitDied = healthComponent.gameObject;
        if (unitDied)
        {
            LevelComponent unitDiedLevelComponent = unitDied.GetComponent<LevelComponent>();
            if (unitDiedLevelComponent)
            {
                unitLevelComponent.GainExp(unitDiedLevelComponent.GiveExp());
            }
            

        }
    }
    
}
