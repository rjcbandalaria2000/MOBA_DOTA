using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class Buff : MonoBehaviour
{
    [SerializeField]
    public GameObject targetUnit;
    [SerializeField]
    protected GameObject sourceUnit { get; set; }
    [SerializeField]
    protected string buffName;
    //[SerializeField]
    //protected UnitStats buffStats;

    virtual public void ActivateBuff(GameObject target, GameObject source = null)
    {
        OnActiveBuff(target);
    }
    virtual public void DeactivateBuff(GameObject target, GameObject source = null)
    {
        OnDeactiveBuff(target);
    }
    virtual public void OnActiveBuff(GameObject target, GameObject source = null)
    {
        
    }
    virtual public void OnDeactiveBuff(GameObject target, GameObject source = null)
    {

    }
}
