using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField]
    UnitStats source;
    float damageMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        source = this.transform.gameObject.GetComponent<UnitStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float CalculateDamageMultiplier()
    {
        float unitTotalArmor = source.GetTotalArmor();
        return damageMultiplier = 1 - ((0.052f * unitTotalArmor) /
            (0.9f + 0.048f * Mathf.Abs(unitTotalArmor)));
    }
}
