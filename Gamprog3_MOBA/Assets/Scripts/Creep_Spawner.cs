using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep_Spawner : MonoBehaviour
{
    public GameObject[] creeps;
    public List<Transform> waypoint = new List<Transform>();
    public int creepIndex;
    public GameObject spawner;


    // Start is called before the first frame update
    void Start()
    {
        GameObject minions = Instantiate(creeps[creepIndex], spawner.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
