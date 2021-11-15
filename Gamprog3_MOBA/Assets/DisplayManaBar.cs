using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class DisplayManaBar : MonoBehaviour
{
    [SerializeField]
    ManaComponent unitManaComponent;
    [SerializeField]
    Slider manaSlider;
    // Start is called before the first frame update
    void Start()
    {
        manaSlider = this.GetComponent<Slider>();
        unitManaComponent = this.gameObject.transform.parent.
            gameObject.transform.parent.GetComponent<ManaComponent>();
        Assert.IsNotNull(unitManaComponent);
        Assert.IsNotNull(manaSlider);
        manaSlider.maxValue = unitManaComponent.GetMaxMana();
        manaSlider.value = unitManaComponent.GetCurrentMana();
    }

    // Update is called once per frame
    void Update()
    {
        manaSlider.maxValue = unitManaComponent.GetMaxMana();
        manaSlider.value = unitManaComponent.GetCurrentMana();
    }
}
