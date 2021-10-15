using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField]
    int manaCost;
    [SerializeField]
    int castRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void ActivateSkill()
    {

    }

    virtual public void DeactivateSkill()
    {

    }

    virtual public void OnActivate()
    {

    }

    virtual public void OnDeactivateSkill()
    {

    }
}
