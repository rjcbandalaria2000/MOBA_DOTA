using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerComponent : MonoBehaviour
{
    [SerializeField] public List<GameObject> targets;
    public Collider rangeCollider;
    [SerializeField] private bool isInvincible;
    public GameObject referenceTower;

    public UnityEvent<TowerComponent> destroyed;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
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

   

    
}
