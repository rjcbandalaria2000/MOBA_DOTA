using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayUnitStats : MonoBehaviour
{
    public UnitStats objectUnitStat;

    [Header("Attack UI")]
    public Text attackSpeed;
    public Text baseDamage;
    public Text attackRange;
    public Text MoveSpeed;
    public Text ManaRegen;

    [Header("Defence UI")]
    public Text Armor;
    public Text magicResist;
    public Text HealthRegen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Awake()
    {
        SingletonManager.Register(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(objectUnitStat != null)
        {
            attackSpeed.text = objectUnitStat.GetAttackSpeed().ToString();
            baseDamage.text = objectUnitStat.GetBaseDamage().ToString();
            attackRange.text = objectUnitStat.GetAttackRange().ToString();
            MoveSpeed.text = objectUnitStat.GetMovementSpeed().ToString();

            Armor.text = objectUnitStat.GetTotalArmor().ToString();

            HealthRegen.text = objectUnitStat.GetBaseHealthRegen().ToString();
        }
       
    }
}
