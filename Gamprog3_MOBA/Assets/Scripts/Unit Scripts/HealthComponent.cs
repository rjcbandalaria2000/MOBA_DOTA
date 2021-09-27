using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private float currentHP;
    [SerializeField]
    private float maxHP; 

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeHealth()
    {

    }

    public void SetCurrentHealth(float health)
    {

    }

    public float GetCurrentHealth()
    {
        return currentHP;
    }

    public float GetMaxHP()
    {
        return maxHP;
    }

    public void SetMaxHP(float maxHealth)
    {
        maxHP = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (currentHP > 0)
        {
            currentHP -= damage;
        }
        else
        {
            Death();
        }
    }

    public void Death()
    {
        OnDeath();
    }

    public void OnDeath()
    {
        Debug.Log("Unit Dead");
    }
}
