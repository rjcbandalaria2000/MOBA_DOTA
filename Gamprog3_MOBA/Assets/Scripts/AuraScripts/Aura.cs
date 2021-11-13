using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    [SerializeField]
    protected string auraName;
    //[SerializeField]
    //protected UnitStats buffStats;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    virtual public void ActivateAura(GameObject target)
    {
        OnActiveAura(target);
    }
    virtual public void DeactivateAura(GameObject target)
    {
        OnDeactiveAura(target);
    }
    virtual public void OnActiveAura(GameObject target)
    {

    }
    virtual public void OnDeactiveAura(GameObject target)
    {

    }
}
