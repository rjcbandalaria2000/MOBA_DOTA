using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DamageReceiver : MonoBehaviour
{
   
    GameObject source;
    public GameObject lastAttacker;
    
    // Start is called before the first frame update
    void Start()
    {
        source = this.gameObject;
        HealthComponent sourceHP = source.GetComponent<HealthComponent>();
        if (sourceHP)
        {
            sourceHP.death.AddListener(OnLastHit);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float CalculateDamageMultiplier()
    {
        float unitTotalArmor = source.GetComponent<UnitStats>().CalculateTotalArmor();
        float multiplier = 1 - ((0.052f * unitTotalArmor) /
            (0.9f + 0.048f * Mathf.Abs(unitTotalArmor)));
        return multiplier;
    }

    public void ReceiveDamage(float damage, AttackType attackType, DamageType damageType)
    {
        float damageMultiplier = CalculateDamageMultiplier();
        float attackMultiplier = DetermineAttackTypeMultiplier(attackType);
        float magicalResistanceMultiplier = CalculateMagicalResistance();
        Debug.Log("Damage Multiplier: " + attackMultiplier);
        HealthComponent sourceHealth = source.GetComponent<HealthComponent>();
        if (sourceHealth)
        {
            if(damageType == DamageType.Physical)
            {
                sourceHealth.TakeDamage(damage * damageMultiplier * attackMultiplier);
            }
            else if(damageType == DamageType.Magical)
            {
                sourceHealth.TakeDamage(damage * damageMultiplier * attackMultiplier * magicalResistanceMultiplier);
            }
            
        }
    }

    public float DetermineAttackTypeMultiplier(AttackType attackType)
    { 
       UnitStats sourceStats = source.GetComponent<UnitStats>();
       if (sourceStats)
       {
            if (sourceStats.GetArmorType() == ArmorType.Basic && attackType == AttackType.Basic)
            {
                return 1.0f;
            }  
            else if (sourceStats.GetArmorType() == ArmorType.Basic && attackType == AttackType.Pierce)
            {
                return 1.5f;
            }
            else if (sourceStats.GetArmorType() == ArmorType.Basic && attackType == AttackType.Siege)
            {
                return 1.0f;
            }
            else if (sourceStats.GetArmorType() == ArmorType.Basic && attackType == AttackType.Hero)
            {
                return 1.0f;
            }
            else if (sourceStats.GetArmorType() == ArmorType.Fortified && attackType == AttackType.Basic)
            {
                return 0.7f;
            }
            else if (sourceStats.GetArmorType() == ArmorType.Fortified && attackType == AttackType.Pierce)
            {
                return 0.35f;
            }
            else if (sourceStats.GetArmorType() == ArmorType.Fortified && attackType == AttackType.Siege)
            {
                return 2.50f;
            }
            else if (sourceStats.GetArmorType() == ArmorType.Fortified && attackType == AttackType.Hero)
            {
                return 0.5f;
            }
            else if (sourceStats.GetArmorType() == ArmorType.Hero && attackType == AttackType.Basic)
            {
                return 0.75f;
            }
            else if (sourceStats.GetArmorType() == ArmorType.Hero && attackType == AttackType.Pierce)
            {
                return 0.5f;
            }
            else if (sourceStats.GetArmorType() == ArmorType.Hero && attackType == AttackType.Siege)
            {
                return 1.0f;
            }
            else if (sourceStats.GetArmorType() == ArmorType.Hero && attackType == AttackType.Hero)
            {
                return 1.0f;
            }
            else
            {
                return 0f;
            }
       }
       else
       {
            return 0f;
       }

    }
    public float CalculateMagicalResistance()
    {
        UnitStats unitStats = source.GetComponent<UnitStats>();
        Assert.IsNotNull(unitStats, "Unit Stats required to get Magical Resistance");
        return 1 - unitStats.BaseMagicResistance; 
    }

    public void setAttacker(GameObject attacker)
    {
        lastAttacker = attacker;
    }


    public void OnLastHit(HealthComponent lastAttackerHP)
    {
        Unit lastAttackerUnit = lastAttacker.GetComponent<Unit>();
        if (lastAttackerUnit)
        {
            if(lastAttackerUnit.unitType == UnitType.Hero)
            {
                BountyComponent lastAttackerBounty = lastAttackerUnit.gameObject.GetComponent<BountyComponent>();
                lastAttackerBounty.Gold += 10;
            }
        }
    }
   

}
