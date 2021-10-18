using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DebuggerManager : MonoBehaviour
{
    [SerializeField]
    float timeMultiplier = 1f;
    public GameObject player;
    public List<GameObject> towerButton;

    private void Awake()
    {
        SingletonManager.Register(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < towerButton.Count; i++)
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
        towerButton.RemoveAt(index);
        

        for (int i = 0; i < towerButton.Count; i++)
        {
            towerButton[i].SetActive(false);
        }
    }

    public void selectToDestroyTower()
    {
        for (int i = 0; i < towerButton.Count; i++)
        {
            towerButton[i].SetActive(true);
        }
    }
}
