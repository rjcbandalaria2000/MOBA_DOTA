using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Skill : MonoBehaviour
{
    [SerializeField]
    int manaCost;
    [SerializeField]
    int castRange;
    
    public UnityEvent onApply;
   
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
        OnActivate(target, attacker);
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
}
