using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep_Spawner : MonoBehaviour
{
    public GameObject[] creeps;
    public List<Transform> waypoint = new List<Transform>();
    [SerializeField]
    Faction faction;
    public GameObject spawnPoint;
    [SerializeField] int waves = 1;
    //public Creeps_ScriptableObject creepScript;

    public int creepQuantity;
    public float delayTime;
    public float waveDelayTime;

    // Start is called before the first frame update
    void Start()
    {
        //CreepSpawning(3);
        StartCoroutine(SpawnCreepsRoutine());
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator SpawnCreepsRoutine()
    {
        while (true)
        {
            this.waves += 1;

            for (int i = 0; i < creepQuantity; i++)
            {
                yield return new WaitForSeconds(delayTime);
                Debug.Log("SpawnTime");
                CreepSpawning();
            }

            if (waves % 5 == 0 && waves > 0 && creeps[1] != null)
            {
                yield return new WaitForSeconds(delayTime);
                siegeSpawn();
            }
           
            Debug.Log("FinishSpawning"); 
            
          
            yield return new WaitForSeconds(waveDelayTime);

            
        }
       


    }

    void CreepSpawning()
    {
        //Debug.Log("Spawn for the love of God");
        GameObject minions = Instantiate(creeps[0], spawnPoint.transform.position, Quaternion.identity);
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
        GameObject siege = Instantiate(creeps[1], spawnPoint.transform.position, Quaternion.identity);
        AI_Script siegeAI = siege.gameObject.GetComponent<AI_Script>();
        if (siegeAI)
        {
            siegeAI.waypoints = waypoint;
        }
       
    }

    void spawnSuperCreep()
    {
        GameObject superCreep = Instantiate(creeps[2], spawnPoint.transform.position, Quaternion.identity);
        AI_Script superCreepAI = superCreep.gameObject.GetComponent<AI_Script>();
        if(superCreepAI)
        {
            superCreepAI.waypoints = waypoint;
        }
    }
}
