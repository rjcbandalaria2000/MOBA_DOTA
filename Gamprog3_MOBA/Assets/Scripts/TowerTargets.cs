using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTargets : TowerComponent
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.GetComponent<Unit>() != null)
        //{
        //    targets.Add(other.gameObject);
        //}
        if(other.gameObject.CompareTag("Creep"))
        {
            targets.Add(other.gameObject);
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.GetComponent<Unit>() != null)
        //{
        //    targets.Remove(other.gameObject);
        //}
        targets.Remove(other.gameObject);
    }
}
