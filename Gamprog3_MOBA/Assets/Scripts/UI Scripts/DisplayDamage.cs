using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Assertions;

public class DisplayDamage : MonoBehaviour
{
    public DamageReceiver damageReceiver;
    public TextMeshProUGUI damageText;
    public HealthComponent unitHealthComponent;
    Coroutine displayDamageTextRoutine;
    // Start is called before the first frame update
    void Start()
    {
        damageReceiver = this.gameObject.transform.parent.gameObject.GetComponent<DamageReceiver>();
        damageText = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        unitHealthComponent = this.gameObject.transform.parent.gameObject.GetComponent<HealthComponent>();
        Assert.IsNotNull(unitHealthComponent, "Health Component cannot be null as used to display damage Text");
        unitHealthComponent.damaged.AddListener(OnDamaged);
        //dmgValue.gameObject.SetActive(false);
       // damageReceiver = this.gameObject.GetComponent<DamageReceiver>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDamaged(float damageTaken)
    {
        displayDamageTextRoutine = StartCoroutine(displayDamage(damageTaken));
    }

    public IEnumerator displayDamage(float damage)
    {
        if(this.gameObject != null)
        {
            RectTransform damageTextUI = this.gameObject.GetComponent<RectTransform>();
            yield return new WaitForSeconds(0.1f);
            damageText.text = damage.ToString("0");
            damageTextUI.DOAnchorPosY(damageTextUI.anchoredPosition.y + 10, 0.5f);
            yield return new WaitForSeconds(0.2f);
            damageTextUI.DOAnchorPosY(damageTextUI.anchoredPosition.y - 10, 0.5f);
            damageText.text = "";
        }
       
    }
}
