using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField]
    GameObject source;
    [SerializeField]
    float damageMultiplier;
    [SerializeField]
    float basicAttackMultiplier;
    [SerializeField]
    float pierceAttackMultiplier;
    [SerializeField]
    float siegeAttackMultiplier;
    [SerializeField]
    float heroAttackMultiplier; 
    
    // Start is called before the first frame update
    void Start()
    {
        source = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float CalculateDamageMultiplier()
    {
        float unitTotalArmor = source.GetComponent<UnitStats>().GetTotalArmor();
        float multiplier = 1 - ((0.052f * unitTotalArmor) /
            (0.9f + 0.048f * Mathf.Abs(unitTotalArmor)));
        return multiplier;
    }

    public void ReceiveDamage(float damage, AttackType damageAttackType)
    {
        damageMultiplier = CalculateDamageMultiplier();
        float attackMultiplier; 
        Debug.Log("Damage Multiplier: " + damageMultiplier);
        HealthComponent sourceHealth = source.GetComponent<HealthComponent>();
        if (sourceHealth)
        {
            sourceHealth.TakeDamage(damage * damageMultiplier);
        }
    }

    public float DetermineAttackMultiplier(AttackType attackType)
    {
        UnitStats sourceStats = source.GetComponent<UnitStats>();
        if (sourceStats)
        {
            if(sourceStats.GetArmorType() == ArmorType.Basic && attackType == AttackType.Basic)
            {
                
            }
        }
        return 0; 
    }

}
