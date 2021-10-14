using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public UIManager UI;

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

                if(unitSelected)
                {
                    UI.name.text = unitSelected.name;
                    UI.HP_Bar_Slider.value = unitSelected.gameObject.GetComponent<HealthComponent>().GetCurrentHealth() / unitSelected.gameObject.GetComponent<HealthComponent>().GetMaxHP();

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
