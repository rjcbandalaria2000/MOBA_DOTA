using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VengefulAuraSkill : Skill
{
    VengefulAura skillAura;
    // Start is called before the first frame update
    void Start()
    {
        skillAura = this.gameObject.GetComponentInChildren<VengefulAura>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
