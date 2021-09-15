using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectControlPrototype : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                Debug.Log("Object Clicked: " + hit.transform.name);
            }
        }
    }
}
