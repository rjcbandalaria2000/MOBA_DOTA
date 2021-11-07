using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    [SerializeField]
    protected string buffName;
    [SerializeField]
    protected UnitStats buffStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void ActivateBuff(GameObject target)
    {
        OnActiveBuff(target);
    }
    virtual public void DeactivateBuff(GameObject target)
    {
        OnDeactiveBuff(target);
    }
    virtual public void OnActiveBuff(GameObject target)
    {

    }
    virtual public void OnDeactiveBuff(GameObject target)
    {

    }
}
