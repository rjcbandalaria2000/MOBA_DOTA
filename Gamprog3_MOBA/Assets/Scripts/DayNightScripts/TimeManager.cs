using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TimeManager : MonoBehaviour
{
    //Code Reference: https://www.youtube.com/watch?v=m9hj9PdO328&t=38s
    [SerializeField]
    Light directionalLight;
    [SerializeField]
    LightingPreset lightPreset;
    [SerializeField, Range(0,24)]
    float time;
    float timeMultiplier = 1f;
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
            time += Time.deltaTime;
            time %= 24; // Clamped between 0-24
            ChangeLighting(time/ 24);
        }
    }

    
    void ChangeLighting(float timeOfDay)
    {
        RenderSettings.ambientLight = lightPreset.ambientColor.Evaluate(timeOfDay);
        directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timeOfDay * 360f) - 90f, 170, 0));

    }
}
