using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    [SerializeField]
    int manaCost;
    [SerializeField]
    float castRange;
    public virtual void OnActivate()
    {

    }

    public virtual void OnDeactivate()
    {

    }

    public int GetManaCost()
    {
        return manaCost;
    }

    public float GetCastRange()
    {
        return castRange;
    }
   
}
