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
    public float skillCooldown;
    //public float currentSkillCooldown;
    //public float maxSkillCoolDown;
    public bool isCoolDown;
    protected Coroutine coolDownRoutine;
    public int skillIndex;

    public UIManager skillsUI;

    [SerializeField]
    int manaCost;
    [SerializeField]
    public float castRange;
    [SerializeField]
    protected AttackType attackType;
    [SerializeField]
    protected DamageType damageType;
    // Start is called before the first frame update
    void Start()
    {
        //currentSkillCooldown = maxSkillCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void ActivateSkill(GameObject target, GameObject attacker = null)
    {
        if(!isCoolDown)
        {
            OnActivate(target, attacker);

            coolDownRoutine = StartCoroutine(SkillCoolDown(skillCooldown,skillIndex));
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
        return manaCost;
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
        skillsUI.skill_icon_Transparent[index].fillAmount = 1;
        yield return new WaitForSeconds(coolDownValue);
        skillsUI.skill_icon_Transparent[index].fillAmount = 0;
        isCoolDown = false;
        coolDownValue = skillCooldown;
 
    }

    

    //public IEnumerator MagicMissleCooldown(float coolDownValue)
    //{

    //    while (coolDownTimer < coolDownValue)
    //    {
    //        isCoolDown = true;
    //        coolDownTimer++;
    //        skillsUI.skill1_icon_Transparent.fillAmount = coolDownTimer / coolDownValue;
    //    }
    //    coolDownTimer = 0;

    //    //skillsUI.skill1_icon_Transparent.fillAmount = 0;
    //    isCoolDown = false;
    //    coolDownValue = skillCooldown;
    //    yield return null;
    //}
}
