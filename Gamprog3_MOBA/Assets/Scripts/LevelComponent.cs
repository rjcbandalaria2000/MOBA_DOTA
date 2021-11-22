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
    public UnitStats growthStats; 

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
        stats.SetStrength(stats.GetStrength() + growthStats.GetStrength());
        stats.SetAgility(stats.GetAgility() + growthStats.GetAgility());
        stats.SetIntelligence(stats.GetIntelligence() + growthStats.GetIntelligence());
    }

    public void GainExp(float experienceGain)
    {
        if (Level < 25)
        {
            currentEXP += experienceGain;
            if (currentEXP >= maxEXP)
            {
                LevelUpUnit();
            }
        }
    }

    public int GiveExp()
    {
        return deathExp[Level - 1];
    }

    void LevelUpUnit()
    {
        Level += 1;
        if (Level - 1 < requiredExp.Count)
        {
            maxEXP = requiredExp[Level - 1];
        }
        if (growthStats)
        {
            updateStats();
        }
       
    }
}
