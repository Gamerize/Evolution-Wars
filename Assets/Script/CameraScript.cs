using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float CameraSpeed = 5f;
    public Transform Camera;
    public Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        //Camera.position = startingPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse X") < 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse Y") * Time.deltaTime * CameraSpeed, 0f, Input.GetAxisRaw("Mouse X") * Time.deltaTime * CameraSpeed);
        }
        else if (Input.GetAxis("Mouse X") > 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse Y") * Time.deltaTime * CameraSpeed, 0f, Input.GetAxisRaw("Mouse X") * Time.deltaTime * CameraSpeed);
        }
    }
}
