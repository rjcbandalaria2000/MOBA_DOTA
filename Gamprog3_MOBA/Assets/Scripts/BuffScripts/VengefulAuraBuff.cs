using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class VengefulAuraBuff : Buff
{
    [SerializeField]
    GameObject source;
    public GameObject Source { get { return source; }}
    [SerializeField]
    List<float> attackRangeIncrease;
    [SerializeField]
    List<float> damageIncrease;
    public int buffLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        buffName = "Vengeful Aura";
    }

    // Update is called once per frame
    void Update()
    {
        
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
        UnitStats targetStats = target.GetComponent<UnitStats>();
        Assert.IsNotNull(targetStats);
        targetStats.IncreaseAttackRange(attackRangeIncrease[buffLevel]);
        targetStats.IncreaseTotalDamage(damageIncrease[buffLevel]);

    }
    public override void OnDeactiveBuff(GameObject target, GameObject source = null)
    {
        //base.OnDeactiveBuff(target, source);
        UnitStats targetStats = target.GetComponent<UnitStats>();
        Assert.IsNotNull(targetStats);
        targetStats.DecreaseAttackRange(attackRangeIncrease[buffLevel]);
        targetStats.DecreaseTotalDamage(damageIncrease[buffLevel]);
    }

}
