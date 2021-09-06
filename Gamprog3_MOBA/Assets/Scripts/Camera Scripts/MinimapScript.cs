using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    [SerializeField]
    Camera      mainCamera;
    [SerializeField]
    Camera      minimapCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        //minimapCamera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit mapClick;
            ////Ray ray = minimapCamera.ScreenPointToRay(Input.mousePosition);
            //          //Camera.current.ScreenPointToRay(Input.mousePosition);

            //if (Physics.Raycast(ray, out mapClick, 100.0f))
            //{
            //    if (mapClick.transform != null)
            //    {
            //        Debug.Log("Mouse Position: " + mapClick.transform.position);
            //    }
            //}

            //MoveCamera();
        }

    }

    public void MoveCamera()
    {
        Vector3 cameraPosition = minimapCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Main Camera Position " + cameraPosition);
        mainCamera.transform.position = new Vector3(cameraPosition.x, mainCamera.transform.position.y, cameraPosition.z);
    }
}
