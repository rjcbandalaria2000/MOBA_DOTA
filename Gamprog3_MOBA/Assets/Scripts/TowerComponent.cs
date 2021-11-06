using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerComponent : MonoBehaviour
{
    [SerializeField] public List<GameObject> targets;
    public Collider rangeCollider;
    [SerializeField] private bool isInvincible;
    public GameObject referenceTower;

    public UnityEvent<TowerComponent> destroyed;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (referenceTower != null)
        {
            isInvincible = true;
        }
        else
        {
            isInvincible = false;
        }

        if (this.gameObject.GetComponent<Unit>() == true)
        {
            if(targets.Count > 0 && this.gameObject.GetComponent<Unit>().target == null)
            {
                this.gameObject.GetComponent<Unit>().SetTarget(targets[0]);
            }
            
        }

        if (targets.Count > 0)
        {
            Unit towerUnit = this.gameObject.GetComponent<Unit>();
            if (towerUnit)
            {
                if (towerUnit.target == null)
                {
                    for (int i = 0; i < targets.Count; i++)
                    {
                        if (targets[i] != null)
                        {
                            towerUnit.target = targets[i];
                            break;
                        }
                        else
                        {
                            targets.RemoveAt(i);
                        }

                    }
                }
            }
        }
    }

   

    
}
