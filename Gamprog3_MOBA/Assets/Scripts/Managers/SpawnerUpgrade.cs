using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerUpgrade : MonoBehaviour
{
    public GameObject redSpawner;
    public GameObject blueSpawner;

    //public UnityEvent onDestroySpawner;

    //public List<GameObject> midSpawners;
   
    // Start is called before the first frame update
    void Start()
    {
        if (redSpawner)
        {
            HealthComponent redSpawnerHealth = redSpawner.GetComponent<HealthComponent>();
            redSpawnerHealth.death.AddListener(UpgradeBlueSpawner);
        }
        if (blueSpawner)
        {
            HealthComponent blueSpawnerHealth = blueSpawner.GetComponent<HealthComponent>();
            blueSpawnerHealth.death.AddListener(UpgradeRedSpawner);
        }
    }

    void UpgradeBlueSpawner(HealthComponent spawner)
    {
        if (redSpawner != null)
        {
            //Debug.Log(redSpawner.name);
            HealthComponent redSpawnerHealth = redSpawner.GetComponent<HealthComponent>();
            if (redSpawnerHealth)
            {
                //redSpawnerHealth.death.AddListener()
                if (redSpawnerHealth.GetIsDead() == true)
                {
                    if (!blueSpawner.GetComponent<Creep_Spawner>().isSpawningSuperCreeps)
                    {
                        blueSpawner.GetComponent<Creep_Spawner>().isSpawningSuperCreeps = true;
                        //Debug.Log("Red Spawner is Dead");
                        blueSpawner.GetComponent<Creep_Spawner>().StopSpawningNormalCreeps();
                        blueSpawner.GetComponent<Creep_Spawner>().StartSpawnSuperCreeps();
                    }

                }
            }

        }
    }
    void UpgradeRedSpawner(HealthComponent spawner)
    {
        if (blueSpawner != null)
        {
            //Debug.Log(blueSpawner.name);
            HealthComponent blueSpawnerHealth = blueSpawner.GetComponent<HealthComponent>();
            if (blueSpawnerHealth)
            {
                if (blueSpawnerHealth.GetIsDead() == true)
                {
                    if (!redSpawner.GetComponent<Creep_Spawner>().isSpawningSuperCreeps)
                    {
                        redSpawner.GetComponent<Creep_Spawner>().isSpawningSuperCreeps = true;
                        //Debug.Log("Red Spawner is Dead");
                        redSpawner.GetComponent<Creep_Spawner>().StopSpawningNormalCreeps();
                        redSpawner.GetComponent<Creep_Spawner>().StartSpawnSuperCreeps();
                    }

                }
            }

        }
    }
}
