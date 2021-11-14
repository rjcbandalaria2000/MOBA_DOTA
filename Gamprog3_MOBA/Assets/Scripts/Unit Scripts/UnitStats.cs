using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Basic,
    Pierce,
    Siege,
    Hero
}
public enum ArmorType
{
    Basic, 
    Fortified,
    Hero
}

public enum PrimaryAttribute
{
    None,
    Strength,
    Agility,
    Intelligence,
}
public class UnitStats : MonoBehaviour
{
    [SerializeField]
    float baseHP;
    [SerializeField]
    float baseHealthRegen;
    [SerializeField]
    float initialDamage;
    [SerializeField]
    float baseDamage;
    [SerializeField]
    float totalDamage;
    [SerializeField]
    int strength;
    [SerializeField]
    int intelligence;
    [SerializeField]
    float baseMana;
    [SerializeField]
    int agility;
    [SerializeField]
    int movementSpeed;
    [SerializeField]
    int baseAttackSpeed;
    public int attackSpeedModifier;
    [SerializeField]
    int totalAttackSpeed;
    [SerializeField]
    float attackRange;
    [SerializeField]
    float projectileSpeed;
    [SerializeField]
    float baseAttackTime;
    [SerializeField]
    float totalAttackTime;
    [SerializeField]
    float baseArmor;
    [SerializeField]
    float totalArmor;
    [SerializeField]
    ArmorType unitArmorType;
    [SerializeField]
    PrimaryAttribute unitPrimaryAttribute;
    #region StatGetters
    public float GetBaseDamage()
    {
        return baseDamage;
    }
    public float GetTotalDamage()
    {
        return totalDamage;
    }
    public int GetStrength()
    {
        return strength;
    }
    public int GetIntelligence()
    {
        return intelligence;
    }
    public int GetAgility()
    {
        return agility;
    }
    public int GetMovementSpeed()
    {
        return movementSpeed;
    }
    public int GetAttackSpeed()
    {
        return baseAttackSpeed;
    }
    public float GetAttackRange()
    {
        return attackRange;
    }
    public float GetProjectileSpeed()
    {
        return projectileSpeed;
    }
    public float GetBaseAttackTime()
    {
        return baseAttackTime;
    }
    public float GetTotalAttackTime()
    {
        return totalAttackTime;
    }
    public float GetBaseArmor()
    {
        return baseArmor;
    }
    public float GetTotalArmor()
    {
        return totalArmor;
    }
    public ArmorType GetArmorType()
    {
        return unitArmorType;
    }
    public float GetBaseHP()
    {
        return baseHP;
    }
    public float GetBaseHealthRegen()
    {
        return baseHealthRegen;
    }
    public float GetBaseMana()
    {
        return baseMana;
    }
    #endregion
    #region StatSetters
    public void SetBaseDamage(float damageValue)
    {
        baseDamage = damageValue;
    }
    public void SetTotalDamage(float totalDamageValue)
    {
        totalDamage = totalDamageValue;
    }
    public void SetStrength(int strengthValue)
    {
        strength = strengthValue;
    }
    public void SetIntelligence(int intelligenceValue)
    {
        intelligence = intelligenceValue;
    }
    public void SetAgility(int agilityValue)
    {
        agility = agilityValue;
    }
    public void SetMovementSpeed(int movementSpeedValue)
    {
        movementSpeed = movementSpeedValue;
    }
    public void SetAttackSpeed(int attackSpeedValue)
    {
        baseAttackSpeed = attackSpeedValue;
    }
    public void SetBaseArmor(float baseArmorValue)
    {
        baseArmor = baseArmorValue;
    }
    public void SetTotalArmor(float totalArmorValue)
    {
        totalArmor = totalArmorValue;
    }
    public void SetBaseHP(float baseHPValue)
    {
        baseHP = baseHPValue;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        InitializeUnitStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeUnitStats()
    {
        attackRange /= GameManager.distanceUnit;
        totalArmor = CalculateTotalArmor();
        totalAttackSpeed = CalculateAttackSpeedWithAgility();
        CalculateBaseDamage();
        CalculateAttackTime();

    }

    public void AddBonusArmor(float bonusArmorValue)
    {
        totalArmor += bonusArmorValue;
    }

    public void RemoveBonusArmor(float bonusArmorValue)
    {
        totalArmor -= bonusArmorValue;
    }

    public void CalculateBaseDamage()
    {
        if(unitPrimaryAttribute == PrimaryAttribute.Strength)
        {
            baseDamage = initialDamage + strength;
        }
        else if (unitPrimaryAttribute == PrimaryAttribute.Agility)
        {
            baseDamage = initialDamage + agility;
        }
        else if (unitPrimaryAttribute == PrimaryAttribute.Intelligence)
        {
            baseDamage = initialDamage + intelligence;
        }
        else
        {
            baseDamage = initialDamage;
        }
    }

    public float CalculateTotalArmor()
    {
        return baseArmor + (agility * 0.16f);
    }

    public int CalculateAttackSpeedWithAgility()
    {
        return baseAttackSpeed + agility;
    } 

    public void CalculateAttackTime()
    {
        float attackPerSecond = (baseAttackSpeed + totalAttackSpeed + attackSpeedModifier) / (100 * baseAttackTime);
        totalAttackTime = 1 / attackPerSecond;
    }
}
