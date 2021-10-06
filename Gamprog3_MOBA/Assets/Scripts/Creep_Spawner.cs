using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep_Spawner : MonoBehaviour
{
    public GameObject[] creeps;
    public List<Transform> waypoint = new List<Transform>();
   // public int creepIndex; 
    public GameObject spawnPoint;
   // public int SiegeSpawn = SingletonManager.Get<GameManager>().GetWaves() % 5;


    // Start is called before the first frame update
    void Start()
    {
        GameObject meeleMinions = Instantiate(creeps[0], spawnPoint.transform.position, Quaternion.identity);
        //GameObject rangeMinions = Instantiate(creeps[1], spawner.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
