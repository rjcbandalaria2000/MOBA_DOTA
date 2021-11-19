using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class LevelComponent : MonoBehaviour
{
    public Unit unit;
    public UnitStats stats;
    public HealthComponent HP_Source;
    public UIManager UI;

    public int Level = 1;
    public float currentEXP;
    public float maxEXP;
    public int skillPoints;

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
        if(currentEXP >= maxEXP) // if level up
        {
            Level += 1;
            currentEXP = 0;
            maxEXP += 10; // Hard Values
            updateStats(); 
        }
    }

    public void updateStats()
    {
        stats.SetStrength(stats.GetStrength() + 5);
        stats.SetBaseArmor(stats.GetBaseArmor() + 5);
        stats.SetAttackSpeed(stats.GetAttackSpeed() + 5);
    }

    public void displayUI_Upgrade()
    {
        if (UI.skillsCanvas && skillPoints > 0)
        {
            for(int i = 0; i < UI.upgradeButtons.Count; i++)
            {
                UI.upgradeButtons[i].gameObject.SetActive(true);
            }
        }
    }

    public void skillUpgrade(int index)
    {
        unit.GetSkill(index).skillLevel += 1;

        if (UI.skillsCanvas && skillPoints < 0)
        {
            for (int i = 0; i < UI.upgradeButtons.Count; i++)
            {
                UI.upgradeButtons[i].gameObject.SetActive(false);
            }
        }

    }
}
