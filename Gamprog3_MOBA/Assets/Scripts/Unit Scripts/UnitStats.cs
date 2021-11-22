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
    float strength;
    [SerializeField]
    float intelligence;
    [SerializeField]
    float baseMana;
    [SerializeField]
    float agility;
    [SerializeField]
    int movementSpeed;
    [SerializeField]
    int baseAttackSpeed;
    public int attackSpeedModifier;
    [SerializeField]
    float totalAttackSpeed;
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
    float baseMagicResistance;
    public float BaseMagicResistance { get { return baseMagicResistance; } }
    [SerializeField]
    ArmorType unitArmorType;
    [SerializeField]
    PrimaryAttribute unitPrimaryAttribute;
    [Header("Status Effect")]
    public bool isStuned = false;

    #region StatGetters
    public float GetBaseDamage()
    { 
        return CalculateBaseDamageForPrimaryAttribute() ;
    }
    public float GetTotalDamage()
    {
        return totalDamage;
    }
    public float GetStrength()
    {
        return strength;
    }
    public float GetIntelligence()
    {
        return intelligence;
    }
    public float GetAgility()
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
        return CalculateTotalArmor();
    }
    public ArmorType GetArmorType()
    {
        return unitArmorType;
    }
    public float GetBaseHP()
    {
        return baseHP;
    }
    //Replace improve 
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
    public void SetStrength(float strengthValue)
    {
        strength = strengthValue;
    }
    public void SetIntelligence(float intelligenceValue)
    {
        intelligence = intelligenceValue;
    }
    public void SetAgility(float agilityValue)
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
        baseDamage = CalculateBaseDamageForPrimaryAttribute();
        totalDamage = baseDamage;
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

    public float CalculateBaseDamageForPrimaryAttribute()
    {
        if (unitPrimaryAttribute == PrimaryAttribute.Strength)
        {
            return baseDamage = initialDamage + strength;
        }
        else if (unitPrimaryAttribute == PrimaryAttribute.Agility)
        {
            return baseDamage = initialDamage + agility;
        }
        else if (unitPrimaryAttribute == PrimaryAttribute.Intelligence)
        {
            return baseDamage = initialDamage + intelligence;
        }
        else
        {
            return baseDamage = initialDamage;
        }
    }

    public float CalculateTotalArmor()
    {
        return baseArmor + (agility * 0.16f);
    }

    public float CalculateAttackSpeedWithAgility()
    {
        return baseAttackSpeed + agility;
    }

    public void CalculateAttackTime()
    {
        float attackPerSecond = (baseAttackSpeed + totalAttackSpeed + attackSpeedModifier) / (100 * baseAttackTime);
        totalAttackTime = 1 / attackPerSecond;
    }

    public float GetAttackTime()
    {
        float attackPerSecond = (baseAttackSpeed + totalAttackSpeed + attackSpeedModifier) / (100 * baseAttackTime);
        return 1 / attackPerSecond; ;
    }

    public void IncreaseAttackRange(float attackRangeValue)
    {
        attackRange += (attackRangeValue / GameManager.distanceUnit);
    }
    public void DecreaseAttackRange(float attackRangeValue)
    {
        if (attackRange > 0)
        {
            attackRange -= (attackRangeValue / GameManager.distanceUnit);
        }
    }
    public void IncreaseTotalDamage(float damageValue)
    {
        totalDamage += damageValue;
    }
    public void DecreaseTotalDamage(float damageValue)
    {
        totalDamage -= damageValue;
    } 
}
