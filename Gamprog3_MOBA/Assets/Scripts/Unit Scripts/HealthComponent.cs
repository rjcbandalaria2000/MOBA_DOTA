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
    [SerializeField]
    bool isRegenerating;
    public float healthRegen;
    public bool isInvincible = false;
    Coroutine activateHealthRegen;
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
        activateHealthRegen = StartCoroutine(healthRegeneration());
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

         //display text if available/assign
        
         StartCoroutine(SingletonManager.Get<DisplayDamage>().displayDamage(damage));
        
        
        
        
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
            yield return new WaitForSeconds(0.0f);
            UnitStats unitStats = this.gameObject.GetComponent<UnitStats>();
            if (unitStats)
            {
                healthRegen = unitStats.GetStrength() * 0.1f;
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
