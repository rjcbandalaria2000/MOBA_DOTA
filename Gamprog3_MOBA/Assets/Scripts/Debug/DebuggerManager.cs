using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerManager : MonoBehaviour
{
    [SerializeField]
    float timeMultiplier = 1f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void destroyTower()
    {
        Debug.Log("Select Tower to Destroy");

        if (Input.GetMouseButtonDown(1))
        {
            //RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Debug.Log(hitInfo.collider.gameObject);

                Unit unitSelected = hitInfo.transform.gameObject.GetComponent<Unit>();

                if (unitSelected != null && unitSelected.CompareTag("Tower"))
                {
                    Destroy(unitSelected.gameObject);
                }
                else
                {
                    Debug.Log("Not Tower");
                }
            }
        }
    }
}
