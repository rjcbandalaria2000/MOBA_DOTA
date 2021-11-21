using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseComponent : MonoBehaviour
{
    public List<GameObject> referenceTower;
    public HealthComponent towerHealth;
    int towerTracker;
    HealthComponent baseHealthComponent;
    // Start is called before the first frame update
    void Start()
    {
        towerTracker = referenceTower.Count;
        baseHealthComponent = this.gameObject.GetComponent<HealthComponent>();
        baseHealthComponent.death.AddListener(OnBaseDeath);
    }

    // Update is called once per frame
    void Update()
    {
        if(towerTracker <= 0)
        {
            HealthComponent baseHealthComponent = this.gameObject.GetComponent<HealthComponent>();
            baseHealthComponent.isInvincible = false;
        }
        else
        {
            HealthComponent baseHealthComponent = this.gameObject.GetComponent<HealthComponent>();
            baseHealthComponent.isInvincible = true;
        }

        
        for(int i = 0; i < referenceTower.Count; i++)
        {
            if(referenceTower[i] == null)
            {
                Debug.Log("One Tower Destroyed");
                referenceTower.RemoveAt(i);
                towerTracker--;
            }
           
        }
      
    }

    void OnBaseDeath(HealthComponent healthComponent)
    {
        Collider baseCollider = this.gameObject.GetComponent<Collider>();
        if (baseCollider)
        {
            baseCollider.enabled = false;
        }
        MeshRenderer baseMeshRenderer = this.gameObject.GetComponent<MeshRenderer>();


    }
}
