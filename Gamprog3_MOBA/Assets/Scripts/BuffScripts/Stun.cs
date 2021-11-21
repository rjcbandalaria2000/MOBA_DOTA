using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : Buff
{
    [SerializeField]
    Animator targetAnimator;
    [SerializeField]
    List<float> stunDuration;
    [SerializeField]
    int buffLevel = 0;
    [SerializeField]
    float stunTimer = 0; 
    // Start is called before the first frame update
    void Start()
    {
        targetAnimator = targetUnit.GetComponent<Animator>();
    }

    public override void ActivateBuff(GameObject target, GameObject source = null)
    {
        base.ActivateBuff(target, source);
    }

    public override void DeactivateBuff(GameObject target, GameObject source = null)
    {
        base.DeactivateBuff(target, source);
    }

    public override void OnActiveBuff(GameObject target, GameObject source = null)
    {
        //base.OnActiveBuff(target, source);
        if (target.GetComponent<Stun>())
        {
            stunTimer = 0;
        }
        targetAnimator = target.GetComponent<Animator>();
        InterruptActions();
        targetAnimator.SetBool("IsStun", true);
        
    }
    public override void OnDeactiveBuff(GameObject target, GameObject source = null)
    {
        base.OnDeactiveBuff(target, source);
        targetAnimator.SetBool("IsStun", false);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (stunTimer < stunDuration[buffLevel])
        {
            stunTimer += Time.deltaTime;
        }
        else
        {
            DeactivateBuff(targetUnit);
        }
    }

    void InterruptActions()
    {
        targetAnimator.SetBool("IsMoving", false);
        targetAnimator.SetBool("IsAttacking", false);
        targetUnit.GetComponent<Unit>().target = null;
        targetAnimator.SetBool("hasTarget", false);
    }
}
