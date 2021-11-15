using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Skill : MonoBehaviour
{
    public float skillCooldown;
    public bool isCoolDown;
    protected Coroutine coolDownRoutine;


    [SerializeField]
    int manaCost;
    [SerializeField]
    int castRange;
    [SerializeField]
    protected AttackType attackType;
   
    // Start is called before the first frame update
    void Start()
    {
       
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
            coolDownRoutine = StartCoroutine(coolDown(skillCooldown));
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

    public IEnumerator coolDown(float coolDownValue)
    {
        isCoolDown = true;
        yield return new WaitForSeconds(coolDownValue);
        isCoolDown = false;
        coolDownValue = skillCooldown;
    }
}
