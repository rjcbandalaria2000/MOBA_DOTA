using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string name;

    
    public HealthComponent unitHealth;
    [SerializeField]
    public GameObject targetInRange;
    [SerializeField]
    public GameObject target;
    [SerializeField]
    Skill[] unitSkills;
    [SerializeField]
    public float attackRange;
     
    public float turnRate = 1.0f / GameManager.distanceUnit; 


        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
