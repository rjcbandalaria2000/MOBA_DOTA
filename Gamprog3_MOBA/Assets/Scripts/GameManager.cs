using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    float gameTime = 0;
    public static float distanceUnit = 85.714f; // Distance Formula: 1200(Dota Units) / 14(Unity Units)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
    }

    public float GetGameTime()
    {
        return gameTime;
    }
}
