using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{

    Transform mainCameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(this.transform.position + mainCameraTransform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
