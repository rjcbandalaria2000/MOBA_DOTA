using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class DisplayHealthBar : MonoBehaviour
{
    [SerializeField]
    Slider healthSlider;
    [SerializeField]
    HealthComponent healthComponent; 


    // Start is called before the first frame update
    void Start()
    {
        healthSlider = this.GetComponent<Slider>();
        healthComponent = this.transform.parent.gameObject.transform.parent.
            GetComponent<HealthComponent>();
        Assert.IsNotNull(healthComponent);
        healthSlider.maxValue = healthComponent.maxHP;
        healthSlider.value = healthComponent.GetCurrentHealth();
        //SetMaxHealth(healthComponent.GetMaxHP());
    }
    public void SetCurrentHealth(float health)
    {
        healthSlider.value = health;
    }

    public void SetMaxHealth(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    private void Update()
    {
        healthSlider.value = healthComponent.GetCurrentHealth();
        healthSlider.maxValue = healthComponent.maxHP;
    }

}
