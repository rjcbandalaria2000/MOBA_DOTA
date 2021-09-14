using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private float panSpeed = 10f;
    [SerializeField] private float panBorder = 10f;
    public Vector2 panLimit_Horizontal;
    public Vector2 panLimit_Vertical;

    [SerializeField] private float scrollSpeed = 20f;
    [SerializeField] private float minY = 25f; 
    [SerializeField] private float maxY = 90f;

    public GameObject player;

    public int cameraOffsetX;
    public int cameraOffsetZ;

    // Start is called before the first frame update
    void Start()
    {
       // this.transform.position = new Vector3(-42,31,-83);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.mousePosition.y >= Screen.height - panBorder)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= panBorder)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x >= Screen.width - panBorder)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x <= panBorder)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;


        pos.x = Mathf.Clamp(pos.x, -panLimit_Horizontal.x, panLimit_Horizontal.y);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit_Vertical.x, panLimit_Vertical.y);

        transform.position = pos;

        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            focusPlayer();
        }

    }

    public void focusPlayer()
    {
        this.transform.position = new Vector3(player.transform.position.x , this.transform.position.y, player.transform.position.z - cameraOffsetZ);
    }

}
