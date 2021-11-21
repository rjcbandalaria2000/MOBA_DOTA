using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class LevelComponent : MonoBehaviour
{
    public Unit unit;
    public UnitStats stats;
    

    public int Level = 1;
    public int maxLevel = 25;
    public float currentEXP;
    public float maxEXP;
    public List<int> requiredExp;
    public List<int> deathExp;

   // public float pointsToGain; //EXP points gain when killed something

    // Start is called before the first frame update
    void Start()
    {
        unit = this.gameObject.GetComponent<Unit>();
        Assert.IsNotNull(unit);
        
        stats = this.gameObject.GetComponent<UnitStats>();
        Assert.IsNotNull(stats);

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateStats()
    {
        stats.SetStrength(stats.GetStrength() + 5);
        stats.SetBaseArmor(stats.GetBaseArmor() + 5);
        stats.SetAttackSpeed(stats.GetAttackSpeed() + 5);
    }

    public void GainExp(float experienceGain)
    {
        if (Level < 25)
        {
            currentEXP += experienceGain;
            if (currentEXP >= maxEXP)
            {
                Level += 1;
                if(Level - 1 < requiredExp.Count)
                {
                    maxEXP = requiredExp[Level - 1];
                }
                
                updateStats();
            }
        }
    }

    public int GiveExp()
    {
        return deathExp[Level - 1];
    }
}
