using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum DamageType
{
    Physical,
    Magical
}

public class Skill : MonoBehaviour
{
    public List<float> skillCooldown;
    //public float currentSkillCooldown;
    //public float maxSkillCoolDown;
    public bool isCoolDown;
    protected Coroutine coolDownRoutine;
    public int skillIndex;
    public int skillLevel;
    [SerializeField]
    bool isMaxSkillLevel;

    //Prototype Level Requirements 
    [SerializeField]
    public List<int> heroLevelRequirement;


    //public int currentSkillLevel;
    public int maxSkillLevel;
    public UIManager skillsUI;

    [SerializeField]
    public List<int> manaCost;
    [SerializeField]
    public float castRange;
    [SerializeField]
    protected AttackType attackType;
    [SerializeField]
    protected DamageType damageType;

    public int GetHeroLevelRequirement()
    {
        if (skillLevel > 1)
        {
            return heroLevelRequirement[skillLevel - 1];
        }
        else{
            return heroLevelRequirement[skillLevel];
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        //currentSkillCooldown = maxSkillCoolDown;
        skillsUI.skill_icon_Transparent[skillIndex].fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        //Debug.Log(isCoolDown);
        if (isCoolDown)
        {
            if(skillsUI != null)
            {
                skillsUI.skill_icon_Transparent[skillIndex].fillAmount -= 1 / skillCooldown[skillLevel - 1] * Time.deltaTime;
                if (skillsUI.skill_icon_Transparent[skillIndex].fillAmount <= 0)
                {
                    Debug.Log("Finish CD");
                    skillsUI.skill_icon_Transparent[skillIndex].fillAmount = 0;
                }
            }
            
        }
    }

    virtual public void ActivateSkill(GameObject target, GameObject attacker = null)
    {
        if(!isCoolDown)
        {
            OnActivate(target, attacker);

           if(skillsUI != null)
            {
                skillsUI.skill_icon_Transparent[skillIndex].fillAmount = 1;
            }
        
          
            
            //SkillCoolDown1(skillCooldown, skillIndex);
        }
        else
        {
            Debug.Log("OnCooldown");
        }
    }

    virtual public void DeactivateSkill(GameObject target, GameObject attacker = null)
    {
        OnDeactivateSkill(target, attacker);
    }

    virtual public void OnActivate(GameObject target, GameObject attacker = null)
    {

    }

    virtual public void OnDeactivateSkill(GameObject target, GameObject attacker = null)
    {

    }

    public int getManaCost()
    {
        return manaCost[skillLevel -1];
    }

    //public IEnumerator coolDown(float coolDownValue)
    //{
    //    isCoolDown = true;
    //    skillsUI.skill1_icon_Transparent.fillAmount = coolDownValue /100.0f;
    //    yield return new WaitForSeconds(coolDownValue);
    //    isCoolDown = false;
    //    currentSkillCooldown = maxSkillCoolDown;
    //}

    public IEnumerator SkillCoolDown(float coolDownValue, int index)
    {

        isCoolDown = true;
        yield return new WaitForSeconds(coolDownValue);
        isCoolDown = false;
        

    }

    public void SkillCoolDown1(float coolDownValue, int index)
    {
        
            if(!isCoolDown)
            {
                isCoolDown = true;
                skillsUI.skill_icon_Transparent[index].fillAmount = 1;
            }
           
           if(isCoolDown)
           {
                skillsUI.skill_icon_Transparent[index].fillAmount -= 1 / coolDownValue * Time.deltaTime;

                if (skillsUI.skill_icon_Transparent[index].fillAmount <= 0)
                {
                    skillsUI.skill_icon_Transparent[index].fillAmount = 0;
                    isCoolDown = false;
                   
                }
           }

    }

}
