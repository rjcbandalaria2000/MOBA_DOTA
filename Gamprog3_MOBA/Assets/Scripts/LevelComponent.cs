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
    public int skillPoints;
    public List<int> requiredExp;
    public List<int> deathExp;
    public UnitStats growthStats;
    public float attributeUpgradeValue = 2;

    public List<int> levelRequired;
    [SerializeField]
    int levelRequiredIndex = 0;

    //For Sharing 
    public int numOfHeroesInRadius;

   // public float pointsToGain; //EXP points gain when killed something

    // Start is called before the first frame update
    void Start()
    {
        unit = this.gameObject.GetComponent<Unit>();
        Assert.IsNotNull(unit);
        
        stats = this.gameObject.GetComponent<UnitStats>();
        Assert.IsNotNull(stats);

        skillPoints = 1;
        skillUpgradeActivate();

        if (requiredExp.Count > 0)
        {
            maxEXP = requiredExp[Level - 1];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpgradeStats()
    {
        skillPoints -= 1;
        stats.SetStrength(stats.GetStrength() + attributeUpgradeValue);
        stats.SetAgility(stats.GetAgility() + attributeUpgradeValue);
        stats.SetIntelligence(stats.GetIntelligence() + attributeUpgradeValue);
        if (skillPoints <= 0)
        {
            for (int i = 0; i < SingletonManager.Get<UIManager>().upgradeButtons.Count; i++)
            {
                SingletonManager.Get<UIManager>().upgradeButtons[i].gameObject.SetActive(false);
            }
            SingletonManager.Get<UIManager>().attributeUpgradeButtons.gameObject.SetActive(false);

            for (int i = 0; i < unit.unitSkills.Count; i++)
            {
                if (unit.unitSkills[i].skillLevel == 1 && this.Level == 2)
                {
                    SingletonManager.Get<UIManager>().upgradeButtons[i].gameObject.SetActive(false);
                }
                else
                {
                    return;
                }
            }

        }
        
       

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
        return deathExp[Level - 1] / numOfHeroesInRadius;
    }

    public void skillUpgradeActivate()
    {
        if(this.gameObject.GetComponent<Unit>().unitType == UnitType.Hero)
        {
            for(int i = 1; i < unit.unitSkills.Count; i++)
            {
                Debug.Log("Unit Skills: " + unit.GetSkill(i).name);
                
                //SingletonManager.Get<UIManager>().upgradeButtons[i].gameObject.SetActive(true);
                if(unit.GetSkill(i).skillLevel < unit.GetSkill(i).maxSkillLevel)//levelRequired[levelRequiredIndex]) //Skill cap for ultimate
                {
                    Debug.Log(unit.GetSkill(i).name + " Hero Level Requirement: " + unit.GetSkill(i).GetHeroLevelRequirement());
                    if(this.Level >= unit.GetSkill(i).GetHeroLevelRequirement())
                    {
                        Debug.Log(unit.GetSkill(i).name + " Level for Upgrading");
                        //SingletonManager.Get<UIManager>().upgradeButtons[3].gameObject.SetActive(true);
                        //levelRequiredIndex += 1;
                        SingletonManager.Get<UIManager>().upgradeButtons[i -1].gameObject.SetActive(true);
                    }
                    
                }
                else
                {
                   Debug.Log(unit.GetSkill(i).name + " upgrade level not met");
                   //SingletonManager.Get<UIManager>().upgradeButtons[3].gameObject.SetActive(false);
                   SingletonManager.Get<UIManager>().upgradeButtons[i -1].gameObject.SetActive(false);
                }
               
            }
            

            SingletonManager.Get<UIManager>().attributeUpgradeButtons.gameObject.SetActive(true);
        }
    }

    public void selectSkillUpgrade(int index)
    {
        if (unit.GetSkill(index).skillLevel < unit.GetSkill(index).maxSkillLevel)
        {
            Debug.Log("Skill Upgrade");
            unit.GetSkill(index).skillLevel += 1;
            skillPoints -= 1;
            //skill Upgrade
            if (skillPoints <= 0)
            {
                for (int i = 0; i < SingletonManager.Get<UIManager>().upgradeButtons.Count; i++)
                {
                    SingletonManager.Get<UIManager>().upgradeButtons[i].gameObject.SetActive(false);
                }
            }
            else
            {
                Debug.Log("Has skill points left");
                skillUpgradeActivate();
            }
            //if (unit.GetSkill(index) == unit.GetSkill(3)) {
            //    levelRequiredIndex += 1;
            //}
            
        }
        
    }
    public void LevelUpUnit()
    {
        Level += 1;
        skillPoints++;
        if (Level - 1 < requiredExp.Count)
        {
            maxEXP = requiredExp[Level - 1];
        }
        if (growthStats)
        {
            //updateStats();
            LevelUpAttributes();
        }
        if (skillPoints > 0)
        {
            skillUpgradeActivate();
        }

    }

    public void LevelUpAttributes()
    {
        stats.SetStrength(stats.GetStrength() + growthStats.GetStrength());
        stats.SetAgility(stats.GetAgility() + growthStats.GetAgility());
        stats.SetIntelligence(stats.GetIntelligence() + growthStats.GetIntelligence());
    }
}
