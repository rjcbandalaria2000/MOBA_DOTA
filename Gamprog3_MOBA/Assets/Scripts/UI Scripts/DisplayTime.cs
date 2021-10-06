using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayTime : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    GameManager gameManager; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float minutes = gameManager.GetGameTime() / 60f;
        float seconds = gameManager.GetGameTime() % 60f;
        Debug.Log("Minutes: " + minutes);
        Debug.Log("Seconds: " + seconds);
        timerText.text = minutes.ToString("00") + " : " + seconds.ToString("00");
    }
}
