using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class LightingManager : MonoBehaviour
{
    //Code Reference: https://www.youtube.com/watch?v=m9hj9PdO328&t=38s
    [SerializeField]
    Light directionalLight;
    [SerializeField]
    LightingPreset lightPreset;
    [SerializeField]
    float dayTimeChange;
    [SerializeField]
    float transitionTimer = 0;
    [SerializeField]
    float dayTransitionTime = 5f;
    bool isDay = true;

    [SerializeField, Range(0,30)]
    public float dayTimer; // LIGHTING -> DAY/NIGHT CYCLE

    private Coroutine dayTransitionRoutine;

    // Start is called before the first frame update
    void Start()
    {
        isDay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(lightPreset == null) {
            return;
        }

        if (Application.isPlaying)
        {
            dayTimer += Time.deltaTime;
            //dayTimer %= dayTimeChange;
            if(dayTimer >= dayTimeChange)
            {
               dayTransitionRoutine = StartCoroutine(ChangeDayNight());
                dayTimer = 0;
            }
            // Clamped between 0-600
            
            //ChangeLighting(dayTimer / dayTimeChange);
            //Separate time for tracking the dayTime and do coroutine when daytime goes to 5mins 
            //at least 5 sec transitiontime from day to night 
        }
    }

    
    void ChangeLighting(float timeOfDay)
    {
        RenderSettings.ambientLight = lightPreset.ambientColor.Evaluate(timeOfDay);
        directionalLight.color = lightPreset.directionalColor.Evaluate(timeOfDay);
        if (isDay) {
            //If Day, switch to night
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timeOfDay * 360f) - 45f, 0, 0));
        }
        else if (!isDay)
        {
            // If night, switch to day
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timeOfDay * 360f) + 45f, 0, 0));
        }
        

    }
    IEnumerator ChangeDayNight()
    {
        yield return new WaitForSeconds(0f);
        Debug.Log("DayNight Routine");
        if (transitionTimer < dayTransitionTime)
        {
            Debug.Log("Night Time");
            while (transitionTimer <= dayTransitionTime)
            {
                transitionTimer += Time.deltaTime;
                ChangeLighting(transitionTimer / dayTransitionTime);
            }
            isDay = false;
        }
        else if (transitionTimer >= dayTransitionTime)
        {
            Debug.Log("Day Time");
            while (transitionTimer > 0)
            {
                transitionTimer -= Time.deltaTime;
                if (transitionTimer < 0)
                {
                    transitionTimer = 0f;
                }
                ChangeLighting(transitionTimer / dayTransitionTime);
            }
            isDay = true;
        }
    }
}
