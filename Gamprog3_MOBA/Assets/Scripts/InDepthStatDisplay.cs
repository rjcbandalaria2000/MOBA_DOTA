using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InDepthStatDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool mouse_over = false;
    void Update()
    {
        if (mouse_over)
        {
            Debug.Log("Mouse Over");
            SingletonManager.Get<UIManager>().inDepthStatsCanvas.gameObject.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        Debug.Log("Mouse enter");
        SingletonManager.Get<UIManager>().inDepthStatsCanvas.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        Debug.Log("Mouse exit");
        SingletonManager.Get<UIManager>().inDepthStatsCanvas.gameObject.SetActive(false);
    }
}

