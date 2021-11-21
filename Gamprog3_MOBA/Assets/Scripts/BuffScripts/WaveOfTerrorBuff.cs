using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class WaveOfTerrorBuff : Buff
{
    [SerializeField]
    List<float> armorReductionValues;
    public int buffLevel = 0;
    public float buffDuration;
    [SerializeField]
    float buffTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        buffName = "Wave Of Terror";

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
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if(buffTimer < buffDuration)
        {
            buffTimer+=Time.deltaTime;
        }
        if(buffTimer >= buffDuration)
        {
            DeactivateBuff(targetUnit);
        }
    }

}
