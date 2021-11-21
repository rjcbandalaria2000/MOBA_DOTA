using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GrowthStats
{
    public float healthGrowth;
    public float attackGrowth;
    public int goldGrowth;
    public int experienceGrowth;
}

public class Creep_Spawner : MonoBehaviour
{
   // public GameObject[] creeps;
    public GameObject regularCreeps;
    public GameObject SiegeCreep;
    public GameObject SuperCreep;

    public List<Transform> waypoint = new List<Transform>();
    [SerializeField]
    Faction faction;
    public GameObject spawnPoint;
    [SerializeField] int waves = 1;
    //public Creeps_ScriptableObject creepScript;
    [SerializeField]
    AttackType buildingAttackType;
    public int creepQuantity;
    public float delayTime;
    public float waveDelayTime;
    public bool isSpawningSuperCreeps;

    private Coroutine spawnRoutine;
    private Coroutine creepGrowth;
    // Start is called before the first frame update
    void Start()
    {

        spawnRoutine = StartCoroutine(SpawnCreepsRoutine());
        creepGrowth = StartCoroutine(CreepGrowthRoutine());
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    IEnumerator CreepGrowthRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(180f);
            Debug.Log("CreepGrowth");
            UnitStats creepStats = regularCreeps.GetComponent<UnitStats>();
            if (creepStats)
            {
                //For testing
                creepStats.SetBaseHP(creepStats.GetBaseHP() + 9);

            }
        }
        
    }
    IEnumerator SpawnCreepsRoutine()
    {
        while (true)
        {
            this.waves += 1;
            yield return new WaitForSeconds(waveDelayTime);
            for (int i = 0; i < creepQuantity; i++)
            {
                yield return new WaitForSeconds(delayTime);
                Debug.Log("SpawnTime");
                CreepSpawning();
            }

            if (waves % 5 == 0 && waves > 0 && SiegeCreep != null)
            {
                yield return new WaitForSeconds(delayTime);
                siegeSpawn();
            }
           
            Debug.Log("FinishSpawning"); 
            
          
            

            
        }

    }

    void CreepSpawning()
    {
        //Debug.Log("Spawn for the love of God");
        GameObject minions = Instantiate(regularCreeps, spawnPoint.transform.position, Quaternion.identity);
        // Unit spawnedMinion = minions.gameObject.GetComponent<Unit>();
        FactionComponent minionFaction = minions.GetComponent<FactionComponent>();

        if (minionFaction)
        { 
            minionFaction.unitFaction = faction;
        }
        AI_Script minionAI = minions.gameObject.GetComponent<AI_Script>();

        if (minionAI)
        {
            minionAI.waypoints = waypoint;
            //minionAI.moveToWaypoint();
        }
    }

    void siegeSpawn()
    {

        Debug.Log("Siege Spawn");
        GameObject siege = Instantiate(SiegeCreep, spawnPoint.transform.position, Quaternion.identity);
        AI_Script siegeAI = siege.gameObject.GetComponent<AI_Script>();
        if (siegeAI)
        {
            siegeAI.waypoints = waypoint;
        }
       
    }

    void spawnSuperCreep()
    {
        Debug.Log("Spawning Super Creeps");
        GameObject superCreep = Instantiate(SuperCreep, spawnPoint.transform.position, Quaternion.identity);
        AI_Script superCreepAI = superCreep.gameObject.GetComponent<AI_Script>();
        if(superCreepAI)
        {
            superCreepAI.waypoints = waypoint;
        }
    }
    
    public void StopSpawningNormalCreeps()
    {
        Debug.Log("Stop Normal Spawning");
        StopCoroutine(spawnRoutine);
    }

    public void StartSpawnSuperCreeps()
    {
        StartCoroutine(SpawnSuperCreeps());
    }

    IEnumerator SpawnSuperCreeps()
    {
        while (true)
        {
            this.waves += 1;

            for (int i = 0; i < creepQuantity; i++)
            {
                yield return new WaitForSeconds(delayTime);
                Debug.Log("SpawnTime");
                spawnSuperCreep();
            }

            if (waves % 5 == 0 && waves > 0 && SiegeCreep != null)
            {
                yield return new WaitForSeconds(delayTime);
                siegeSpawn();
            }

            Debug.Log("FinishSpawning");
            yield return new WaitForSeconds(waveDelayTime);
        }

    }
}
