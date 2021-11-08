using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    float gameTime = 0;
    [SerializeField] int waves = 0;
    public static float distanceUnit = 85.714f; // Distance Formula: 1200(Dota Units) / 14(Unity Units)

    public GameObject redBase;
    public GameObject blueBase;

    public bool gameEnd = false;

    public Faction unitFaction;

    private void Awake()
    {
        SingletonManager.Register(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (redBase)
        {
            HealthComponent redBaseHealth = redBase.GetComponent<HealthComponent>();
            redBaseHealth.death.AddListener(blueDebugWin);
        }
        if (blueBase)
        {
            HealthComponent blueBasehealth = blueBase.GetComponent<HealthComponent>();
            blueBasehealth.death.AddListener(redDebugWin);
        }
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

    public int GetWaves()
    {
        return waves;
    }

    public void AddWave()
    {
        waves += 1;
    }

    public bool gameEnded()
    {
        return gameEnd;
    }

    public void redDebugWin(HealthComponent health)
    {
        Debug.Log("Red WIN");
        gameEnd = true;
    }

    public void blueDebugWin(HealthComponent health)
    {
        Debug.Log("Blue WIN");
        gameEnd = true;
    }
}
