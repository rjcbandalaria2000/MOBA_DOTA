using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep_Spawner : MonoBehaviour
{
    public GameObject[] creeps;
    public List<Transform> waypoint = new List<Transform>();
    [SerializeField]

    public GameObject spawnPoint;
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
            yield return new WaitForSeconds(5.0f);
            Debug.Log("SpawnTime");
        
            CreepSpawning(3);
        }
    }

    void CreepSpawning(int numOfCreeps)
    {
        for (int i = 0; i < numOfCreeps; i++)
        {
            Debug.Log("Spawn for the love of God");
            GameObject minions = Instantiate(creeps[0], spawnPoint.transform.position, Quaternion.identity);
           // Unit spawnedMinion = minions.gameObject.GetComponent<Unit>();

            AI_Script minionAI = minions.gameObject.GetComponent<AI_Script>();
            if(minionAI)
            {
                minionAI.waypoints = waypoint;
                //minionAI.moveToWaypoint();
            }

            //if (spawnedMinion)
            //{
            //    //spawnedMinion.SetDamage(creepScript.ATK);
            //}
        }
    }
}