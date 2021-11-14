using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDamage : MonoBehaviour
{
    public DamageReceiver damageReceiver;
    public Text dmgValue;

    public void Awake()
    {
        SingletonManager.Register(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        //dmgValue.gameObject.SetActive(false);
       // damageReceiver = this.gameObject.GetComponent<DamageReceiver>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator displayDamage(float damage)
    {
        if(this.gameObject != null)
        {
            yield return new WaitForSeconds(0.1f);
            dmgValue.text = damage.ToString();
            yield return new WaitForSeconds(0.2f);
            dmgValue.text = "";
        }
       
    }
}
