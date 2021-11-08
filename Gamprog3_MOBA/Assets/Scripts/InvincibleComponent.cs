using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleComponent : MonoBehaviour
{
    public bool isInvincible;
    public List<GameObject> buildingReference;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (buildingReference != null)
        {
            isInvincible = true;
        }
        else
        {
            isInvincible = false;
        }
    }

    //public void targetImmune()
    //{
    //    if(SingletonManager.Get<GameManager>().unitFaction != this.gameObject.GetComponent<FactionComponent>().unitFaction)
    //    {
    //        //cant target
    //    }
    //}
}
