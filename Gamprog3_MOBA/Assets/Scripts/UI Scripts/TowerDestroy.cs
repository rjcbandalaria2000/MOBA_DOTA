using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerDestroy : MonoBehaviour
{
    [SerializeField] UnityEvent destroyTowerEvent;
    public GameObject tower;

   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        destroyTowerEvent.AddListener(destroyTower);
    }

    private void OnMouseDown()
    {
        Debug.Log("Event Invoke");
        destroyTowerEvent.Invoke();
    }

    public void destroyTower()
    {
        Debug.Log("Destroy");
        Destroy(tower);
    }

}