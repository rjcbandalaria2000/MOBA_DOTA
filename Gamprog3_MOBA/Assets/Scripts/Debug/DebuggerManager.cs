using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DebuggerManager : MonoBehaviour
{
    [SerializeField]
    float timeMultiplier = 1f;
    public GameObject player;
    public GameObject[] towerButton;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < towerButton.Length; i++)
        {
            towerButton[i].SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void destroyTower(int index)
    {
        Destroy(towerButton[index].GetComponentsInParent<GameObject>()[index]);
    }

    public void selectToDestroyTower()
    {
        for (int i = 0; i < towerButton.Length; i++)
        {
            towerButton[i].SetActive(true);
        }
    }
}
