using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerManager : MonoBehaviour
{
    [SerializeField]
    float timeMultiplier = 1f;
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
}
