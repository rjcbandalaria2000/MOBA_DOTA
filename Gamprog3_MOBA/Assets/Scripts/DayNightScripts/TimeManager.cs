using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
=======

>>>>>>> main
[ExecuteInEditMode]
public class TimeManager : MonoBehaviour
{
    //Code Reference: https://www.youtube.com/watch?v=m9hj9PdO328&t=38s
    [SerializeField]
    Light directionalLight;
    [SerializeField]
    LightingPreset lightPreset;
<<<<<<< HEAD
    [SerializeField, Range(0,24)]
    float time;
    float timeMultiplier = 1f;
=======
    [SerializeField, Range(0,600)]
    public float dayTimer; // LIGHTING -> DAY/NIGHT CYCLE
    public float gameTime = 0;
    public float timeMultiplier = 1f;
>>>>>>> main
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lightPreset == null) {
            return;
        }

        if (Application.isPlaying)
        {
<<<<<<< HEAD
            time += Time.deltaTime;
            time %= 24; // Clamped between 0-24
            ChangeLighting(time/ 24);
=======
            Time.timeScale = timeMultiplier;
            dayTimer += Time.deltaTime; //* timeMultiplier;

           
            dayTimer %= 600; // Clamped between 0-600
            ChangeLighting(dayTimer/ 600);

            gameTime += Time.deltaTime;
>>>>>>> main
        }
    }

    
    void ChangeLighting(float timeOfDay)
    {
        RenderSettings.ambientLight = lightPreset.ambientColor.Evaluate(timeOfDay);
        directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timeOfDay * 360f) - 90f, 170, 0));

    }
<<<<<<< HEAD
=======

    public void increaseTimeSpeed()
    {
        timeMultiplier *= 2;
    }

    public void decreaseTimeSpeed()
    {
        timeMultiplier /= 2;
    }
>>>>>>> main
}
