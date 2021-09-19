using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealthBar : MonoBehaviour
{
    [SerializeField]
    Slider healthSlider;



    // Start is called before the first frame update
    void Start()
    {
        healthSlider = this.GetComponent<Slider>();
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
    
}
