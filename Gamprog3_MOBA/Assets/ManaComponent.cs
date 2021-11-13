using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ManaComponent : MonoBehaviour
{
    [SerializeField]
    float currentMana;
    [SerializeField]
    float maxMana;
    [SerializeField]
    bool canManaRegen;
    [SerializeField]
    float manaRegen;

    Coroutine manaRegenerationRoutine;
    #region Getter Setter
    public float GetCurrentMana()
    {
        return currentMana;
    }
    public float GetMaxMana()
    {
        return maxMana;
    }
    public void SetCurrentMana(float currentManaValue)
    {
        currentMana = currentManaValue; 
    }
    public void SetMaxMana(float maxManaValue)
    {
        maxMana = maxManaValue;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        InitializeMana();
        if (canManaRegen)
        {
            manaRegenerationRoutine = StartCoroutine(ManaRegeneration());
        }
        

    }

    void InitializeMana()
    {
        UnitStats unitStats = this.GetComponent<UnitStats>();
        Assert.IsNotNull(unitStats);
        maxMana = unitStats.GetIntelligence() * 12f;
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ManaRegeneration()
    {
        while (true)
        { 
            yield return new WaitForSeconds(0.0f);
            HealthComponent unitHealth = this.gameObject.GetComponent<HealthComponent>();
            UnitStats unitStats = this.gameObject.GetComponent<UnitStats>();
            Assert.IsNotNull(unitStats);
            Assert.IsNotNull(unitHealth);
            manaRegen = unitStats.GetIntelligence() * 0.05f;
            if (!unitHealth.GetIsDead())
            {   
                if(currentMana < maxMana)
                {
                    currentMana += manaRegen;
                }
            }
            
        }
        
    }
}
