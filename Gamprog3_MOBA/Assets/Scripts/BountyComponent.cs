using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyComponent : MonoBehaviour
{
    [SerializeField]
     public int Gold;
    [SerializeField]
    int goldBounty;

    public GameObject killer; //for last hit

    public List<GameObject> bountyInRange;

    public Collider bountyRange;
    public GameObject bountyIncludeObject;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.GetComponent<Unit>() != null)
        {
            if (this.gameObject.GetComponent<Unit>().unitType == UnitType.Hero)
            {
                Gold = 600;
            }
            else
            {
                Gold = 0;
            }
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider bountyRange)
    {
        bountyIncludeObject = bountyRange.gameObject;
        bountyInRange.Add(bountyIncludeObject);

    }

    private void OnTriggerExit(Collider bountyRange)
    {
        bountyInRange.Remove(bountyIncludeObject);
    }
    
}
