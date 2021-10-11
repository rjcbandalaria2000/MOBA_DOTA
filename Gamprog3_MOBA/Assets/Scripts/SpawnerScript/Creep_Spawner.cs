using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep_Spawner : MonoBehaviour
{
    public GameObject[] creeps;
    public List<Transform> waypoint = new List<Transform>();
    [SerializeField]

    public GameObject spawnPoint;
    [SerializeField] int waves = 1;
    //public Creeps_ScriptableObject creepScript;


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
          
            if (waves % 5 == 0 && waves > 0 && creeps[1] != null)
            {
                yield return new WaitForSeconds(1.0f);
                siegeSpawn();
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    yield return new WaitForSeconds(1.0f);
                    Debug.Log("SpawnTime");
                    CreepSpawning();
                }
            }

            Debug.Log("FinishSpawning"); 
            
            this.waves += 1;
            yield return new WaitForSeconds(5.0f);

            
        }
       


    }

    

    void CreepSpawning()
    {

        //Debug.Log("Spawn for the love of God");
        GameObject minions = Instantiate(creeps[0], spawnPoint.transform.position, Quaternion.identity);
        // Unit spawnedMinion = minions.gameObject.GetComponent<Unit>();

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
}
