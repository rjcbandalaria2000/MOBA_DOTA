using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TowerDestroy : MonoBehaviour
{
    //[SerializeField] UnityEvent destroyTowerEvent;
    //public Button DestroyTowerButton;
    //public GameObject tower;

   
    // Start is called before the first frame update
    void Start()
    {
        //DestroyTowerButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //destroyTowerEvent.AddListener(destroyTower);


    }

    //private void OnMouseDown()
    //{
    //    Debug.Log("Event Invoke");
    //    destroyTowerEvent.Invoke();
    //}

    //public void destroyTower()
    //{
    //    Debug.Log("Destroy");
    //    DestroyTowerButton.gameObject.SetActive(false);
    //    Destroy(tower);
    //}

}