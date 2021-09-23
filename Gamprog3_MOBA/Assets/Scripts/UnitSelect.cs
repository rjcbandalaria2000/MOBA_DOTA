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
                    UI.HP_Bar.fillAmount = hitInfo.collider.gameObject.transform.parent.GetComponent<HealthComponent>().GetCurrentHealth() / hitInfo.collider.gameObject.GetComponent<HealthComponent>().GetMaxHP();
                }
                else
                {
                    Debug.Log("Not Unit");
                }
               

            }
        }
    }
}
