using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public UIManager UI;
    [SerializeField]
    Unit unitSelected;
    //public DisplayUnitStats unitStats;
    //public TowerDestroy towerDestroyer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
           
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Debug.Log(hitInfo.collider.gameObject);

                unitSelected = hitInfo.transform.gameObject.GetComponent<Unit>();
                //TowerComponent towerSelected = hitInfo.transform.gameObject.GetComponent<TowerComponent>();
             
            }

            if (unitSelected)
            {
                UI.name.text = unitSelected.name;
                UI.HP_Bar_Slider.value = unitSelected.gameObject.GetComponent<HealthComponent>().GetCurrentHealth() / unitSelected.gameObject.GetComponent<HealthComponent>().GetMaxHP();

                if (unitSelected.gameObject.GetComponent<ManaComponent>() != null)
                {
                    UI.Mana_Bar_Slider.value = unitSelected.gameObject.GetComponent<ManaComponent>().GetCurrentMana() / unitSelected.gameObject.GetComponent<ManaComponent>().GetMaxMana();
                }
                else
                {
                    UI.Mana_Bar_Slider.value = 0;
                }
                if (unitSelected.gameObject.GetComponent<UnitStats>() != null)
                {
                    UnitStats selectedStats = unitSelected.gameObject.GetComponent<UnitStats>();
                    UI.AtkVal.text = selectedStats.GetBaseDamage().ToString();
                    UI.DefVal.text = selectedStats.GetBaseArmor().ToString();
                    UI.SpeedVal.text = selectedStats.GetMovementSpeed().ToString();

                    if (unitSelected.gameObject.GetComponent<LevelComponent>() != null)
                    {
                        LevelComponent selectedLevel = unitSelected.gameObject.GetComponent<LevelComponent>();
                        UI.levelValue.text = selectedLevel.Level.ToString();
                        UI.expValue.text = selectedLevel.currentEXP.ToString() + " / " + selectedLevel.maxEXP.ToString();
                    }

                    if (unitSelected.gameObject.GetComponent<BountyComponent>() != null)
                    {
                        BountyComponent selectedBounty = unitSelected.gameObject.GetComponent<BountyComponent>();
                        UI.goldValue.text = selectedBounty.Gold.ToString();
                    }

                    if (unitSelected.unitType == UnitType.Hero)
                    {
                        UI.heroImage.gameObject.SetActive(true);
                        UI.skillsCanvas.gameObject.SetActive(true);
                        //UI.skill1_icon.gameObject.SetActive(true);
                        //UI.skill2_icon.gameObject.SetActive(true);
                        //UI.skill3_icon.gameObject.SetActive(true);
                        //UI.skill4_icon.gameObject.SetActive(true);


                    }
                    else if (unitSelected.unitType != UnitType.Hero)
                    {
                        UI.heroImage.gameObject.SetActive(false);
                        UI.skillsCanvas.gameObject.SetActive(false);
                        //UI.skill1_icon.gameObject.SetActive(false);
                        //UI.skill2_icon.gameObject.SetActive(false);
                        //UI.skill3_icon.gameObject.SetActive(false);
                        //UI.skill4_icon.gameObject.SetActive(false);
                    }

                    SingletonManager.Get<DisplayUnitStats>().objectUnitStat = selectedStats;
                }
                else
                {
                    UI.AtkVal.text = 0.ToString();
                    UI.DefVal.text = 0.ToString();
                    UI.SpeedVal.text = 0.ToString();
                }

                //UI.HP_Bar.fillAmount = unitSelected.gameObject.GetComponent<HealthComponent>().GetCurrentHealth() / unitSelected.gameObject.GetComponent<HealthComponent>().GetMaxHP();
            }
            else
            {
                SingletonManager.Get<DisplayUnitStats>().objectUnitStat = null;
                Debug.Log("Not Unit");
            }
        }

        
    }

   
}
