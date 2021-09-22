using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    HealthComponent unitHealth;
    [SerializeField]
    Skill[] unitSkills;
    public float turnRate = 1.0f / GameManager.distanceUnit; 
        
    // Start is called before the first frame update
    void Start()
    {
        unitHealth = this.GetComponent<HealthComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
