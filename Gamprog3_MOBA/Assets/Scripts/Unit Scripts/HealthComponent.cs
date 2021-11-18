using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private float currentHP;
    [SerializeField]
    public float maxHP;
    [SerializeField]
    private bool isDead;
    [SerializeField]
    bool canRegen;
    public float healthRegen;
    public bool isInvincible = false;
    Coroutine activateHealthRegen;
    public UnityEvent<HealthComponent> death;
    public UnityEvent<float> damaged;
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
        InitializeHealth();

        //maxHP = CalculateMaxHealth();
        //currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //death.Invoke(this);
    }

    public void InitializeHealth()
    {
        
        Unit unit = this.gameObject.GetComponent<Unit>();
        Assert.IsNotNull(unit);
        UnitStats unitStats = this.gameObject.GetComponent<UnitStats>();
        Assert.IsNotNull(unitStats);
        

        maxHP = CalculateMaxHealth();
        currentHP = maxHP;
        if(unit.unitType == UnitType.Hero)
        {
            canRegen = true;
            activateHealthRegen = StartCoroutine(healthRegeneration());
        }
        
    }

    public float CalculateMaxHealth()
    {
        UnitStats unitStats = this.gameObject.GetComponent<UnitStats>();
        Assert.IsNotNull(unitStats);
        return unitStats.GetBaseHP() + (unitStats.GetStrength() * 20f);
    }
   
    public void TakeDamage(float damage)
    {

        if (isInvincible)
        {
            Debug.Log("Immune");
            return;
        }

        currentHP -= damage;
        damaged.Invoke(damage);
    
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
    IEnumerator healthRegeneration()
    {
        while (!isDead)
        {
            //yield return null - similar to update instead of WaitForSeconds which is for the next frame
            //yield return new WaitForSeconds(0.0f);
            yield return null;
            UnitStats unitStats = this.gameObject.GetComponent<UnitStats>();
            if (unitStats)
            {
                healthRegen = unitStats.GetBaseHealthRegen() + (unitStats.GetStrength() * 0.1f);
                if(healthRegen <= 0)
                {
                    healthRegen = 0;
                }
                if(currentHP < maxHP)
                {
                    currentHP += healthRegen;
                }
                
            }
        }
        
    }

   
    //IEnumerator displayDamage(float damage)
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    SingletonManager.Get<DisplayDamage>().dmgValue.gameObject.SetActive(true);
    //    SingletonManager.Get<DisplayDamage>().dmgValue.text = damage.ToString();
    //    yield return new WaitForSeconds(1f);
    //    SingletonManager.Get<DisplayDamage>().dmgValue.gameObject.SetActive(false);
    //}
}
