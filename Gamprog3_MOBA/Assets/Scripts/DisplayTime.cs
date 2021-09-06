using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayTime : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TimeManager timeManager; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float minutes = timeManager.gameTime / 60f;
        float seconds = timeManager.gameTime % 60f;

        timerText.text = minutes.ToString("00") + " : " + seconds.ToString("00");
    }
}
