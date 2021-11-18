using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class WaveOfTerrorBuff : Buff
{
    [SerializeField]
    GameObject source;
    public GameObject Source { get { return source; } }
    [SerializeField]
    GameObject targetInflicted;
    public GameObject TargetInflicted { get { return targetInflicted; } }
    [SerializeField]
    List<float> armorReductionValues;
    public int buffLevel = 0;
    public int buffDuration;
    [SerializeField]
    int buffTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        buffName = "Wave Of Terror";
        targetInflicted = this.gameObject.transform.parent.gameObject;

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
        targetStats.RemoveBonusArmor(armorReductionValues[buffLevel]);

    }
    public override void OnDeactiveBuff(GameObject target, GameObject source = null)
    {
        base.OnDeactiveBuff(target, source);
        UnitStats targetStats = target.GetComponent<UnitStats>();
        Assert.IsNotNull(targetStats);
        targetStats.AddBonusArmor(armorReductionValues[buffLevel]);
    }

    private void Update()
    {
        if(buffTimer < buffDuration)
        {
            buffTimer++;
        }
        if(buffTimer >= buffDuration)
        {
            DeactivateBuff(targetInflicted);
        }
    }

}
