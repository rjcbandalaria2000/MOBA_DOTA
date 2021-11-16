using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public UIManager UI;
    //public TowerDestroy towerDestroyer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Debug.Log(hitInfo.collider.gameObject);

                Unit unitSelected = hitInfo.transform.gameObject.GetComponent<Unit>();
                //TowerComponent towerSelected = hitInfo.transform.gameObject.GetComponent<TowerComponent>();

           
                if(unitSelected)
                {
                    UI.name.text = unitSelected.name;
                    UI.HP_Bar_Slider.value = unitSelected.gameObject.GetComponent<HealthComponent>().GetCurrentHealth() / unitSelected.gameObject.GetComponent<HealthComponent>().GetMaxHP();

                    if(unitSelected.gameObject.GetComponent<UnitStats>() != null)
                    {
                        UnitStats selectedStats = unitSelected.gameObject.GetComponent<UnitStats>();
                        UI.AtkVal.text = selectedStats.GetBaseDamage().ToString();
                        UI.DefVal.text = selectedStats.GetBaseArmor().ToString();
                        UI.SpeedVal.text = selectedStats.GetMovementSpeed().ToString();

                        if (unitSelected.unitType == UnitType.Hero)
                        {
                            UI.heroImage.gameObject.SetActive(true);
                            UI.skill1_icon.gameObject.SetActive(true);
                            UI.skill2_icon.gameObject.SetActive(true);
                            UI.skill3_icon.gameObject.SetActive(true);
                            UI.skill4_icon.gameObject.SetActive(true);
                        }
                        else if (unitSelected.unitType != UnitType.Hero)
                        {
                            UI.heroImage.gameObject.SetActive(false);
                            UI.skill1_icon.gameObject.SetActive(false);
                            UI.skill2_icon.gameObject.SetActive(false);
                            UI.skill3_icon.gameObject.SetActive(false);
                            UI.skill4_icon.gameObject.SetActive(false);
                        }
                        
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
                    Debug.Log("Not Unit");
                }

            }
        }
    }

   
}
