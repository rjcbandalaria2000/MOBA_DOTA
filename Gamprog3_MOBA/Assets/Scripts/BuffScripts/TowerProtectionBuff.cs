using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProtectionBuff : Buff
{
    [SerializeField]
    int bonusArmor;
    // Start is called before the first frame update
    void Start()
    {
        buffName = "Tower Protection";
        //targetUnit = this.gameObject;
        //ActivateBuff(targetUnit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ActivateBuff(GameObject target)
    {
        base.ActivateBuff(target);
    }
    public override void OnActiveBuff(GameObject target)
    {
        //base.OnActiveBuff(target);
        UnitStats targetStats = target.GetComponent<UnitStats>();
        if (targetStats)
        {
            Debug.Log("Give armor");
            targetStats.AddBonusArmor(bonusArmor);
        }

    }
    public override void DeactivateBuff(GameObject target)
    {
        base.DeactivateBuff(target);
    }
    public override void OnDeactiveBuff(GameObject target)
    {
        //base.OnDeactiveBuff(target);
        UnitStats targetStats = target.GetComponent<UnitStats>();
        if (targetStats)
        {
            targetStats.RemoveBonusArmor(bonusArmor);
        }
    }
}
