using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    GameObject source;
    
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
        float damageMultiplier = CalculateDamageMultiplier();
        float attackMultiplier = DetermineAttackMultiplier(damageAttackType); 
        Debug.Log("Damage Multiplier: " + attackMultiplier);
        HealthComponent sourceHealth = source.GetComponent<HealthComponent>();
        if (sourceHealth)
        {
            sourceHealth.TakeDamage(damage * damageMultiplier * attackMultiplier);
        }
    }

    public float DetermineAttackMultiplier(AttackType attackType)
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
        return 1f; 
    }

}
