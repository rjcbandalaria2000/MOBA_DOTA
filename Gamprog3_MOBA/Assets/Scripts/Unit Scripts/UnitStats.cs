using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    [SerializeField]
    float baseDamage;
    [SerializeField]
    int strength;
    [SerializeField]
    int intelligence;
    [SerializeField]
    int agility;
    [SerializeField]
    int movementSpeed;
    [SerializeField]
    int attackSpeed;
    [SerializeField]
    float attackRange;
    [SerializeField]
    float projectileSpeed;
    [SerializeField]
    float baseAttackTime;
    [SerializeField]
    float baseArmor;
    [SerializeField]
    float totalArmor;

    #region StatGetters
    public float GetBaseDamage()
    {
        return baseDamage;
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
        return attackSpeed;
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
    public float GetBaseArmor()
    {
        return baseArmor;
    }
    public float GetTotalArmor()
    {
        return totalArmor;
    }
    #endregion
    #region StatSetters
    public void SetBaseDamage(float damageValue)
    {
        baseDamage = damageValue;
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
        attackSpeed = attackSpeedValue;
    }
    public void SetBaseArmor(float baseArmorValue)
    {
        baseArmor = baseArmorValue;
    }
    public void SetTotalArmor(float totalArmorValue)
    {
        totalArmor = totalArmorValue;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        attackRange /= GameManager.distanceUnit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
