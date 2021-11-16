using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DebuggerManager : MonoBehaviour
{
    [SerializeField]
    float timeMultiplier = 1f;
    public GameObject player;
    //public List<GameObject> towerButton;
    public UIManager UI;
    public GameObject selectedTower;
    


    // Start is called before the first frame update
    void Start()
    {

        //destroyTowerButton.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Debug.Log(hitInfo.collider.gameObject);

               
                TowerComponent towerSelected = hitInfo.transform.gameObject.GetComponent<TowerComponent>();

                if (towerSelected)
                {
                    selectedTower = towerSelected.gameObject;
                    UI.DestroyTowerButton.gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("Not Unit");
                }

            }
        }
    }

    public void increaseTimeSpeed()
    {
        timeMultiplier *= 2;
        Time.timeScale = timeMultiplier;
    }

    public void decreaseTimeSpeed()
    {
        timeMultiplier /= 2;
        Time.timeScale = timeMultiplier;
    }

    public void ResetTimeSpeed()
    {
        timeMultiplier = 1;
        Time.timeScale = timeMultiplier;
    }

    public void fullHealth()
    {
        player.gameObject.GetComponent<HealthComponent>().SetCurrentHealth(player.gameObject.GetComponent<HealthComponent>().GetMaxHP());
    }

    public void restoreMana()
    {
        player.gameObject.GetComponent<ManaComponent>().SetCurrentMana(player.gameObject.GetComponent<ManaComponent>().GetMaxMana());
    }

    /*public void destroyTower()
    {
        Debug.Log("Select Tower to Destroy");

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hitInfo.collider.gameObject);

                BoxCollider towerSelect = hit.collider as BoxCollider;

                if (towerSelect != null)
                {
                    Destroy(towerSelect.gameObject);
                    Debug.Log("Destroy Tower");
                }
               
            }
            else
            {
                
                    Debug.Log("Not Tower");
                
            }
        }
    }*/

    public void destroyTower()
    {
        Debug.Log("Destroy");
        UI.DestroyTowerButton.gameObject.SetActive(false);
        // DestroyTowerButton.gameObject.SetActive(false);
        Destroy(selectedTower);
    }

    //public void selectToDestroyTower()
    //{
    //    for (int i = 0; i < towerButton.Count; i++)
    //    {
    //        towerButton[i].SetActive(true);
    //    }
    //}
}
