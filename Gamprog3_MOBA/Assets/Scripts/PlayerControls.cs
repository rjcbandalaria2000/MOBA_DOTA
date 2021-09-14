using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControls : MonoBehaviour
{
    //public GameObject player;

    public NavMeshAgent player;

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                player.SetDestination(hit.point);
            }
        }
    }
}
