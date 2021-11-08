using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private float currentHP;
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private bool isDead;

    public bool isInvincible = false;

    public UnityEvent<HealthComponent> death;

    #region Getter Setter 

    public float GetCurrentHealth()
    {
        return currentHP;
    }

    public float GetMaxHP()
    {
        return maxHP;
    }


    public bool GetIsDead()
    {
        return isDead;
    }
    public void SetCurrentHealth(float health)
    {
        currentHP = health;
    }

  

    public void SetMaxHP(float maxHealth)
    {
        maxHP = maxHealth;
    }


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //death.Invoke(this);
    }

    public void InitializeHealth()
    {

    }

   
    public void TakeDamage(float damage)
    {
        //if (SingletonManager.Get<InvincibleComponent>().isInvincible)
        //{
        //    Debug.Log("Immune");
        //    return;
        //}

        if (isInvincible)
        {
            Debug.Log("Immune");
            return;
        }

        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            Death();
            
        }
       
    }

    public void Death()
    {
        OnDeath();
    }

    private void OnDeath()
    {
        Destroy(this.gameObject);
        Debug.Log("Unit Dead");
        isDead = true;
        death.Invoke(this);
    }
}
