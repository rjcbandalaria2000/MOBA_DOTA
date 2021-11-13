using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseComponent : MonoBehaviour
{
    public List<GameObject> referenceTower;
    public HealthComponent towerHealth;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (towerHealth)
        {
            if (referenceTower != null)
            {
                towerHealth.isInvincible = true;
            }
            else if (referenceTower.Count <= 0)
            {

                referenceTower = null;
                towerHealth.isInvincible = false;

            }

        }

        if(referenceTower == null)
        {
            referenceTower.Remove(null);
        }

      
    }
}
