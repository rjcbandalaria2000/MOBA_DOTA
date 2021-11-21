using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerUpgrade : MonoBehaviour
{
    public GameObject redBarracks;
    public GameObject blueBarracks;

    public GameObject redSpawner;
    public GameObject blueSpawner;
   
    // Start is called before the first frame update
    void Start()
    {
        if (redBarracks)
        {
            HealthComponent redSpawnerHealth = redBarracks.GetComponent<HealthComponent>();
            redSpawnerHealth.death.AddListener(UpgradeBlueSpawner);
        }
        if (blueBarracks)
        {
            HealthComponent blueSpawnerHealth = blueBarracks.GetComponent<HealthComponent>();
            blueSpawnerHealth.death.AddListener(UpgradeRedSpawner);
        }
    }

    void UpgradeBlueSpawner(HealthComponent spawner)
    {
        if (redBarracks != null)
        {
            //Debug.Log(redSpawner.name);
            HealthComponent redSpawnerHealth = redBarracks.GetComponent<HealthComponent>();
            if (redSpawnerHealth)
            {
                //redSpawnerHealth.death.AddListener()
                if (redSpawnerHealth.GetIsDead() == true)
                {
                    if (!blueBarracks.GetComponent<Creep_Spawner>().isSpawningSuperCreeps)
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
        if (blueBarracks != null)
        {
            //Debug.Log(blueSpawner.name);
            HealthComponent blueSpawnerHealth = blueBarracks.GetComponent<HealthComponent>();
            if (blueSpawnerHealth)
            {
                if (blueSpawnerHealth.GetIsDead() == true)
                {
                    if (!redBarracks.GetComponent<Creep_Spawner>().isSpawningSuperCreeps)
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
