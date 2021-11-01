using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerComponent : MonoBehaviour
{
    [SerializeField] public List<GameObject> targets;
    public Collider rangeCollider;
    [SerializeField] private bool isInvincible;
    public GameObject referenceTower;

    // Start is called before the first frame update
    void Start()
    {
        if (referenceTower != null)
        {
            isInvincible = true;
        }
        else
        {
            isInvincible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    //private void OnTriggerEnter(Collider other)
    //{
    //    //if(other.gameObject.GetComponent<Unit>() != null)
    //    //{
    //    //    targets.Add(other.gameObject);
    //    //}
    //    targets.Add(other.gameObject);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    //if (other.gameObject.GetComponent<Unit>() != null)
    //    //{
    //    //    targets.Remove(other.gameObject);
    //    //}
    //    targets.Remove(other.gameObject);
    //}
}
